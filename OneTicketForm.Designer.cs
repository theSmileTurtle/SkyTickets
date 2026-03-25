namespace SkyTickets
{
    partial class OneTicketForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OneTicketForm));
            this.ticketBox = new System.Windows.Forms.PictureBox();
            this.downloadButton = new System.Windows.Forms.Button();
            this.printButton = new System.Windows.Forms.Button();
            this.printDialog = new System.Windows.Forms.PrintDialog();
            ((System.ComponentModel.ISupportInitialize)(this.ticketBox)).BeginInit();
            this.SuspendLayout();
            // 
            // ticketBox
            // 
            this.ticketBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ticketBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ticketBox.Location = new System.Drawing.Point(12, 70);
            this.ticketBox.Name = "ticketBox";
            this.ticketBox.Size = new System.Drawing.Size(870, 412);
            this.ticketBox.TabIndex = 0;
            this.ticketBox.TabStop = false;
            // 
            // downloadButton
            // 
            this.downloadButton.Location = new System.Drawing.Point(12, 12);
            this.downloadButton.Name = "downloadButton";
            this.downloadButton.Size = new System.Drawing.Size(116, 44);
            this.downloadButton.TabIndex = 1;
            this.downloadButton.Text = "Скачать";
            this.downloadButton.UseVisualStyleBackColor = true;
            this.downloadButton.Click += new System.EventHandler(this.downloadButton_Click);
            // 
            // printButton
            // 
            this.printButton.Location = new System.Drawing.Point(134, 12);
            this.printButton.Name = "printButton";
            this.printButton.Size = new System.Drawing.Size(116, 44);
            this.printButton.TabIndex = 2;
            this.printButton.Text = "Распечатать";
            this.printButton.UseVisualStyleBackColor = true;
            this.printButton.Click += new System.EventHandler(this.printButton_Click);
            // 
            // printDialog
            // 
            this.printDialog.UseEXDialog = true;
            // 
            // OneTicketForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(895, 496);
            this.Controls.Add(this.printButton);
            this.Controls.Add(this.downloadButton);
            this.Controls.Add(this.ticketBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "OneTicketForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SkyTickets";
            this.Load += new System.EventHandler(this.OneTicketForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ticketBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox ticketBox;
        private System.Windows.Forms.Button downloadButton;
        private System.Windows.Forms.Button printButton;
        private System.Windows.Forms.PrintDialog printDialog;
    }
}