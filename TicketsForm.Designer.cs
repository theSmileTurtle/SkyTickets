namespace SkyTickets
{
    partial class TicketsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TicketsForm));
            this.ticketsPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // ticketsPanel
            // 
            this.ticketsPanel.AutoScroll = true;
            this.ticketsPanel.BackgroundImage = global::SkyTickets.Properties.Resources.clouds;
            this.ticketsPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ticketsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ticketsPanel.Location = new System.Drawing.Point(0, 0);
            this.ticketsPanel.Name = "ticketsPanel";
            this.ticketsPanel.Size = new System.Drawing.Size(684, 761);
            this.ticketsPanel.TabIndex = 0;
            // 
            // TicketsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(684, 761);
            this.Controls.Add(this.ticketsPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "TicketsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SkyTickets";
            this.Load += new System.EventHandler(this.TicketsForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel ticketsPanel;
    }
}