namespace Lab2
{
    partial class Form2
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
            this.addProc = new System.Windows.Forms.Button();
            this.RamValue = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.RamValueTrack = new System.Windows.Forms.TrackBar();
            this.DriveSizeValue = new System.Windows.Forms.Label();
            this.DriveSize = new System.Windows.Forms.Label();
            this.DriveSizeTrack = new System.Windows.Forms.TrackBar();
            this.ProducerGroup = new System.Windows.Forms.GroupBox();
            this.INTEL_Button = new System.Windows.Forms.RadioButton();
            this.AMD_Button = new System.Windows.Forms.RadioButton();
            this.TypeLabel = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.NameField = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.RamValueTrack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DriveSizeTrack)).BeginInit();
            this.ProducerGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // addProc
            // 
            this.addProc.Location = new System.Drawing.Point(290, 784);
            this.addProc.Name = "addProc";
            this.addProc.Size = new System.Drawing.Size(224, 43);
            this.addProc.TabIndex = 123;
            this.addProc.Text = "Добавить процессор";
            this.addProc.UseVisualStyleBackColor = true;
            this.addProc.Click += new System.EventHandler(this.addProc_Click);
            // 
            // RamValue
            // 
            this.RamValue.AutoSize = true;
            this.RamValue.Location = new System.Drawing.Point(63, 581);
            this.RamValue.Name = "RamValue";
            this.RamValue.Size = new System.Drawing.Size(91, 20);
            this.RamValue.TabIndex = 120;
            this.RamValue.Text = "Значение: ";
            this.RamValue.Click += new System.EventHandler(this.RamValue_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 429);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(228, 20);
            this.label2.TabIndex = 119;
            this.label2.Text = "Размер оперативной памяти";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // RamValueTrack
            // 
            this.RamValueTrack.LargeChange = 8;
            this.RamValueTrack.Location = new System.Drawing.Point(33, 493);
            this.RamValueTrack.Maximum = 64;
            this.RamValueTrack.Name = "RamValueTrack";
            this.RamValueTrack.Size = new System.Drawing.Size(269, 69);
            this.RamValueTrack.SmallChange = 2;
            this.RamValueTrack.TabIndex = 118;
            this.RamValueTrack.Scroll += new System.EventHandler(this.RamValueTrack_Scroll);
            // 
            // DriveSizeValue
            // 
            this.DriveSizeValue.AutoSize = true;
            this.DriveSizeValue.Location = new System.Drawing.Point(63, 374);
            this.DriveSizeValue.Name = "DriveSizeValue";
            this.DriveSizeValue.Size = new System.Drawing.Size(91, 20);
            this.DriveSizeValue.TabIndex = 117;
            this.DriveSizeValue.Text = "Значение: ";
            this.DriveSizeValue.Click += new System.EventHandler(this.DriveSizeValue_Click);
            // 
            // DriveSize
            // 
            this.DriveSize.AutoSize = true;
            this.DriveSize.Location = new System.Drawing.Point(40, 235);
            this.DriveSize.Name = "DriveSize";
            this.DriveSize.Size = new System.Drawing.Size(114, 20);
            this.DriveSize.TabIndex = 116;
            this.DriveSize.Text = "Размер диска";
            this.DriveSize.Click += new System.EventHandler(this.DriveSize_Click);
            // 
            // DriveSizeTrack
            // 
            this.DriveSizeTrack.LargeChange = 50;
            this.DriveSizeTrack.Location = new System.Drawing.Point(33, 302);
            this.DriveSizeTrack.Maximum = 1024;
            this.DriveSizeTrack.Name = "DriveSizeTrack";
            this.DriveSizeTrack.Size = new System.Drawing.Size(398, 69);
            this.DriveSizeTrack.SmallChange = 10;
            this.DriveSizeTrack.TabIndex = 115;
            this.DriveSizeTrack.Scroll += new System.EventHandler(this.DriveSizeTrack_Scroll);
            // 
            // ProducerGroup
            // 
            this.ProducerGroup.Controls.Add(this.INTEL_Button);
            this.ProducerGroup.Controls.Add(this.AMD_Button);
            this.ProducerGroup.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ProducerGroup.Location = new System.Drawing.Point(29, 12);
            this.ProducerGroup.Name = "ProducerGroup";
            this.ProducerGroup.Size = new System.Drawing.Size(284, 73);
            this.ProducerGroup.TabIndex = 114;
            this.ProducerGroup.TabStop = false;
            this.ProducerGroup.Text = "Производитель";
            this.ProducerGroup.Enter += new System.EventHandler(this.DriveGroup_Enter);
            // 
            // INTEL_Button
            // 
            this.INTEL_Button.AutoSize = true;
            this.INTEL_Button.Location = new System.Drawing.Point(142, 30);
            this.INTEL_Button.Name = "INTEL_Button";
            this.INTEL_Button.Size = new System.Drawing.Size(79, 24);
            this.INTEL_Button.TabIndex = 1;
            this.INTEL_Button.TabStop = true;
            this.INTEL_Button.Text = "INTEL";
            this.INTEL_Button.UseVisualStyleBackColor = true;
            // 
            // AMD_Button
            // 
            this.AMD_Button.AutoSize = true;
            this.AMD_Button.Location = new System.Drawing.Point(15, 30);
            this.AMD_Button.Name = "AMD_Button";
            this.AMD_Button.Size = new System.Drawing.Size(70, 24);
            this.AMD_Button.TabIndex = 0;
            this.AMD_Button.TabStop = true;
            this.AMD_Button.Text = "AMD";
            this.AMD_Button.UseVisualStyleBackColor = true;
            // 
            // TypeLabel
            // 
            this.TypeLabel.AutoSize = true;
            this.TypeLabel.Location = new System.Drawing.Point(563, 215);
            this.TypeLabel.Name = "TypeLabel";
            this.TypeLabel.Size = new System.Drawing.Size(36, 20);
            this.TypeLabel.TabIndex = 113;
            this.TypeLabel.Text = "Тип";
            this.TypeLabel.Click += new System.EventHandler(this.TypeLabel_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Рабочая станция",
            "Ноутбук",
            "Сервер"});
            this.comboBox1.Location = new System.Drawing.Point(503, 493);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(285, 28);
            this.comboBox1.TabIndex = 112;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(482, 397);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(285, 26);
            this.textBox1.TabIndex = 111;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // NameField
            // 
            this.NameField.AutoSize = true;
            this.NameField.Location = new System.Drawing.Point(40, 115);
            this.NameField.Name = "NameField";
            this.NameField.Size = new System.Drawing.Size(70, 20);
            this.NameField.TabIndex = 110;
            this.NameField.Text = "Модель";
            this.NameField.Click += new System.EventHandler(this.NameField_Click);
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
            this.comboBox2.Location = new System.Drawing.Point(33, 164);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(285, 28);
            this.comboBox2.TabIndex = 121;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 839);
            this.Controls.Add(this.addProc);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.RamValue);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.RamValueTrack);
            this.Controls.Add(this.DriveSizeValue);
            this.Controls.Add(this.DriveSize);
            this.Controls.Add(this.DriveSizeTrack);
            this.Controls.Add(this.ProducerGroup);
            this.Controls.Add(this.TypeLabel);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.NameField);
            this.Name = "Form2";
            this.Text = "Добавить процессор";
            ((System.ComponentModel.ISupportInitialize)(this.RamValueTrack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DriveSizeTrack)).EndInit();
            this.ProducerGroup.ResumeLayout(false);
            this.ProducerGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button addProc;
        private System.Windows.Forms.Label RamValue;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar RamValueTrack;
        private System.Windows.Forms.Label DriveSizeValue;
        private System.Windows.Forms.Label DriveSize;
        private System.Windows.Forms.TrackBar DriveSizeTrack;
        private System.Windows.Forms.GroupBox ProducerGroup;
        private System.Windows.Forms.RadioButton INTEL_Button;
        private System.Windows.Forms.RadioButton AMD_Button;
        private System.Windows.Forms.Label TypeLabel;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label NameField;
        private System.Windows.Forms.ComboBox comboBox2;
    }
}