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

namespace SkyTickets
{
    public partial class TicketsForm : Form
    {
        public TicketsForm()
        {
            InitializeComponent();
        }

        private void TicketsForm_Load(object sender, EventArgs e)
        {
            List<Ticket> tickets = new List<Ticket>();
            Ticket current;

            string sql = $"SELECT * FROM view__for_generate_tickets " +
                $"WHERE passenger_id = {DataModule.Passenger_Id}";

            var conn = DataModule.GetConnection();
            using (MySqlCommand command = new MySqlCommand(sql, conn))
            {
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    // Получаем все билеты пользователя по его id
                    while (reader.Read())
                    {
                        current.ticket_id = reader.GetInt32("ticket_id");
                        current.passenger_id = DataModule.Passenger_Id;
                        current.first_name = reader.GetString("first_name");
                        current.last_name = reader.GetString("last_name");
                        current.patronymic = reader.GetString("patronymic");
                        current.departure_airport = reader.GetString("departure_city_code");
                        current.arrival_airport = reader.GetString("arrival_city_code");
                        current.departure_date = reader.GetDateTime("departure_date");
                        current.arrival_date = reader.GetDateTime("arrival_date");
                        current.seat = reader.GetString("seat");
                        current.tariff = reader.GetString("tariff");
                        current.total_cost = reader.GetInt32("total_cost");

                        tickets.Add(current);
                    }
                }
            }

            if(tickets.Count > 0)
            {
                int width = 650, height = 75;
                int x = 10, y = 20;
                int index = 0;
                foreach (Ticket ticket in tickets)
                {
                    // Создаем панель для билета
                    Panel panel = new Panel();
                    panel.Width = width;
                    panel.Height = height;
                    panel.Location = new Point(x, y);
                    panel.BorderStyle = BorderStyle.FixedSingle;
                    panel.BackColor = Color.Thistle;

                    // От куда и куда
                    Label fromToLabel = new Label();
                    fromToLabel.Text = ticket.departure_airport + " -> " + ticket.arrival_airport;
                    fromToLabel.Width = 250;
                    fromToLabel.Location = new Point(5, 5);
                    panel.Controls.Add(fromToLabel);

                    // Когда
                    Label fromToDateLabel = new Label();
                    fromToDateLabel.Text = ticket.departure_date.ToString() + " -> " + ticket.arrival_date.ToString();
                    fromToDateLabel.Width = 250;
                    fromToDateLabel.Location = new Point(5, 30);
                    panel.Controls.Add(fromToDateLabel);

                    // Место в самолете
                    Label seatLabel = new Label();
                    seatLabel.Text = "Место: " + ticket.seat;
                    seatLabel.Location = new Point(260, 5);
                    panel.Controls.Add(seatLabel);

                    // Тариф
                    Label tariffLabel = new Label();
                    tariffLabel.Text = "Тариф: " + ticket.tariff;
                    tariffLabel.Width = 200;
                    tariffLabel.Location = new Point(260, 30);
                    panel.Controls.Add(tariffLabel);

                    // Стоимость
                    Label totalLabel = new Label();
                    totalLabel.Text = "Стоимость: " + ticket.total_cost.ToString() + " руб.";
                    totalLabel.Width = 200;
                    totalLabel.Location = new Point(260, 55);
                    panel.Controls.Add(totalLabel);

                    // Кнопка открыть
                    Button openButton = new Button();
                    openButton.Text = "Открыть";
                    openButton.Width = 75;
                    openButton.Height = 50;
                    openButton.BackColor = Color.AliceBlue;
                    openButton.Location = new Point(565, 11);
                    openButton.Name = $"open{index}";
                    openButton.Tag = ticket; // Передача билета в функцию обработки нажатия на открытие
                    openButton.Click += OpenButton_Click;
                    panel.Controls.Add(openButton);

                    // Добавляем на главную панель формы
                    ticketsPanel.Controls.Add(panel);
                    y += 95;
                }
            }
            else
            {
                Label emptyLabel = new Label();
                emptyLabel.Text = "Билетов не найдено!";
                emptyLabel.Width = 250;
                emptyLabel.BackColor = Color.Transparent;
                emptyLabel.Location = new Point(ticketsPanel.Width/3, ticketsPanel.Height/2);
                ticketsPanel.Controls.Add(emptyLabel);
            }
        }

        // Обработка нажатия на кнопку открыть
        private void OpenButton_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Ticket ticket = (Ticket)btn.Tag;
            OneTicketForm oneTicketForm = new OneTicketForm();
            oneTicketForm.OneTicket = ticket;
            oneTicketForm.ShowDialog();
        }
    }
}
