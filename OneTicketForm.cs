using QRCoder;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Forms;

namespace SkyTickets
{
    public partial class OneTicketForm : Form
    {
        public Ticket OneTicket { get; set; }

        Point firstNameLocation = new Point(670, 100);
        Point lastNameLocation = new Point(670, 120);
        Point patronymicLocation = new Point(670, 140);
        Point seatLocation = new Point(670, 160);
        Point tariffLocation = new Point(670, 180);
        Point totalCostLocation = new Point(670, 200);
        Point QRLocation = new Point(685, 275);
        Point departureAirportLocation = new Point(400, 100);
        Point arrivalAirportLocation = new Point(400, 280);
        Point departureDateLocation = new Point(400, 120);
        Point arrivalDateLocation = new Point(400, 300);

        Bitmap canvas;
        Graphics graph;
        System.Drawing.Image ticketBG = Properties.Resources.ticket;

        PrintDocument printDoc; // документ для печати

        public OneTicketForm()
        {
            printDoc = new PrintDocument();
            printDoc.PrintPage += PrintPageHandler;
            InitializeComponent();
        }

        private void OneTicketForm_Load(object sender, EventArgs e)
        {
            canvas = new Bitmap(ticketBox.Width, ticketBox.Height);
            ticketBox.Image = canvas;
            graph = Graphics.FromImage(canvas);

            graph.DrawImage(ticketBG, new Point(0,0));

            graph.DrawString(OneTicket.first_name, new Font("Consolas", 12), Brushes.Gray, firstNameLocation);
            graph.DrawString(OneTicket.last_name, new Font("Consolas", 12), Brushes.Gray, lastNameLocation);
            graph.DrawString(OneTicket.patronymic, new Font("Consolas", 12), Brushes.Gray, patronymicLocation);
            graph.DrawString("Место: " + OneTicket.seat, new Font("Consolas", 12), Brushes.Gray, seatLocation);
            graph.DrawString(OneTicket.tariff, new Font("Consolas", 12), Brushes.Gray, tariffLocation);
            graph.DrawString(OneTicket.total_cost.ToString() + " руб.", new Font("Consolas", 12), Brushes.Gray, totalCostLocation);
            graph.DrawString(OneTicket.departure_airport, new Font("Consolas", 12), Brushes.Gray, departureAirportLocation);
            graph.DrawString(OneTicket.arrival_airport, new Font("Consolas", 12), Brushes.Gray, arrivalAirportLocation);
            graph.DrawString(OneTicket.departure_date.ToString(), new Font("Consolas", 12), Brushes.Gray, departureDateLocation);
            graph.DrawString(OneTicket.arrival_date.ToString(), new Font("Consolas", 12), Brushes.Gray, arrivalDateLocation);

            Bitmap img = GenerateQR(OneTicket);
            graph.DrawImage(img, QRLocation.X, QRLocation.Y, 125, 125);

            ticketBox.Invalidate();

        }

        private void PrintPageHandler(object sender, PrintPageEventArgs e)
        {
            System.Drawing.Image img = ticketBox.Image;
            if (img == null) return;

            e.Graphics.DrawImage(img, 0, 0, img.Width, img.Height);
            e.HasMorePages = false;
        }

        private Bitmap GenerateQR(Ticket ticket)
        {

            string text = $"{ticket.ticket_id}/{ticket.seat}";

            // Сгенерировать QR
            var qrGen = new QRCodeGenerator();
            QRCodeData data = qrGen.CreateQrCode(text, QRCodeGenerator.ECCLevel.Q);

            // Получить Bitmap требуемого размера
            var qrCode = new BitmapByteQRCode(data);
            byte[] bmpBytes = qrCode.GetGraphic(20); // 20 px на модуль
            Bitmap qrBmp;
            using (var ms = new MemoryStream(bmpBytes))
                qrBmp = new Bitmap(ms);

            return qrBmp;
        }

        private void downloadButton_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Title = "Сохранить билет как PNG";
                sfd.Filter = "PNG-файл (*.png)|*.png";
                sfd.DefaultExt = "png";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Сохранение
                        ticketBox.Image.Save(sfd.FileName, ImageFormat.Png);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Не удалось сохранить билет:\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void printButton_Click(object sender, EventArgs e)
        {
            if (ticketBox.Image == null)
            {
                MessageBox.Show("Изображение отсутствует.");
                return;
            }

            printDialog.Document = printDoc;
            printDialog.AllowSomePages = false;
            printDialog.AllowPrintToFile = true;
            printDialog.ShowHelp = false;

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    printDoc.Print();   // печать на принтер ИЛИ в PDF
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка печати:\n" + ex.Message);
                }
            }
        }
    }
}
