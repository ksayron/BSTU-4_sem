namespace Lab2
{
    partial class Computer_form
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.NameField = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Type_comboBox = new System.Windows.Forms.ComboBox();
            this.TypeLabel = new System.Windows.Forms.Label();
            this.DriveGroup = new System.Windows.Forms.GroupBox();
            this.SSD_Button = new System.Windows.Forms.RadioButton();
            this.HDD_Button = new System.Windows.Forms.RadioButton();
            this.DriveSizeTrack = new System.Windows.Forms.TrackBar();
            this.DriveSize = new System.Windows.Forms.Label();
            this.DriveSizeValue = new System.Windows.Forms.Label();
            this.RamValue = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.RamValueTrack = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.RamType_comboBox = new System.Windows.Forms.ComboBox();
            this.addProc = new System.Windows.Forms.Button();
            this.Proc_richTextBox = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.Calc_button = new System.Windows.Forms.Button();
            this.Price_label = new System.Windows.Forms.Label();
            this.SaveJSON_button = new System.Windows.Forms.Button();
            this.GetJSON_button = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.search_button = new System.Windows.Forms.Button();
            this.help_Button = new System.Windows.Forms.Button();
            this.DriveGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DriveSizeTrack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RamValueTrack)).BeginInit();
            this.SuspendLayout();
            // 
            // NameField
            // 
            this.NameField.AutoSize = true;
            this.NameField.Location = new System.Drawing.Point(13, 13);
            this.NameField.Name = "NameField";
            this.NameField.Size = new System.Drawing.Size(53, 25);
            this.NameField.TabIndex = 0;
            this.NameField.Text = "Имя";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(19, 41);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(256, 31);
            this.textBox1.TabIndex = 1;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // Type_comboBox
            // 
            this.Type_comboBox.FormattingEnabled = true;
            this.Type_comboBox.Items.AddRange(new object[] {
            "Рабочая станция",
            "Ноутбук",
            "Сервер"});
            this.Type_comboBox.Location = new System.Drawing.Point(17, 103);
            this.Type_comboBox.Name = "Type_comboBox";
            this.Type_comboBox.Size = new System.Drawing.Size(256, 33);
            this.Type_comboBox.TabIndex = 2;
            this.Type_comboBox.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // TypeLabel
            // 
            this.TypeLabel.AutoSize = true;
            this.TypeLabel.Location = new System.Drawing.Point(12, 75);
            this.TypeLabel.Name = "TypeLabel";
            this.TypeLabel.Size = new System.Drawing.Size(49, 25);
            this.TypeLabel.TabIndex = 3;
            this.TypeLabel.Text = "Тип";
            // 
            // DriveGroup
            // 
            this.DriveGroup.Controls.Add(this.SSD_Button);
            this.DriveGroup.Controls.Add(this.HDD_Button);
            this.DriveGroup.ForeColor = System.Drawing.SystemColors.WindowText;
            this.DriveGroup.Location = new System.Drawing.Point(17, 151);
            this.DriveGroup.Name = "DriveGroup";
            this.DriveGroup.Size = new System.Drawing.Size(255, 73);
            this.DriveGroup.TabIndex = 4;
            this.DriveGroup.TabStop = false;
            this.DriveGroup.Text = "Тип Диска";
            // 
            // SSD_Button
            // 
            this.SSD_Button.AutoSize = true;
            this.SSD_Button.Location = new System.Drawing.Point(142, 30);
            this.SSD_Button.Name = "SSD_Button";
            this.SSD_Button.Size = new System.Drawing.Size(86, 29);
            this.SSD_Button.TabIndex = 1;
            this.SSD_Button.TabStop = true;
            this.SSD_Button.Text = "SSD";
            this.SSD_Button.UseVisualStyleBackColor = true;
            this.SSD_Button.CheckedChanged += new System.EventHandler(this.SSD_Button_CheckedChanged);
            // 
            // HDD_Button
            // 
            this.HDD_Button.AutoSize = true;
            this.HDD_Button.Location = new System.Drawing.Point(15, 30);
            this.HDD_Button.Name = "HDD_Button";
            this.HDD_Button.Size = new System.Drawing.Size(88, 29);
            this.HDD_Button.TabIndex = 0;
            this.HDD_Button.TabStop = true;
            this.HDD_Button.Text = "HDD";
            this.HDD_Button.UseVisualStyleBackColor = true;
            this.HDD_Button.CheckedChanged += new System.EventHandler(this.HDD_Button_CheckedChanged);
            // 
            // DriveSizeTrack
            // 
            this.DriveSizeTrack.LargeChange = 50;
            this.DriveSizeTrack.Location = new System.Drawing.Point(13, 256);
            this.DriveSizeTrack.Maximum = 1024;
            this.DriveSizeTrack.Name = "DriveSizeTrack";
            this.DriveSizeTrack.Size = new System.Drawing.Size(369, 90);
            this.DriveSizeTrack.SmallChange = 10;
            this.DriveSizeTrack.TabIndex = 100;
            this.DriveSizeTrack.Scroll += new System.EventHandler(this.DriveSizeTrack_Scroll);
            // 
            // DriveSize
            // 
            this.DriveSize.AutoSize = true;
            this.DriveSize.Location = new System.Drawing.Point(17, 227);
            this.DriveSize.Name = "DriveSize";
            this.DriveSize.Size = new System.Drawing.Size(152, 25);
            this.DriveSize.TabIndex = 101;
            this.DriveSize.Text = "Размер диска";
            // 
            // DriveSizeValue
            // 
            this.DriveSizeValue.AutoSize = true;
            this.DriveSizeValue.Location = new System.Drawing.Point(27, 311);
            this.DriveSizeValue.Name = "DriveSizeValue";
            this.DriveSizeValue.Size = new System.Drawing.Size(120, 25);
            this.DriveSizeValue.TabIndex = 102;
            this.DriveSizeValue.Text = "Значение: ";
            // 
            // RamValue
            // 
            this.RamValue.AutoSize = true;
            this.RamValue.Location = new System.Drawing.Point(27, 521);
            this.RamValue.Name = "RamValue";
            this.RamValue.Size = new System.Drawing.Size(120, 25);
            this.RamValue.TabIndex = 106;
            this.RamValue.Text = "Значение: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 445);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(301, 25);
            this.label2.TabIndex = 105;
            this.label2.Text = "Размер оперативной памяти";
            // 
            // RamValueTrack
            // 
            this.RamValueTrack.LargeChange = 8;
            this.RamValueTrack.Location = new System.Drawing.Point(22, 473);
            this.RamValueTrack.Maximum = 64;
            this.RamValueTrack.Name = "RamValueTrack";
            this.RamValueTrack.Size = new System.Drawing.Size(240, 90);
            this.RamValueTrack.SmallChange = 2;
            this.RamValueTrack.TabIndex = 104;
            this.RamValueTrack.Scroll += new System.EventHandler(this.RamValueTrack_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 364);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(262, 25);
            this.label1.TabIndex = 108;
            this.label1.Text = "Тип оперативной памяти";
            // 
            // RamType_comboBox
            // 
            this.RamType_comboBox.FormattingEnabled = true;
            this.RamType_comboBox.Items.AddRange(new object[] {
            "DDR1",
            "DDR2",
            "DDR3",
            "DDR4",
            "DDR5"});
            this.RamType_comboBox.Location = new System.Drawing.Point(19, 392);
            this.RamType_comboBox.Name = "RamType_comboBox";
            this.RamType_comboBox.Size = new System.Drawing.Size(256, 33);
            this.RamType_comboBox.TabIndex = 107;
            this.RamType_comboBox.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // addProc
            // 
            this.addProc.Location = new System.Drawing.Point(280, 569);
            this.addProc.Name = "addProc";
            this.addProc.Size = new System.Drawing.Size(127, 66);
            this.addProc.TabIndex = 109;
            this.addProc.Text = "Добавить процессор";
            this.addProc.UseVisualStyleBackColor = true;
            this.addProc.Click += new System.EventHandler(this.addProc_Click);
            // 
            // Proc_richTextBox
            // 
            this.Proc_richTextBox.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.Proc_richTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Proc_richTextBox.Enabled = false;
            this.Proc_richTextBox.Location = new System.Drawing.Point(32, 569);
            this.Proc_richTextBox.Name = "Proc_richTextBox";
            this.Proc_richTextBox.Size = new System.Drawing.Size(221, 161);
            this.Proc_richTextBox.TabIndex = 110;
            this.Proc_richTextBox.Text = "Процессор:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 748);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(149, 25);
            this.label3.TabIndex = 112;
            this.label3.Text = "Дата покупки";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(26, 776);
            this.dateTimePicker1.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(265, 31);
            this.dateTimePicker1.TabIndex = 113;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // Calc_button
            // 
            this.Calc_button.Location = new System.Drawing.Point(26, 833);
            this.Calc_button.Name = "Calc_button";
            this.Calc_button.Size = new System.Drawing.Size(110, 23);
            this.Calc_button.TabIndex = 114;
            this.Calc_button.Text = "Посчитать стоимость";
            this.Calc_button.UseVisualStyleBackColor = true;
            this.Calc_button.Click += new System.EventHandler(this.Calc_button_Click);
            // 
            // Price_label
            // 
            this.Price_label.AutoSize = true;
            this.Price_label.Location = new System.Drawing.Point(142, 831);
            this.Price_label.Name = "Price_label";
            this.Price_label.Size = new System.Drawing.Size(132, 25);
            this.Price_label.TabIndex = 115;
            this.Price_label.Text = "Стоимость: ";
            // 
            // SaveJSON_button
            // 
            this.SaveJSON_button.Location = new System.Drawing.Point(611, 48);
            this.SaveJSON_button.Name = "SaveJSON_button";
            this.SaveJSON_button.Size = new System.Drawing.Size(497, 34);
            this.SaveJSON_button.TabIndex = 116;
            this.SaveJSON_button.Text = "Сохранить в XML";
            this.SaveJSON_button.UseVisualStyleBackColor = true;
            this.SaveJSON_button.Click += new System.EventHandler(this.SaveJSON_button_Click);
            // 
            // GetJSON_button
            // 
            this.GetJSON_button.Location = new System.Drawing.Point(611, 101);
            this.GetJSON_button.Name = "GetJSON_button";
            this.GetJSON_button.Size = new System.Drawing.Size(497, 34);
            this.GetJSON_button.TabIndex = 117;
            this.GetJSON_button.Text = "Извлечь из XML";
            this.GetJSON_button.UseVisualStyleBackColor = true;
            this.GetJSON_button.Click += new System.EventHandler(this.GetJSON_button_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(26, 874);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(381, 34);
            this.button1.TabIndex = 118;
            this.button1.Text = "Добавить компьютер";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.richTextBox1.Enabled = false;
            this.richTextBox1.Location = new System.Drawing.Point(611, 191);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(497, 629);
            this.richTextBox1.TabIndex = 119;
            this.richTextBox1.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(767, 839);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(132, 25);
            this.label4.TabIndex = 121;
            this.label4.Text = "Стоимость: ";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(611, 833);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(137, 37);
            this.button2.TabIndex = 120;
            this.button2.Text = "Посчитать стоимость";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // search_button
            // 
            this.search_button.Location = new System.Drawing.Point(611, 151);
            this.search_button.Name = "search_button";
            this.search_button.Size = new System.Drawing.Size(497, 34);
            this.search_button.TabIndex = 122;
            this.search_button.Text = "Поиск";
            this.search_button.UseVisualStyleBackColor = true;
            this.search_button.Click += new System.EventHandler(this.button3_Click);
            // 
            // help_Button
            // 
            this.help_Button.AutoSize = true;
            this.help_Button.Location = new System.Drawing.Point(1084, 874);
            this.help_Button.Name = "help_Button";
            this.help_Button.Size = new System.Drawing.Size(154, 35);
            this.help_Button.TabIndex = 123;
            this.help_Button.Text = "О программе";
            this.help_Button.UseVisualStyleBackColor = true;
            this.help_Button.Click += new System.EventHandler(this.help_Button_Click);
            // 
            // Computer_form
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1250, 1293);
            this.Controls.Add(this.help_Button);
            this.Controls.Add(this.search_button);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.GetJSON_button);
            this.Controls.Add(this.SaveJSON_button);
            this.Controls.Add(this.Price_label);
            this.Controls.Add(this.Calc_button);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Proc_richTextBox);
            this.Controls.Add(this.addProc);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.RamType_comboBox);
            this.Controls.Add(this.RamValue);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.RamValueTrack);
            this.Controls.Add(this.DriveSizeValue);
            this.Controls.Add(this.DriveSize);
            this.Controls.Add(this.DriveSizeTrack);
            this.Controls.Add(this.DriveGroup);
            this.Controls.Add(this.TypeLabel);
            this.Controls.Add(this.Type_comboBox);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.NameField);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.Name = "Computer_form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IT дамбалатория";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Computer_form_KeyDown);
            this.DriveGroup.ResumeLayout(false);
            this.DriveGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DriveSizeTrack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RamValueTrack)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label NameField;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox Type_comboBox;
        private System.Windows.Forms.Label TypeLabel;
        private System.Windows.Forms.GroupBox DriveGroup;
        private System.Windows.Forms.RadioButton SSD_Button;
        private System.Windows.Forms.RadioButton HDD_Button;
        private System.Windows.Forms.TrackBar DriveSizeTrack;
        private System.Windows.Forms.Label DriveSize;
        private System.Windows.Forms.Label DriveSizeValue;
        private System.Windows.Forms.Label RamValue;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar RamValueTrack;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox RamType_comboBox;
        private System.Windows.Forms.Button addProc;
        private System.Windows.Forms.RichTextBox Proc_richTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button Calc_button;
        private System.Windows.Forms.Label Price_label;
        private System.Windows.Forms.Button SaveJSON_button;
        private System.Windows.Forms.Button GetJSON_button;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button search_button;
        private System.Windows.Forms.Button help_Button;
    }
}

