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
using System.Windows.Forms.DataVisualization.Charting;

namespace SkyTickets
{
    public partial class StatisticsForm : Form
    {
        public StatisticsForm()
        {
            InitializeComponent();
        }

        private void StatisticsForm_Load(object sender, EventArgs e)
        {

            // Создаем области для построения
            var myFlightsArea = new ChartArea("MyFlightsArea");
            flightsChart.ChartAreas.Add(myFlightsArea);

            var popularFlightsArea = new ChartArea("PopularFlightsArea");
            flightsChart.ChartAreas.Add(popularFlightsArea);

            // Задаем расположение областей
            myFlightsArea.Position = new ElementPosition(0, 5, 90, 45);
            popularFlightsArea.Position = new ElementPosition(0, 50, 90, 50);

            // Создаем серию для столбчатой диаграммы
            var myFlights = new Series("MyFlights")
            {
                ChartType = SeriesChartType.Column, // столбцы
                IsValueShownAsLabel = true,       // показывать цифры на столбцах
                XValueType = ChartValueType.String,
                YValueType  = ChartValueType.Int32,
                Color = Color.Orange,
                ChartArea = "MyFlightsArea"
            };
            flightsChart.Series.Add(myFlights);

            // Делаем выборку из базы данных
            string sql = $@"
                SELECT a.city,
                       a.airport_code,
                       COUNT(*) AS cnt
                FROM tickets        t
                JOIN voyages        v ON v.voyage_id = t.voyage_id
                JOIN airports       a ON a.airport_id IN (v.arrival_airport_id)
                WHERE t.passenger_id = {DataModule.Passenger_Id} 
                GROUP BY a.city, a.airport_code
                ORDER BY cnt DESC;";

            var conn = DataModule.GetConnection();
            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            {
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read()) 
                    {
                        string cityCode = $"{reader.GetString("city")} ({reader.GetString("airport_code")})";
                        int flights = reader.GetInt32("cnt");
                        myFlights.Points.AddXY(cityCode, flights);
                    }
                }
            }

            flightsChart.ChartAreas["MyFlightsArea"].AxisX.MajorGrid.Enabled = false;
            flightsChart.ChartAreas["MyFlightsArea"].AxisY.MajorGrid.Enabled = false;
            flightsChart.ChartAreas["MyFlightsArea"].AxisX.MinorGrid.Enabled = false;
            flightsChart.ChartAreas["MyFlightsArea"].AxisY.MinorGrid.Enabled = false;

            flightsChart.ChartAreas["MyFlightsArea"].AxisX.Title = "Город (IATA)";
            flightsChart.ChartAreas["MyFlightsArea"].AxisY.Title = "Кол -во полётов";


            // Создаем серию для столбчатой диаграммы
            var popularFlights = new Series("PopularFlights")
            {
                ChartType = SeriesChartType.Column, // столбцы
                IsValueShownAsLabel = true,       // показывать цифры на столбцах
                XValueType = ChartValueType.String,
                YValueType = ChartValueType.Int32,
                Color = Color.Olive,
                ChartArea = "PopularFlightsArea"
            };
            flightsChart.Series.Add(popularFlights);

            // Делаем выборку из базы данных
            sql = $@"
                SELECT a.city,
                       a.airport_code,
                       COUNT(*) AS cnt
                FROM tickets        t
                JOIN voyages        v ON v.voyage_id = t.voyage_id
                JOIN airports       a ON a.airport_id IN (v.arrival_airport_id)
                GROUP BY a.city, a.airport_code
                ORDER BY cnt DESC;";

            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            {
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string cityCode = $"{reader.GetString("city")} ({reader.GetString("airport_code")})";
                        int flights = reader.GetInt32("cnt");
                        popularFlights.Points.AddXY(cityCode, flights);
                    }
                }
            }

            flightsChart.ChartAreas["PopularFlightsArea"].AxisX.MajorGrid.Enabled = false;
            flightsChart.ChartAreas["PopularFlightsArea"].AxisY.MajorGrid.Enabled = false;
            flightsChart.ChartAreas["PopularFlightsArea"].AxisX.MinorGrid.Enabled = false;
            flightsChart.ChartAreas["PopularFlightsArea"].AxisY.MinorGrid.Enabled = false;

            flightsChart.ChartAreas["PopularFlightsArea"].AxisX.Title = "Город (IATA)";
            flightsChart.ChartAreas["PopularFlightsArea"].AxisY.Title = "Кол-во полётов";
        }
    }
}
