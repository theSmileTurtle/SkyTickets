using Google.Protobuf.Compiler;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace SkyTickets
{
    public partial class PlaneLayoutForm : Form
    {
        public string From {  get; set; }
        public string To { get; set; }
        public DateTime When { get; set; }

        public int vId = 0, pId = 0;

        public PlaneLayoutForm()
        {
            InitializeComponent();
        }

        // Обработчик нажатия на сидения
        private void SeatButton_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            OrderedSeat seatInfo = (OrderedSeat)btn.Tag; // получаем данные о сидении

            // создаем форму оплаты и передаем в нее параметры
            PurchaseForm purchaseForm = new PurchaseForm();

            string sql = $"SELECT * FROM view_for_purchase " +
                $"WHERE voyage_id = {seatInfo.voyage_id}";

            var conn = DataModule.GetConnection();
            using (MySqlCommand command = new MySqlCommand(sql, conn))
            {
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    reader.Read();
                    purchaseForm.Departure = reader.GetString("departure");
                    purchaseForm.Arrival = reader.GetString("arrival");
                    purchaseForm.DepartureDate = reader.GetDateTime("departure_date");
                    purchaseForm.ArrivalDate = reader.GetDateTime("arrival_date");
                    purchaseForm.Total = reader.GetInt32("price");
                }
            }

            purchaseForm.Seat = seatInfo.seat_number;
            purchaseForm.SeatID = seatInfo.seat_id;
            purchaseForm.Voyage = seatInfo.voyage_id;

            switch (seatInfo.seat_number[0])
            {
                case 'c': 
                    purchaseForm.Tariff = "Эконом";
                    break;

                case 'b':
                    purchaseForm.Tariff = "Бизнес";
                    break;

                case 'f':
                    purchaseForm.Tariff = "Первый класс";
                    break;

                default:
                    purchaseForm.Tariff = "";
                    break;
            }

            var result = purchaseForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void FillPlaneSeats(int plane_id, int voyage_id)
        {
            var conn = DataModule.GetConnection();
            // откуда, куда и когда
            string voyage_data_sql = $"SELECT departure, arrival, departure_date FROM view_for_purchase WHERE voyage_id = {voyage_id}";
            using (MySqlCommand command = new MySqlCommand(voyage_data_sql, conn))
            {
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    reader.Read();
                    fromToLabel.Text = reader.GetString("departure") + " -> " + reader.GetString("arrival");
                    dateTimeLabel.Text = reader.GetDateTime("departure_date").ToString();
                }
            }

            // sql запросы и получение соединения
            string seats_and_voyage_link_sql = $"SELECT seat_id, seat_number, is_ordered FROM view_seats_and_voyages " +
                $"WHERE voyage_id = {voyage_id}";
            string sql = $"SELECT layout, model FROM planes WHERE plane_id = {plane_id}";

            // список сидений
            List<OrderedSeat> orderedSeats = new List<OrderedSeat>();
            OrderedSeat current;
            current.voyage_id = voyage_id;

            // получение данных о занятых и не занятых мест
            using (MySqlCommand cmd = new MySqlCommand(seats_and_voyage_link_sql, conn))
            {
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        current.seat_id = reader.GetInt32("seat_id");
                        current.seat_number = reader.GetString("seat_number");
                        current.is_ordered = reader.GetInt32("is_ordered");

                        orderedSeats.Add(current);
                    }
                }
            }

            // парсинг json и расстановка мест по салону
            using (MySqlCommand command = new MySqlCommand(sql, conn))
            {
                using(MySqlDataReader reader = command.ExecuteReader())
                {
                    reader.Read();
                    string jsonString = reader.GetString("layout");
                    string planeModel = reader.GetString("model");

                    planeModelLabel.Text = planeModel;

                    if (string.IsNullOrEmpty(jsonString))
                        return;

                    PlaneLayout p = JsonConvert.DeserializeObject<PlaneLayout>(jsonString);
                    SeatRow[] tariffsList = { p.First, p.Business, p.Cheap };

                    // Показатели начальных координат и размеров
                    int firstSize, businessSize, cheapSize;
                    int x, y, baseX;
                    int buttonSize;
                    int lenghOfRow, countOfRows, baseCountOfRows;
                    int index = 0;
                    if (planeModel.Contains("Boeing"))
                    {
                        firstSize = 50;
                        businessSize = 30;
                        cheapSize = 30;
                    }
                    else if (planeModel.Contains("Airbus"))
                    {
                        firstSize = 50;
                        businessSize = 32;
                        cheapSize = 31;
                    }
                    else
                    {
                        firstSize = 0;
                        businessSize = 0;
                        cheapSize = 0;
                    }

                    // Единый цикл для заполнения салона местами
                    baseX = 5;
                    foreach (var tariff in tariffsList)
                    {
                        if (tariff == tariffsList[0])
                        {
                            buttonSize = firstSize;
                            baseCountOfRows = 0;
                        }
                        else if(tariff == tariffsList[1])
                        {
                            buttonSize = businessSize;
                            baseCountOfRows = 1;
                        }
                        else
                        {
                            buttonSize = cheapSize;
                            baseCountOfRows = 1;
                        }

                        countOfRows = baseCountOfRows;

                        int[] yPos = { planePanel.Height / 5 - buttonSize*(countOfRows+1), planePanel.Height / 2 - buttonSize * (countOfRows + 1) / 2,
                            planePanel.Height - (planePanel.Height / 5 - buttonSize * (countOfRows + 1)) - buttonSize * (countOfRows + 1) - 5*(countOfRows + 1) };

                        List<int>[] rowsList = { tariff.A, tariff.B, tariff.C };
                        lenghOfRow = 0;
                        foreach (var row in rowsList)
                        {
                            x = baseX;
                            lenghOfRow = 0;

                            if (row == rowsList[0])
                            {
                                y = yPos[0];
                                countOfRows = baseCountOfRows;
                            }
                            else if (row == rowsList[1])
                            {
                                y = yPos[1];
                                if(planeModel.Contains("Boeing") && tariff == tariffsList[2])
                                {
                                    countOfRows = 2;
                                    y = planePanel.Height / 2 - buttonSize * (countOfRows + 1) / 2;
                                }
                            }
                            else
                            {
                                y = yPos[2];
                                countOfRows = baseCountOfRows;
                            }
                            foreach (var seat in row)
                            {
                                Button b = new Button();
                                b.Text = seat.ToString();
                                b.Width = buttonSize;
                                b.Height = buttonSize;

                                // назначение цвета в зависимости от занятости места
                                if(orderedSeats[index].is_ordered==0)
                                    b.BackColor = Color.Green;
                                else
                                {
                                    b.BackColor = Color.Red;
                                    b.Enabled = false;
                                }

                                b.Name = orderedSeats[index].seat_number; // назначение имени     p.s. надеюсь в правильной последовательности
                                b.Tag = orderedSeats[index++]; // назначить тег
                                b.Click += SeatButton_Click; // подписать на клик


                                if (lenghOfRow > countOfRows)
                                {
                                    if (row == rowsList[0])
                                        y = yPos[0];
                                    else if(row == rowsList[1])
                                    {
                                        y = yPos[1];
                                        if (planeModel.Contains("Boeing") && tariff == tariffsList[2])
                                            y = planePanel.Height / 2 - buttonSize * (countOfRows + 1) / 2;
                                    }
                                    else
                                        y = yPos[2];

                                    x += buttonSize + 5;
                                    lenghOfRow = 0;
                                }
                                b.Location = new Point(x, y);
                                y += buttonSize+5;
                                lenghOfRow++;

                                planePanel.Controls.Add(b);
                            }
                            
                        }
                        baseX += 320; // разграничение классов
                    }
                }
            }
        }

        private void PlaneLayoutForm_Load(object sender, EventArgs e)
        {
            // если переданные id рейса и самолета существуют, то отрисовываем самолет
            if (vId != 0 && pId != 0)
            {
                FillPlaneSeats(pId, vId);
            }
        }
    }
}
