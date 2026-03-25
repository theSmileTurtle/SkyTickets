namespace SkyTickets
{
    partial class VoyagesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VoyagesForm));
            this.buyButton = new System.Windows.Forms.Button();
            this.voyagesDataGridView = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dateOfDeparture = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.toComboBox = new System.Windows.Forms.ComboBox();
            this.fromComboBox = new System.Windows.Forms.ComboBox();
            this.agreeFillterBox = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.agreeDateBox = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.agreeSearchBox = new System.Windows.Forms.CheckBox();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.voyagesDataGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // buyButton
            // 
            this.buyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buyButton.Location = new System.Drawing.Point(409, 159);
            this.buyButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buyButton.Name = "buyButton";
            this.buyButton.Size = new System.Drawing.Size(145, 38);
            this.buyButton.TabIndex = 1;
            this.buyButton.Text = "Купить";
            this.buyButton.UseVisualStyleBackColor = true;
            this.buyButton.Click += new System.EventHandler(this.buyButton_Click);
            // 
            // voyagesDataGridView
            // 
            this.voyagesDataGridView.AllowUserToAddRows = false;
            this.voyagesDataGridView.AllowUserToDeleteRows = false;
            this.voyagesDataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.voyagesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.voyagesDataGridView.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.voyagesDataGridView.Location = new System.Drawing.Point(0, 237);
            this.voyagesDataGridView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.voyagesDataGridView.Name = "voyagesDataGridView";
            this.voyagesDataGridView.ReadOnly = true;
            this.voyagesDataGridView.RowTemplate.Height = 24;
            this.voyagesDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.voyagesDataGridView.Size = new System.Drawing.Size(564, 488);
            this.voyagesDataGridView.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(8, 211);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(176, 24);
            this.label2.TabIndex = 4;
            this.label2.Text = "Доступные рейсы:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 135);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Дата вылета:";
            // 
            // dateOfDeparture
            // 
            this.dateOfDeparture.Location = new System.Drawing.Point(86, 129);
            this.dateOfDeparture.Name = "dateOfDeparture";
            this.dateOfDeparture.Size = new System.Drawing.Size(168, 20);
            this.dateOfDeparture.TabIndex = 12;
            this.dateOfDeparture.ValueChanged += new System.EventHandler(this.dateOfDeparture_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Куда";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "От куда";
            // 
            // toComboBox
            // 
            this.toComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.toComboBox.FormattingEnabled = true;
            this.toComboBox.Location = new System.Drawing.Point(7, 92);
            this.toComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.toComboBox.Name = "toComboBox";
            this.toComboBox.Size = new System.Drawing.Size(247, 32);
            this.toComboBox.TabIndex = 9;
            this.toComboBox.SelectedIndexChanged += new System.EventHandler(this.toComboBox_SelectedIndexChanged);
            // 
            // fromComboBox
            // 
            this.fromComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fromComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fromComboBox.FormattingEnabled = true;
            this.fromComboBox.Location = new System.Drawing.Point(6, 39);
            this.fromComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.fromComboBox.Name = "fromComboBox";
            this.fromComboBox.Size = new System.Drawing.Size(247, 32);
            this.fromComboBox.TabIndex = 8;
            this.fromComboBox.SelectedIndexChanged += new System.EventHandler(this.fromComboBox_SelectedIndexChanged);
            // 
            // agreeFillterBox
            // 
            this.agreeFillterBox.AutoSize = true;
            this.agreeFillterBox.Location = new System.Drawing.Point(131, 155);
            this.agreeFillterBox.Name = "agreeFillterBox";
            this.agreeFillterBox.Size = new System.Drawing.Size(123, 17);
            this.agreeFillterBox.TabIndex = 14;
            this.agreeFillterBox.Text = "Применить фильтр";
            this.agreeFillterBox.UseVisualStyleBackColor = true;
            this.agreeFillterBox.CheckedChanged += new System.EventHandler(this.agreeFillterBox_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.agreeDateBox);
            this.groupBox1.Controls.Add(this.fromComboBox);
            this.groupBox1.Controls.Add(this.agreeFillterBox);
            this.groupBox1.Controls.Add(this.toComboBox);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.dateOfDeparture);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(268, 185);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Фильтр";
            // 
            // agreeDateBox
            // 
            this.agreeDateBox.AutoSize = true;
            this.agreeDateBox.Enabled = false;
            this.agreeDateBox.Location = new System.Drawing.Point(7, 155);
            this.agreeDateBox.Name = "agreeDateBox";
            this.agreeDateBox.Size = new System.Drawing.Size(108, 17);
            this.agreeDateBox.TabIndex = 15;
            this.agreeDateBox.Text = "Применить дату";
            this.agreeDateBox.UseVisualStyleBackColor = true;
            this.agreeDateBox.CheckedChanged += new System.EventHandler(this.agreeDateBox_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.agreeSearchBox);
            this.groupBox2.Controls.Add(this.searchTextBox);
            this.groupBox2.Location = new System.Drawing.Point(286, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(268, 105);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Поиск";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Введите запрос";
            // 
            // agreeSearchBox
            // 
            this.agreeSearchBox.AutoSize = true;
            this.agreeSearchBox.Location = new System.Drawing.Point(6, 69);
            this.agreeSearchBox.Name = "agreeSearchBox";
            this.agreeSearchBox.Size = new System.Drawing.Size(116, 17);
            this.agreeSearchBox.TabIndex = 15;
            this.agreeSearchBox.Text = "Применить поиск";
            this.agreeSearchBox.UseVisualStyleBackColor = true;
            this.agreeSearchBox.CheckedChanged += new System.EventHandler(this.agreeSearchBox_CheckedChanged);
            // 
            // searchTextBox
            // 
            this.searchTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.searchTextBox.Location = new System.Drawing.Point(6, 34);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(253, 29);
            this.searchTextBox.TabIndex = 0;
            this.searchTextBox.TextChanged += new System.EventHandler(this.searchTextBox_TextChanged);
            // 
            // VoyagesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(564, 725);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buyButton);
            this.Controls.Add(this.voyagesDataGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "VoyagesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SkyTickets";
            this.Load += new System.EventHandler(this.VoyagesForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.voyagesDataGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buyButton;
        private System.Windows.Forms.DataGridView voyagesDataGridView;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dateOfDeparture;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox toComboBox;
        private System.Windows.Forms.ComboBox fromComboBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.CheckBox agreeFillterBox;
        private System.Windows.Forms.CheckBox agreeSearchBox;
        public System.Windows.Forms.CheckBox agreeDateBox;
    }
}