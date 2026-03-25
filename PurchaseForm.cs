using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace SkyTickets
{
    public partial class PurchaseForm : Form
    {
        public string Departure {  get; set; }
        public string Arrival {  get; set; }
        public DateTime DepartureDate {  get; set; }
        public DateTime ArrivalDate { get; set; }
        public string Seat {  get; set; }
        public int SeatID {  get; set; }
        public string Tariff {  get; set; }
        public int Total {  get; set; }
        public int Voyage {  get; set; }

        public PurchaseForm()
        {
            InitializeComponent();
        }

        private void PurchaseForm_Load(object sender, EventArgs e)
        {
            string sql = $"SELECT tariff_cost FROM tariffs WHERE tariff_name='{Tariff}'";
            var conn = DataModule.GetConnection();
            using (MySqlCommand command = new MySqlCommand(sql, conn))
            {
                using (MySqlDataReader reader = command.ExecuteReader())
                { 
                    reader.Read();
                    Total += reader.GetInt32("tariff_cost");
                }
            }

            departure.Text = Departure;
            arrival.Text = Arrival;
            departureDate.Text = DepartureDate.ToString();
            arrivalDate.Text = ArrivalDate.ToString();
            seatNumber.Text = Seat;
            tariff.Text = Tariff;
            total.Text = Total.ToString() + " руб.";
        }

        private void buyButton_Click(object sender, EventArgs e)
        {
            var connection = DataModule.GetConnection();

            // добавляем запись в таблицу билетов
            string sql = @"INSERT INTO tickets (passenger_id, voyage_id, tariff_id, seat_id, total_cost) 
                                VALUES (@passenger_id, @voyage_id, @tariff_id, @seat_id, @total_cost)";

            using (MySqlCommand command = new MySqlCommand(sql, connection))
            {

                command.Parameters.AddWithValue("@passenger_id", DataModule.Passenger_Id);
                command.Parameters.AddWithValue("@voyage_id", Voyage);

                int a;
                if (Tariff == "Эконом")
                    a = 1;
                else if (Tariff == "Бизнес")
                    a = 2;
                else
                    a = 3;

                command.Parameters.AddWithValue("@tariff_id", a);
                command.Parameters.AddWithValue("@seat_id", SeatID);
                command.Parameters.AddWithValue("@total_cost", Total);
                command.ExecuteNonQuery();
            }

            // Устанавливаем занятость места
            sql = $"UPDATE seats_and_voyages_link SET is_ordered = 1 WHERE seat_id = {SeatID} AND voyage_id = {Voyage}";
            using (MySqlCommand command = new MySqlCommand(sql, connection))
            {
                command.ExecuteNonQuery();
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
