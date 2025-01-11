namespace Lab2
{
    partial class Компьютер
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
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
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.addProc = new System.Windows.Forms.Button();
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
            this.NameField.Size = new System.Drawing.Size(14, 20);
            this.NameField.TabIndex = 0;
            this.NameField.Text = "`";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(18, 52);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(256, 26);
            this.textBox1.TabIndex = 1;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Рабочая станция",
            "Ноутбук",
            "Сервер"});
            this.comboBox1.Location = new System.Drawing.Point(18, 144);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(256, 28);
            this.comboBox1.TabIndex = 2;
            // 
            // TypeLabel
            // 
            this.TypeLabel.AutoSize = true;
            this.TypeLabel.Location = new System.Drawing.Point(13, 103);
            this.TypeLabel.Name = "TypeLabel";
            this.TypeLabel.Size = new System.Drawing.Size(36, 20);
            this.TypeLabel.TabIndex = 3;
            this.TypeLabel.Text = "Тип";
            // 
            // DriveGroup
            // 
            this.DriveGroup.Controls.Add(this.SSD_Button);
            this.DriveGroup.Controls.Add(this.HDD_Button);
            this.DriveGroup.ForeColor = System.Drawing.SystemColors.WindowText;
            this.DriveGroup.Location = new System.Drawing.Point(19, 211);
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
            this.SSD_Button.Size = new System.Drawing.Size(68, 24);
            this.SSD_Button.TabIndex = 1;
            this.SSD_Button.TabStop = true;
            this.SSD_Button.Text = "SSD";
            this.SSD_Button.UseVisualStyleBackColor = true;
            // 
            // HDD_Button
            // 
            this.HDD_Button.AutoSize = true;
            this.HDD_Button.Location = new System.Drawing.Point(15, 30);
            this.HDD_Button.Name = "HDD_Button";
            this.HDD_Button.Size = new System.Drawing.Size(70, 24);
            this.HDD_Button.TabIndex = 0;
            this.HDD_Button.TabStop = true;
            this.HDD_Button.Text = "HDD";
            this.HDD_Button.UseVisualStyleBackColor = true;
            // 
            // DriveSizeTrack
            // 
            this.DriveSizeTrack.LargeChange = 50;
            this.DriveSizeTrack.Location = new System.Drawing.Point(18, 333);
            this.DriveSizeTrack.Maximum = 1024;
            this.DriveSizeTrack.Name = "DriveSizeTrack";
            this.DriveSizeTrack.Size = new System.Drawing.Size(369, 69);
            this.DriveSizeTrack.SmallChange = 10;
            this.DriveSizeTrack.TabIndex = 100;
            this.DriveSizeTrack.Scroll += new System.EventHandler(this.DriveSizeTrack_Scroll);
            // 
            // DriveSize
            // 
            this.DriveSize.AutoSize = true;
            this.DriveSize.Location = new System.Drawing.Point(17, 293);
            this.DriveSize.Name = "DriveSize";
            this.DriveSize.Size = new System.Drawing.Size(114, 20);
            this.DriveSize.TabIndex = 101;
            this.DriveSize.Text = "Размер диска";
            // 
            // DriveSizeValue
            // 
            this.DriveSizeValue.AutoSize = true;
            this.DriveSizeValue.Location = new System.Drawing.Point(17, 398);
            this.DriveSizeValue.Name = "DriveSizeValue";
            this.DriveSizeValue.Size = new System.Drawing.Size(91, 20);
            this.DriveSizeValue.TabIndex = 102;
            this.DriveSizeValue.Text = "Значение: ";
            // 
            // RamValue
            // 
            this.RamValue.AutoSize = true;
            this.RamValue.Location = new System.Drawing.Point(21, 636);
            this.RamValue.Name = "RamValue";
            this.RamValue.Size = new System.Drawing.Size(91, 20);
            this.RamValue.TabIndex = 106;
            this.RamValue.Text = "Значение: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 531);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(228, 20);
            this.label2.TabIndex = 105;
            this.label2.Text = "Размер оперативной памяти";
            // 
            // RamValueTrack
            // 
            this.RamValueTrack.LargeChange = 8;
            this.RamValueTrack.Location = new System.Drawing.Point(22, 571);
            this.RamValueTrack.Maximum = 64;
            this.RamValueTrack.Name = "RamValueTrack";
            this.RamValueTrack.Size = new System.Drawing.Size(240, 69);
            this.RamValueTrack.SmallChange = 2;
            this.RamValueTrack.TabIndex = 104;
            this.RamValueTrack.Scroll += new System.EventHandler(this.RamValueTrack_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 441);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(199, 20);
            this.label1.TabIndex = 108;
            this.label1.Text = "Тип оперативной памяти";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "DDR1",
            "DDR2",
            "DDR3",
            "DDR4",
            "DDR5"});
            this.comboBox2.Location = new System.Drawing.Point(18, 482);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(256, 28);
            this.comboBox2.TabIndex = 107;
            // 
            // addProc
            // 
            this.addProc.Location = new System.Drawing.Point(34, 677);
            this.addProc.Name = "addProc";
            this.addProc.Size = new System.Drawing.Size(195, 43);
            this.addProc.TabIndex = 109;
            this.addProc.Text = "Добавить процессор";
            this.addProc.UseVisualStyleBackColor = true;
            this.addProc.Click += new System.EventHandler(this.addProc_Click);
            // 
            // Компьютер
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(685, 809);
            this.Controls.Add(this.addProc);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.RamValue);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.RamValueTrack);
            this.Controls.Add(this.DriveSizeValue);
            this.Controls.Add(this.DriveSize);
            this.Controls.Add(this.DriveSizeTrack);
            this.Controls.Add(this.DriveGroup);
            this.Controls.Add(this.TypeLabel);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.NameField);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Компьютер";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Добавить устройство";
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
        private System.Windows.Forms.ComboBox comboBox1;
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
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Button addProc;
    }
}

