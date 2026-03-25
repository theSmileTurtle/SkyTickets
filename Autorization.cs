using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace SkyTickets
{
    public partial class Autorization : Form
    {
        public Autorization()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            try
            {
                string phone = phoneTextBox.Text;
                string password = passwordTextBox.Text;
                string checkPassword;

                var conn = DataModule.GetConnection();

                string sql = "SELECT * FROM passengers WHERE phone = " + phone;
                using (MySqlCommand command = new MySqlCommand(sql, conn))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        reader.Read();
                        checkPassword = reader.GetString("password");
                        if (checkPassword == password)
                        {
                            DataModule.Passenger_Id = reader.GetInt32("passenger_id"); // Опечатка в столбце базы
                            DataModule.Passenger_First_Name = reader.GetString("first_name");
                            DataModule.Passenger_Last_Name = reader.GetString("last_name");
                            DataModule.Passenger_Patronymic = reader.GetString("patronymic");
                            DataModule.Passenger_Passport = reader.GetString("passport_number");
                            DataModule.Passenger_Phone_Number = phone;
                            DataModule.Passenger_Email = reader.GetString("email");
                            DataModule.Passenger_Password = checkPassword;

                            this.Close();
                        }
                        else MessageBox.Show($"Пароль не верный!");
                    }
                }

                
            }
            catch
            {
                MessageBox.Show("Попробуйте зарегистрироваться!", "Номер телефона отсутствует в базе!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            try
            {
                string first_name = firstNameText.Text;
                string last_name = lastNameText.Text;
                string patronymic = patronymicText.Text;
                string serialNumber = serialNumberText.Text;
                string phone = phoneNumberText.Text;
                string email = emailText.Text;
                string password = passwordText.Text;

                var connection = DataModule.GetConnection();
                
                string sql = @"INSERT INTO passengers (first_name, last_name, patronymic, passport_number, phone, email, password) 
                                VALUES (@first_name, @last_name, @patronymic, @serialNumber, @phone, @email, @password); 
                                SELECT LAST_INSERT_ID();";

                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    
                    command.Parameters.AddWithValue("@first_name", first_name);
                    command.Parameters.AddWithValue("@last_name", last_name);
                    command.Parameters.AddWithValue("@patronymic", patronymic);
                    command.Parameters.AddWithValue("@serialNumber", serialNumber);
                    command.Parameters.AddWithValue("@phone", phone);
                    command.Parameters.AddWithValue("@email", email);
                    command.Parameters.AddWithValue("@password", password);

                    //command.ExecuteNonQuery();
                    DataModule.Passenger_Id = Convert.ToInt32(command.ExecuteScalar());
                }

                DataModule.Passenger_First_Name = first_name;
                DataModule.Passenger_Last_Name = last_name;
                DataModule.Passenger_Patronymic = patronymic;
                DataModule.Passenger_Passport = serialNumber;
                DataModule.Passenger_Phone_Number = phone;
                DataModule.Passenger_Email = email;
                DataModule.Passenger_Password = password;

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}\n\nДетали: {ex.ToString()}");
            }

        }
    }
}
