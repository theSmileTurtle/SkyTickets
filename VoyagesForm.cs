using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SkyTickets
{
    public partial class VoyagesForm : Form
    {
        public string To {  get; set; }
        public string From { get; set; }

        public VoyagesForm()
        {
            InitializeComponent();
        }

        private void VoyagesForm_Load(object sender, EventArgs e)
        {
            List<string> cities1 = DataModule.V_available_directions.GetColumnAsArray("Город");
            List<string> cities2 = DataModule.V_available_directions.GetColumnAsArray("Город");
            cities1.Insert(0, "");
            cities2.Insert(0, "");
            fromComboBox.DataSource = cities1;
            toComboBox.DataSource = cities2;

            if (To != string.Empty)
                toComboBox.Text = To;

            // Начальное отображение выборки рейсов
            agreeFillterBox_CheckedChanged(sender, e);
        }

        private void fromComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Запрещаем выбор двух одинаковых городов
            if (fromComboBox.Text == toComboBox.Text && fromComboBox.Text != "" && toComboBox.Text != "")
            {
                MessageBox.Show("Нельзя выбрать один город дважды!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                fromComboBox.SelectedIndex = 0;
            }

            // Обновляем выборку при смене города
            if (agreeFillterBox.Checked)
                agreeFillterBox_CheckedChanged(sender, e);
        }

        private void toComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Запрещаем выбор двух одинаковых городов
            if (fromComboBox.Text == toComboBox.Text && fromComboBox.Text != "" && toComboBox.Text != "")
            {
                MessageBox.Show("Нельзя выбрать один город дважды!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                toComboBox.SelectedIndex = 0;
            }

            // Обновляем выборку при смене города
            if (agreeFillterBox.Checked)
                agreeFillterBox_CheckedChanged(sender, e);
        }

        private void agreeFillterBox_CheckedChanged(object sender, EventArgs e)
        {
            agreeDateBox.Enabled = true;
            string sql, date;
            if (agreeFillterBox.Checked) 
            {
                DateTime when = dateOfDeparture.Value;
                if (agreeDateBox.Checked)
                    date = $" AND (`Время отбытия` >= '{when:yyyy-MM-dd 00:00:00}' AND `Время отбытия` < '{when:yyyy-MM-dd 23:59:59}')";
                else
                    date = "";

                // Если указано два города
                if (fromComboBox.Text != string.Empty && toComboBox.Text != string.Empty)
                {
                    sql = $"SELECT * FROM view_available_voyages " +
                        $"WHERE `Город отбытия`='{fromComboBox.Text}' AND `Город прибытия`='{toComboBox.Text}'" + date;
                }
                // Если указан город прибытия
                else if (fromComboBox.Text == string.Empty && toComboBox.Text != string.Empty)
                {
                    sql = $"SELECT * FROM view_available_voyages " +
                        $"WHERE `Город прибытия`='{toComboBox.Text}'" +date;
                }
                // Если указан город отбытия
                else if (fromComboBox.Text != string.Empty && toComboBox.Text == string.Empty)
                {
                    sql = $"SELECT * FROM view_available_voyages " +
                        $"WHERE `Город отбытия`='{fromComboBox.Text}'" + date;
                }
                // Если не указаны города
                else
                    sql = $"SELECT * FROM view_available_voyages";
            }
            else
            {
                fromComboBox.SelectedIndex = 0;
                toComboBox.SelectedIndex = 0;
                agreeDateBox.Checked = false;
                agreeDateBox.Enabled = false;
                sql = $"SELECT * FROM view_available_voyages";
            }

            // Выборка данных из представления
            MyDataView voyages = new MyDataView("available_voyages", sql);
            voyagesDataGridView.DataSource = voyages.View;
        }

        private void buyButton_Click(object sender, EventArgs e)
        {
            if(voyagesDataGridView.SelectedRows.Count == 1)
            {
                DataGridViewRow row = voyagesDataGridView.SelectedRows[0];
                string from = row.Cells[0].Value.ToString();
                string to = row.Cells[1].Value.ToString();
                string when = row.Cells[2].Value.ToString();
                string date = when.Split(' ')[0];
                string time = when.Split(' ')[1];

                when = "";
                foreach(var c in date.Split('.'))
                {
                    if(when!="")
                        when = c + $".{when}";
                    else
                        when = c + $"{when}";
                }
                when = when + $" {time}";

                PlaneLayoutForm planeLayoutForm = new PlaneLayoutForm();
                bool accept = false;

                // создаем запрос для нахождения конкретного рейса
                string sql = $"SELECT * FROM voyages " +
                    $"WHERE (departure_airport_id IN (SELECT airport_id FROM airports WHERE city = '{from}')) " +
                    $"AND (arrival_airport_id IN (SELECT airport_id FROM airports WHERE city = '{to}')) " +
                    $"AND (departure_date = '{when}')";

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
                if (accept)
                    planeLayoutForm.ShowDialog();
            }
        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            if (agreeSearchBox.Checked)
            {
                string pattern = searchTextBox.Text;
                string sql = $"SELECT * FROM view_available_voyages " +
                    $"WHERE `Город отбытия` LIKE '%{pattern}%' " +
                    $"OR `Город прибытия` LIKE '%{pattern}%' ";

                // Выборка данных из представления
                MyDataView voyages = new MyDataView("available_voyages", sql);
                voyagesDataGridView.DataSource = voyages.View;
            }
        }

        private void agreeDateBox_CheckedChanged(object sender, EventArgs e)
        {
            if (agreeFillterBox.Checked) 
            {
                agreeFillterBox_CheckedChanged(sender, e);
            }
        }

        private void dateOfDeparture_ValueChanged(object sender, EventArgs e)
        {
            if (agreeDateBox.Checked)
                agreeDateBox_CheckedChanged(sender, e);
        }

        private void agreeSearchBox_CheckedChanged(object sender, EventArgs e)
        {
            if (agreeSearchBox.Checked)
            {
                searchTextBox_TextChanged(sender, e);
            }
            else
            {
                MyDataView voyages = new MyDataView("available_voyages", $"SELECT * FROM view_available_voyages");
                voyagesDataGridView.DataSource = voyages.View;
            }
        }
    }
}
