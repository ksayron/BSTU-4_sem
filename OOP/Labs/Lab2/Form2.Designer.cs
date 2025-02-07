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
            this.NameField = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.Model_textBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.RamValueTrack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DriveSizeTrack)).BeginInit();
            this.ProducerGroup.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // addProc
            // 
            this.addProc.Location = new System.Drawing.Point(209, 1024);
            this.addProc.Margin = new System.Windows.Forms.Padding(4);
            this.addProc.Name = "addProc";
            this.addProc.Size = new System.Drawing.Size(299, 54);
            this.addProc.TabIndex = 123;
            this.addProc.Text = "Добавить процессор";
            this.addProc.UseVisualStyleBackColor = true;
            this.addProc.Click += new System.EventHandler(this.addProc_Click);
            // 
            // RamValue
            // 
            this.RamValue.AutoSize = true;
            this.RamValue.Location = new System.Drawing.Point(84, 726);
            this.RamValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.RamValue.Name = "RamValue";
            this.RamValue.Size = new System.Drawing.Size(120, 25);
            this.RamValue.TabIndex = 120;
            this.RamValue.Text = "Значение: ";
            this.RamValue.Click += new System.EventHandler(this.RamValue_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(53, 536);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(301, 25);
            this.label2.TabIndex = 119;
            this.label2.Text = "Размер оперативной памяти";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // RamValueTrack
            // 
            this.RamValueTrack.LargeChange = 8;
            this.RamValueTrack.Location = new System.Drawing.Point(44, 616);
            this.RamValueTrack.Margin = new System.Windows.Forms.Padding(4);
            this.RamValueTrack.Maximum = 64;
            this.RamValueTrack.Name = "RamValueTrack";
            this.RamValueTrack.Size = new System.Drawing.Size(359, 90);
            this.RamValueTrack.SmallChange = 2;
            this.RamValueTrack.TabIndex = 118;
            this.RamValueTrack.Scroll += new System.EventHandler(this.RamValueTrack_Scroll);
            // 
            // DriveSizeValue
            // 
            this.DriveSizeValue.AutoSize = true;
            this.DriveSizeValue.Location = new System.Drawing.Point(84, 468);
            this.DriveSizeValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.DriveSizeValue.Name = "DriveSizeValue";
            this.DriveSizeValue.Size = new System.Drawing.Size(120, 25);
            this.DriveSizeValue.TabIndex = 117;
            this.DriveSizeValue.Text = "Значение: ";
            this.DriveSizeValue.Click += new System.EventHandler(this.DriveSizeValue_Click);
            // 
            // DriveSize
            // 
            this.DriveSize.AutoSize = true;
            this.DriveSize.Location = new System.Drawing.Point(53, 294);
            this.DriveSize.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.DriveSize.Name = "DriveSize";
            this.DriveSize.Size = new System.Drawing.Size(152, 25);
            this.DriveSize.TabIndex = 116;
            this.DriveSize.Text = "Размер диска";
            this.DriveSize.Click += new System.EventHandler(this.DriveSize_Click);
            // 
            // DriveSizeTrack
            // 
            this.DriveSizeTrack.LargeChange = 50;
            this.DriveSizeTrack.Location = new System.Drawing.Point(44, 378);
            this.DriveSizeTrack.Margin = new System.Windows.Forms.Padding(4);
            this.DriveSizeTrack.Maximum = 1024;
            this.DriveSizeTrack.Name = "DriveSizeTrack";
            this.DriveSizeTrack.Size = new System.Drawing.Size(531, 90);
            this.DriveSizeTrack.SmallChange = 10;
            this.DriveSizeTrack.TabIndex = 115;
            this.DriveSizeTrack.Scroll += new System.EventHandler(this.DriveSizeTrack_Scroll);
            // 
            // ProducerGroup
            // 
            this.ProducerGroup.Controls.Add(this.INTEL_Button);
            this.ProducerGroup.Controls.Add(this.AMD_Button);
            this.ProducerGroup.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ProducerGroup.Location = new System.Drawing.Point(39, 15);
            this.ProducerGroup.Margin = new System.Windows.Forms.Padding(4);
            this.ProducerGroup.Name = "ProducerGroup";
            this.ProducerGroup.Padding = new System.Windows.Forms.Padding(4);
            this.ProducerGroup.Size = new System.Drawing.Size(379, 91);
            this.ProducerGroup.TabIndex = 114;
            this.ProducerGroup.TabStop = false;
            this.ProducerGroup.Text = "Производитель";
            this.ProducerGroup.Enter += new System.EventHandler(this.DriveGroup_Enter);
            // 
            // INTEL_Button
            // 
            this.INTEL_Button.AutoSize = true;
            this.INTEL_Button.Location = new System.Drawing.Point(189, 38);
            this.INTEL_Button.Margin = new System.Windows.Forms.Padding(4);
            this.INTEL_Button.Name = "INTEL_Button";
            this.INTEL_Button.Size = new System.Drawing.Size(102, 29);
            this.INTEL_Button.TabIndex = 1;
            this.INTEL_Button.TabStop = true;
            this.INTEL_Button.Text = "INTEL";
            this.INTEL_Button.UseVisualStyleBackColor = true;
            this.INTEL_Button.CheckedChanged += new System.EventHandler(this.INTEL_Button_CheckedChanged);
            // 
            // AMD_Button
            // 
            this.AMD_Button.AutoSize = true;
            this.AMD_Button.Location = new System.Drawing.Point(20, 38);
            this.AMD_Button.Margin = new System.Windows.Forms.Padding(4);
            this.AMD_Button.Name = "AMD_Button";
            this.AMD_Button.Size = new System.Drawing.Size(90, 29);
            this.AMD_Button.TabIndex = 0;
            this.AMD_Button.TabStop = true;
            this.AMD_Button.Text = "AMD";
            this.AMD_Button.UseVisualStyleBackColor = true;
            this.AMD_Button.CheckedChanged += new System.EventHandler(this.AMD_Button_CheckedChanged);
            // 
            // NameField
            // 
            this.NameField.AutoSize = true;
            this.NameField.Location = new System.Drawing.Point(53, 144);
            this.NameField.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.NameField.Name = "NameField";
            this.NameField.Size = new System.Drawing.Size(89, 25);
            this.NameField.TabIndex = 110;
            this.NameField.Text = "Модель";
            this.NameField.Click += new System.EventHandler(this.NameField_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButton1);
            this.groupBox2.Controls.Add(this.radioButton2);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.groupBox2.Location = new System.Drawing.Point(59, 819);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(379, 91);
            this.groupBox2.TabIndex = 124;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Архитектура";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(189, 38);
            this.radioButton1.Margin = new System.Windows.Forms.Padding(4);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(78, 29);
            this.radioButton1.TabIndex = 1;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "x86";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(20, 38);
            this.radioButton2.Margin = new System.Windows.Forms.Padding(4);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(78, 29);
            this.radioButton2.TabIndex = 0;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "x64";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // Model_textBox
            // 
            this.Model_textBox.Location = new System.Drawing.Point(58, 196);
            this.Model_textBox.Name = "Model_textBox";
            this.Model_textBox.Size = new System.Drawing.Size(345, 31);
            this.Model_textBox.TabIndex = 125;
            this.Model_textBox.TextChanged += new System.EventHandler(this.Model_textBox_TextChanged);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 1092);
            this.Controls.Add(this.Model_textBox);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.addProc);
            this.Controls.Add(this.RamValue);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.RamValueTrack);
            this.Controls.Add(this.DriveSizeValue);
            this.Controls.Add(this.DriveSize);
            this.Controls.Add(this.DriveSizeTrack);
            this.Controls.Add(this.ProducerGroup);
            this.Controls.Add(this.NameField);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form2";
            this.Text = "Добавить процессор";
            ((System.ComponentModel.ISupportInitialize)(this.RamValueTrack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DriveSizeTrack)).EndInit();
            this.ProducerGroup.ResumeLayout(false);
            this.ProducerGroup.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
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
        private System.Windows.Forms.Label NameField;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.TextBox Model_textBox;
    }
}