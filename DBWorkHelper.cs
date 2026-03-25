using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SkyTickets
{
    internal static class DataModule
    {
        // Строка подключения 
        private static readonly string ConnectionString =
            "Server=localhost;Database=skytickets;Uid=root;Pwd=;Port=3306;Charset=utf8mb4;";

        // Данные текущего пользователя
        public static int Passenger_Id { get; set; } // Идентификатор
        public static String Passenger_First_Name { get; set; } // Фамилия
        public static String Passenger_Last_Name { get; set; } // Имя
        public static String Passenger_Patronymic { get; set; } // Отчество
        public static String Passenger_Passport { get; set; } // Серия номер паспорта
        public static String Passenger_Phone_Number { get; set; } // Номер телефона
        public static String Passenger_Email { get; set; } // Почта
        public static String Passenger_Password { get; set; } // Пароль

        private static MySqlConnection connection;

        #region Скорее всего нафиг не понадобится
        // Инициализация таблиц
        public static MyDataTable T_Passengers { get; private set; }
        public static MyDataTable T_Airlines { get; private set; }
        public static MyDataTable T_Airports { get; private set; }
        public static MyDataTable T_Planes { get; private set; }
        public static MyDataTable T_Seats { get; private set; }
        public static MyDataTable T_Tarrif { get; private set; }
        public static MyDataTable T_Tickets { get; private set; }
        public static MyDataTable T_Voyages { get; private set; }
        //public static MyDataTable T_seats_and_voyages_link { get; private set; }

        #endregion

        // Инициализация представлений
        public static MyDataView V_available_directions { get; private set; }
        public static MyDataView V_tariffs_costs { get; private set; }
        //public static MyDataView V_available_voyages { get; private set; }
        //public static MyDataView Q_Search_Voyages_By_To_From {  get; private set; }

        public static void OpenStaticConnection()
        {
            try
            {
                // Если соединение не создано
                if (connection == null)
                {
                    connection = new MySqlConnection(ConnectionString);
                }
                if (connection.State == System.Data.ConnectionState.Closed)
                {
                    connection.Open();

                    // Читаем таблицы из базы
                    T_Passengers = new MyDataTable("passengers");
                    T_Airlines = new MyDataTable("airlines");
                    T_Airports = new MyDataTable("airports");
                    T_Planes = new MyDataTable("planes");
                    T_Seats = new MyDataTable("seats");
                    T_Tarrif = new MyDataTable("tariffs");
                    T_Tickets = new MyDataTable("tickets");
                    T_Voyages = new MyDataTable("voyages");
                    //T_seats_and_voyages_link = new MyDataTable("seats_and_voyages_link");

                    // Читаем представления
                    V_available_directions = new MyDataView("view_available_directions", "SELECT * FROM view_available_directions");
                    V_tariffs_costs = new MyDataView("view_tariffs_costs", "SELECT * FROM view_tariffs_costs");

                    //Q_Search_Voyages_By_To_From = new MyDataView(, "SELECT * FROM view_tariffs_costs");
                }
            }
            catch
            {
                MessageBox.Show("Ошибка!", "Не удалось установить соединение с базой данных!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Возвращает активное соединение с БД
        public static MySqlConnection GetConnection()
        {
            return connection;
        }

        // Закрывает соединение
        public static void CloseConnection()
        {
            if (connection != null && connection.State != System.Data.ConnectionState.Closed)
                connection.Close();
        }
    }

    internal class MyDataTable
    {
        private string tableName;

        private MySqlConnection conn;
        private MySqlDataAdapter adapter;
        private MySqlCommandBuilder commandBuilder;

        private DataTable table;

        public string TableName { get { return tableName; } }
        public MySqlDataAdapter Adapter { get { return adapter; } }
        public MySqlCommandBuilder CommandBuilder { get { return commandBuilder; } }
        public DataTable Table { get { return table; } }
        public bool ReadOnly { get; set; } = false;

        public MyDataTable(string name)
        {
            try
            {
                tableName = name;
                conn = DataModule.GetConnection();
                string query = $"SELECT * FROM {tableName}";
                adapter = new MySqlDataAdapter(query, conn);
                commandBuilder = new MySqlCommandBuilder(adapter);

                table = new DataTable();
                adapter.Fill(table);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }

        public void Update()
        {
            adapter.Update(table);
        }
    }
    internal class MyDataView
    {
        private string viewName;

        private MySqlConnection conn;
        private MySqlDataAdapter adapter;
        //private MySqlCommandBuilder commandBuilder;

        private DataTable view;

        public string ViewName { get { return viewName; } }
        public MySqlDataAdapter Adapter { get { return adapter; } }
        //public MySqlCommandBuilder CommandBuilder { get { return commandBuilder; } }
        public DataTable View { get { return view; } }

        public MyDataView(string name, string query)
        {
            viewName = name;
            conn = DataModule.GetConnection();
            adapter = new MySqlDataAdapter(query, conn);

            view = new DataTable();
            adapter.Fill(view);
        }

        public List<string> GetColumnAsArray(string columnName)
        {
            List<string> column;
            string sql = $"SELECT {columnName} FROM {viewName}";
            using (MySqlDataAdapter adp = new MySqlDataAdapter(sql, conn))
            {
                DataTable dt = new DataTable();
                adp.Fill(dt);

                column = dt.AsEnumerable().Select(row => row.Field<string>(columnName)).ToList();
            }
            return column;
        }
    }

    internal class SeatRow
    {
        public List<int> A { get; set; }
        public List<int> B { get; set; }
        public List<int> C { get; set; }
    }

    internal class PlaneLayout
    {
        public SeatRow Cheap { get; set; }
        public SeatRow Business { get; set; }
        public SeatRow First { get; set; }
    }

    internal struct OrderedSeat
    {
        public int voyage_id;
        public int seat_id;
        public string seat_number;
        public int is_ordered;
    }

    public struct Ticket
    {
        public int ticket_id;
        public int passenger_id;
        public string first_name;
        public string last_name;
        public string patronymic;
        public string departure_airport;
        public string arrival_airport;
        public DateTime departure_date;
        public DateTime arrival_date;
        public string seat;
        public string tariff;
        public int total_cost;
    }
}
