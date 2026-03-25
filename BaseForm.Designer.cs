namespace SkyTickets
{
    partial class BaseForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.dateOfDeparture = new System.Windows.Forms.DateTimePicker();
            this.searchButton = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.popularDirectionsStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.flightsStatStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.printTicketsStripButton = new System.Windows.Forms.ToolStripButton();
            this.personalStripButton = new System.Windows.Forms.ToolStripButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.toComboBox = new System.Windows.Forms.ComboBox();
            this.fromComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.directionsDataGridView = new System.Windows.Forms.DataGridView();
            this.directionsContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.goToVoyagesForm = new System.Windows.Forms.ToolStripMenuItem();
            this.costsDataGridView = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.directionsDataGridView)).BeginInit();
            this.directionsContextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.costsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.dateOfDeparture);
            this.panel1.Controls.Add(this.searchButton);
            this.panel1.Controls.Add(this.toolStrip1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.toComboBox);
            this.panel1.Controls.Add(this.fromComboBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(788, 128);
            this.panel1.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(196, 92);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 16);
            this.label5.TabIndex = 7;
            this.label5.Text = "Дата вылета:";
            // 
            // dateOfDeparture
            // 
            this.dateOfDeparture.Location = new System.Drawing.Point(295, 87);
            this.dateOfDeparture.Name = "dateOfDeparture";
            this.dateOfDeparture.Size = new System.Drawing.Size(266, 22);
            this.dateOfDeparture.TabIndex = 6;
            // 
            // searchButton
            // 
            this.searchButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.searchButton.Location = new System.Drawing.Point(597, 50);
            this.searchButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(165, 47);
            this.searchButton.TabIndex = 5;
            this.searchButton.Text = "Найти";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.popularDirectionsStripButton,
            this.toolStripSeparator1,
            this.flightsStatStripButton,
            this.toolStripSeparator2,
            this.printTicketsStripButton,
            this.personalStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(786, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // popularDirectionsStripButton
            // 
            this.popularDirectionsStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.popularDirectionsStripButton.Image = ((System.Drawing.Image)(resources.GetObject("popularDirectionsStripButton.Image")));
            this.popularDirectionsStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.popularDirectionsStripButton.Name = "popularDirectionsStripButton";
            this.popularDirectionsStripButton.Size = new System.Drawing.Size(46, 22);
            this.popularDirectionsStripButton.Text = "Рейсы";
            this.popularDirectionsStripButton.Click += new System.EventHandler(this.popularDirectionsStripButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // flightsStatStripButton
            // 
            this.flightsStatStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.flightsStatStripButton.Image = ((System.Drawing.Image)(resources.GetObject("flightsStatStripButton.Image")));
            this.flightsStatStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.flightsStatStripButton.Name = "flightsStatStripButton";
            this.flightsStatStripButton.Size = new System.Drawing.Size(158, 22);
            this.flightsStatStripButton.Text = "Статистика ваших полетов";
            this.flightsStatStripButton.Click += new System.EventHandler(this.flightsStatStripButton_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // printTicketsStripButton
            // 
            this.printTicketsStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.printTicketsStripButton.Image = ((System.Drawing.Image)(resources.GetObject("printTicketsStripButton.Image")));
            this.printTicketsStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.printTicketsStripButton.Name = "printTicketsStripButton";
            this.printTicketsStripButton.Size = new System.Drawing.Size(98, 22);
            this.printTicketsStripButton.Text = "Печать билетов";
            this.printTicketsStripButton.Click += new System.EventHandler(this.printTicketsStripButton_Click);
            // 
            // personalStripButton
            // 
            this.personalStripButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.personalStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.personalStripButton.Image = ((System.Drawing.Image)(resources.GetObject("personalStripButton.Image")));
            this.personalStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.personalStripButton.Name = "personalStripButton";
            this.personalStripButton.Size = new System.Drawing.Size(103, 22);
            this.personalStripButton.Text = "Личный кабинет";
            this.personalStripButton.Click += new System.EventHandler(this.personalStripButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(291, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Куда";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "От куда";
            // 
            // toComboBox
            // 
            this.toComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.toComboBox.FormattingEnabled = true;
            this.toComboBox.Location = new System.Drawing.Point(294, 50);
            this.toComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.toComboBox.Name = "toComboBox";
            this.toComboBox.Size = new System.Drawing.Size(267, 32);
            this.toComboBox.TabIndex = 1;
            this.toComboBox.SelectedIndexChanged += new System.EventHandler(this.toComboBox_SelectedIndexChanged);
            // 
            // fromComboBox
            // 
            this.fromComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fromComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fromComboBox.FormattingEnabled = true;
            this.fromComboBox.Location = new System.Drawing.Point(21, 50);
            this.fromComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.fromComboBox.Name = "fromComboBox";
            this.fromComboBox.Size = new System.Drawing.Size(267, 32);
            this.fromComboBox.TabIndex = 0;
            this.fromComboBox.SelectedIndexChanged += new System.EventHandler(this.fromComboBox_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(73, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(200, 20);
            this.label4.TabIndex = 1;
            this.label4.Text = "Доступные направления:";
            // 
            // directionsDataGridView
            // 
            this.directionsDataGridView.AllowUserToAddRows = false;
            this.directionsDataGridView.AllowUserToDeleteRows = false;
            this.directionsDataGridView.AllowUserToResizeColumns = false;
            this.directionsDataGridView.AllowUserToResizeRows = false;
            this.directionsDataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.directionsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.directionsDataGridView.ContextMenuStrip = this.directionsContextMenu;
            this.directionsDataGridView.Location = new System.Drawing.Point(0, 159);
            this.directionsDataGridView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.directionsDataGridView.Name = "directionsDataGridView";
            this.directionsDataGridView.ReadOnly = true;
            this.directionsDataGridView.RowTemplate.Height = 24;
            this.directionsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.directionsDataGridView.Size = new System.Drawing.Size(348, 314);
            this.directionsDataGridView.TabIndex = 2;
            // 
            // directionsContextMenu
            // 
            this.directionsContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.goToVoyagesForm});
            this.directionsContextMenu.Name = "directionsContextMenu";
            this.directionsContextMenu.Size = new System.Drawing.Size(227, 26);
            // 
            // goToVoyagesForm
            // 
            this.goToVoyagesForm.Name = "goToVoyagesForm";
            this.goToVoyagesForm.Size = new System.Drawing.Size(226, 22);
            this.goToVoyagesForm.Text = "Просмотреть предложения";
            this.goToVoyagesForm.Click += new System.EventHandler(this.goToVoyagesForm_Click);
            // 
            // costsDataGridView
            // 
            this.costsDataGridView.AllowUserToAddRows = false;
            this.costsDataGridView.AllowUserToDeleteRows = false;
            this.costsDataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.costsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.costsDataGridView.Location = new System.Drawing.Point(438, 159);
            this.costsDataGridView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.costsDataGridView.Name = "costsDataGridView";
            this.costsDataGridView.ReadOnly = true;
            this.costsDataGridView.RowTemplate.Height = 24;
            this.costsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.costsDataGridView.Size = new System.Drawing.Size(348, 314);
            this.costsDataGridView.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(570, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Цены от:";
            // 
            // BaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(788, 473);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.costsDataGridView);
            this.Controls.Add(this.directionsDataGridView);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "BaseForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SkyTickets";
            this.Load += new System.EventHandler(this.BaseForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.directionsDataGridView)).EndInit();
            this.directionsContextMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.costsDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox toComboBox;
        private System.Windows.Forms.ComboBox fromComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView directionsDataGridView;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton popularDirectionsStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton flightsStatStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton printTicketsStripButton;
        private System.Windows.Forms.DataGridView costsDataGridView;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ContextMenuStrip directionsContextMenu;
        private System.Windows.Forms.ToolStripMenuItem goToVoyagesForm;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.ToolStripButton personalStripButton;
        private System.Windows.Forms.DateTimePicker dateOfDeparture;
        private System.Windows.Forms.Label label5;
    }
}