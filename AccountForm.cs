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
    public partial class AccountForm : Form
    {
        public AccountForm()
        {
            InitializeComponent();
        }

        private void AccountForm_Load(object sender, EventArgs e)
        {
            firstNameLabel.Text = DataModule.Passenger_First_Name;
            lastNameLabel.Text = DataModule.Passenger_Last_Name;
            patronymicLabel.Text=DataModule.Passenger_Patronymic;
            passportLabel.Text = DataModule.Passenger_Passport;
            phoneLabel.Text = DataModule.Passenger_Phone_Number;
            emailLabel.Text = DataModule.Passenger_Email;
        }

        private void flightsStatButton_Click(object sender, EventArgs e)
        {
            StatisticsForm statisticsForm = new StatisticsForm();
            statisticsForm.ShowDialog();
        }

        private void ticketsButton_Click(object sender, EventArgs e)
        {
            TicketsForm ticketsForm = new TicketsForm();
            ticketsForm.ShowDialog();
        }
    }
}
