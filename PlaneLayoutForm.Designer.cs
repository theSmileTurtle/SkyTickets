namespace SkyTickets
{
    partial class PlaneLayoutForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlaneLayoutForm));
            this.planePanel = new System.Windows.Forms.Panel();
            this.planeModelLabel = new System.Windows.Forms.Label();
            this.fromToLabel = new System.Windows.Forms.Label();
            this.dateTimeLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // planePanel
            // 
            this.planePanel.BackColor = System.Drawing.Color.OldLace;
            this.planePanel.Location = new System.Drawing.Point(305, 142);
            this.planePanel.Name = "planePanel";
            this.planePanel.Size = new System.Drawing.Size(1128, 317);
            this.planePanel.TabIndex = 0;
            // 
            // planeModelLabel
            // 
            this.planeModelLabel.AutoSize = true;
            this.planeModelLabel.BackColor = System.Drawing.Color.Transparent;
            this.planeModelLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.planeModelLabel.Location = new System.Drawing.Point(299, 30);
            this.planeModelLabel.Name = "planeModelLabel";
            this.planeModelLabel.Size = new System.Drawing.Size(111, 31);
            this.planeModelLabel.TabIndex = 1;
            this.planeModelLabel.Text = "Модель";
            // 
            // fromToLabel
            // 
            this.fromToLabel.AutoSize = true;
            this.fromToLabel.BackColor = System.Drawing.Color.Transparent;
            this.fromToLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fromToLabel.Location = new System.Drawing.Point(1013, 30);
            this.fromToLabel.Name = "fromToLabel";
            this.fromToLabel.Size = new System.Drawing.Size(208, 31);
            this.fromToLabel.TabIndex = 2;
            this.fromToLabel.Text = "Откуда -> Куда";
            // 
            // dateTimeLabel
            // 
            this.dateTimeLabel.AutoSize = true;
            this.dateTimeLabel.BackColor = System.Drawing.Color.Transparent;
            this.dateTimeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateTimeLabel.Location = new System.Drawing.Point(1013, 75);
            this.dateTimeLabel.Name = "dateTimeLabel";
            this.dateTimeLabel.Size = new System.Drawing.Size(352, 31);
            this.dateTimeLabel.TabIndex = 3;
            this.dateTimeLabel.Text = "Дата и время отправления";
            // 
            // PlaneLayoutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackgroundImage = global::SkyTickets.Properties.Resources.seatmap;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1659, 601);
            this.Controls.Add(this.dateTimeLabel);
            this.Controls.Add(this.fromToLabel);
            this.Controls.Add(this.planeModelLabel);
            this.Controls.Add(this.planePanel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "PlaneLayoutForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SkyTickets";
            this.Load += new System.EventHandler(this.PlaneLayoutForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel planePanel;
        private System.Windows.Forms.Label planeModelLabel;
        private System.Windows.Forms.Label fromToLabel;
        private System.Windows.Forms.Label dateTimeLabel;
    }
}