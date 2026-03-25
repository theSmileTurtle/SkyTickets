using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SkyTickets
{
    public partial class BaseForm : Form
    {
        public BaseForm()
        {
            InitializeComponent();
        }

        private void BaseForm_Load(object sender, EventArgs e)
        {
            directionsDataGridView.DataSource = DataModule.V_available_directions.View;
            costsDataGridView.DataSource = DataModule.V_tariffs_costs.View;

            List<string> cities1 = DataModule.V_available_directions.GetColumnAsArray("Город");
            List<string> cities2 = DataModule.V_available_directions.GetColumnAsArray("Город");
            cities1.Insert(0, "");
            cities2.Insert(0, "");
            fromComboBox.DataSource = cities1;
            toComboBox.DataSource = cities2;
        }

        // Защита от выбора одинаковых городов
        private void fromComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(fromComboBox.Text==toComboBox.Text && fromComboBox.Text != ""&& toComboBox.Text != "")
            {
                MessageBox.Show("Нельзя выбрать один город дважды!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                fromComboBox.SelectedIndex = 0;
            }
        }

        // Защита от выбора одинаковых городов
        private void toComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (fromComboBox.Text == toComboBox.Text && fromComboBox.Text != "" && toComboBox.Text != "")
            {
                MessageBox.Show("Нельзя выбрать один город дважды!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                toComboBox.SelectedIndex = 0;
            }
        }

        // Обработка нажатия на кнопку поиска конкретного рейса
        private void searchButton_Click(object sender, EventArgs e)
        {
            PlaneLayoutForm planeLayoutForm = new PlaneLayoutForm();
            bool accept = false;

            string from = fromComboBox.Text;
            string to = toComboBox.Text;
            DateTime when = dateOfDeparture.Value;

            // создаем запрос для нахождения конкретного рейса
            string sql = $"SELECT * FROM voyages " +
                $"WHERE (departure_airport_id IN (SELECT airport_id FROM airports WHERE city = '{from}')) " +
                $"AND (arrival_airport_id IN (SELECT airport_id FROM airports WHERE city = '{to}')) " +
                $"AND (departure_date >= '{when:yyyy-MM-dd 00:00:00}' AND departure_date < '{when:yyyy-MM-dd 23:59:59}')";

            var conn = DataModule.GetConnection();
            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            {
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    try
                    {
                        reader.Read();
                        planeLayoutForm.vId = reader.GetInt32("voyage_id");
                        planeLayoutForm.pId = reader.GetInt32("plane_id");
                        accept = true;

                    }
                    catch
                    {
                        MessageBox.Show("Такого рейса не существует!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        accept = false;
                    }
                }
            }

            // открываем форму выбора места
            if(accept)
                planeLayoutForm.ShowDialog();
        }

        // Открыть личный кабинет
        private void personalStripButton_Click(object sender, EventArgs e)
        {
            AccountForm accountForm = new AccountForm();
            accountForm.ShowDialog();
        }

        // Открыть форму со всеми рейсами
        private void popularDirectionsStripButton_Click(object sender, EventArgs e)
        {
            VoyagesForm voyagesForm = new VoyagesForm();
            voyagesForm.ShowDialog();
        }

        // Открыть форму со всеми рейсами, но применить к ней фильтр
        private void goToVoyagesForm_Click(object sender, EventArgs e)
        {
            string to;
            if (directionsDataGridView.SelectedRows.Count == 1)
            {
                DataGridViewRow row = directionsDataGridView.SelectedRows[0];
                to = row.Cells[1].Value.ToString(); // получение города из выделенной строки

                VoyagesForm voyagesForm = new VoyagesForm();
                voyagesForm.To = to; // передача города в форму
                voyagesForm.agreeFillterBox.Checked = true;
                voyagesForm.ShowDialog();
            }
        }

        // Открыть форму со статистикой полетов
        private void flightsStatStripButton_Click(object sender, EventArgs e)
        {
            StatisticsForm statisticsForm = new StatisticsForm();
            statisticsForm.ShowDialog();
        }

        private void printTicketsStripButton_Click(object sender, EventArgs e)
        {
            TicketsForm ticketsForm = new TicketsForm();
            ticketsForm.ShowDialog();
        }
    }
}
