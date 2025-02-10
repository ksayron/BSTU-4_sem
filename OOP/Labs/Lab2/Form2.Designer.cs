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
            this.CoresValue = new System.Windows.Forms.Label();
            this.CoresField = new System.Windows.Forms.Label();
            this.CoreValueTrack = new System.Windows.Forms.TrackBar();
            this.ProducerGroup = new System.Windows.Forms.GroupBox();
            this.INTEL_Button = new System.Windows.Forms.RadioButton();
            this.AMD_Button = new System.Windows.Forms.RadioButton();
            this.ModelField = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.Model_textBox = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SeriesField = new System.Windows.Forms.Label();
            this.CacheGroup = new System.Windows.Forms.GroupBox();
            this.L2_RadioButtom = new System.Windows.Forms.RadioButton();
            this.L1_RadioButtom = new System.Windows.Forms.RadioButton();
            this.L3_RadioButtom = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.CoreValueTrack)).BeginInit();
            this.ProducerGroup.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.CacheGroup.SuspendLayout();
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
            // CoresValue
            // 
            this.CoresValue.AutoSize = true;
            this.CoresValue.Location = new System.Drawing.Point(54, 562);
            this.CoresValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.CoresValue.Name = "CoresValue";
            this.CoresValue.Size = new System.Drawing.Size(120, 25);
            this.CoresValue.TabIndex = 120;
            this.CoresValue.Text = "Значение: ";
            this.CoresValue.Click += new System.EventHandler(this.RamValue_Click);
            // 
            // CoresField
            // 
            this.CoresField.AutoSize = true;
            this.CoresField.Location = new System.Drawing.Point(54, 403);
            this.CoresField.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.CoresField.Name = "CoresField";
            this.CoresField.Size = new System.Drawing.Size(133, 25);
            this.CoresField.TabIndex = 119;
            this.CoresField.Text = "Кол-во ядер";
            this.CoresField.Click += new System.EventHandler(this.label2_Click);
            // 
            // CoreValueTrack
            // 
            this.CoreValueTrack.LargeChange = 8;
            this.CoreValueTrack.Location = new System.Drawing.Point(58, 468);
            this.CoreValueTrack.Margin = new System.Windows.Forms.Padding(4);
            this.CoreValueTrack.Maximum = 12;
            this.CoreValueTrack.Minimum = 1;
            this.CoreValueTrack.Name = "CoreValueTrack";
            this.CoreValueTrack.Size = new System.Drawing.Size(359, 90);
            this.CoreValueTrack.SmallChange = 2;
            this.CoreValueTrack.TabIndex = 118;
            this.CoreValueTrack.Value = 1;
            this.CoreValueTrack.Scroll += new System.EventHandler(this.RamValueTrack_Scroll);
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
            // ModelField
            // 
            this.ModelField.AutoSize = true;
            this.ModelField.Location = new System.Drawing.Point(53, 144);
            this.ModelField.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ModelField.Name = "ModelField";
            this.ModelField.Size = new System.Drawing.Size(89, 25);
            this.ModelField.TabIndex = 110;
            this.ModelField.Text = "Модель";
            this.ModelField.Click += new System.EventHandler(this.NameField_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButton1);
            this.groupBox2.Controls.Add(this.radioButton2);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.groupBox2.Location = new System.Drawing.Point(59, 770);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(344, 91);
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
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(58, 332);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(345, 31);
            this.textBox1.TabIndex = 127;
            // 
            // SeriesField
            // 
            this.SeriesField.AutoSize = true;
            this.SeriesField.Location = new System.Drawing.Point(53, 280);
            this.SeriesField.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.SeriesField.Name = "SeriesField";
            this.SeriesField.Size = new System.Drawing.Size(74, 25);
            this.SeriesField.TabIndex = 126;
            this.SeriesField.Text = "Серия";
            // 
            // CacheGroup
            // 
            this.CacheGroup.Controls.Add(this.L3_RadioButtom);
            this.CacheGroup.Controls.Add(this.L2_RadioButtom);
            this.CacheGroup.Controls.Add(this.L1_RadioButtom);
            this.CacheGroup.ForeColor = System.Drawing.SystemColors.WindowText;
            this.CacheGroup.Location = new System.Drawing.Point(58, 635);
            this.CacheGroup.Margin = new System.Windows.Forms.Padding(4);
            this.CacheGroup.Name = "CacheGroup";
            this.CacheGroup.Padding = new System.Windows.Forms.Padding(4);
            this.CacheGroup.Size = new System.Drawing.Size(483, 91);
            this.CacheGroup.TabIndex = 128;
            this.CacheGroup.TabStop = false;
            this.CacheGroup.Text = "Размерность кэша";
            // 
            // L2_RadioButtom
            // 
            this.L2_RadioButtom.AutoSize = true;
            this.L2_RadioButtom.Location = new System.Drawing.Point(189, 38);
            this.L2_RadioButtom.Margin = new System.Windows.Forms.Padding(4);
            this.L2_RadioButtom.Name = "L2_RadioButtom";
            this.L2_RadioButtom.Size = new System.Drawing.Size(67, 29);
            this.L2_RadioButtom.TabIndex = 1;
            this.L2_RadioButtom.TabStop = true;
            this.L2_RadioButtom.Text = "L2";
            this.L2_RadioButtom.UseVisualStyleBackColor = true;
            // 
            // L1_RadioButtom
            // 
            this.L1_RadioButtom.AutoSize = true;
            this.L1_RadioButtom.Location = new System.Drawing.Point(20, 38);
            this.L1_RadioButtom.Margin = new System.Windows.Forms.Padding(4);
            this.L1_RadioButtom.Name = "L1_RadioButtom";
            this.L1_RadioButtom.Size = new System.Drawing.Size(67, 29);
            this.L1_RadioButtom.TabIndex = 0;
            this.L1_RadioButtom.TabStop = true;
            this.L1_RadioButtom.Text = "L1";
            this.L1_RadioButtom.UseVisualStyleBackColor = true;
            // 
            // L3_RadioButtom
            // 
            this.L3_RadioButtom.AutoSize = true;
            this.L3_RadioButtom.Location = new System.Drawing.Point(352, 38);
            this.L3_RadioButtom.Name = "L3_RadioButtom";
            this.L3_RadioButtom.Size = new System.Drawing.Size(67, 29);
            this.L3_RadioButtom.TabIndex = 2;
            this.L3_RadioButtom.TabStop = true;
            this.L3_RadioButtom.Text = "L3";
            this.L3_RadioButtom.UseVisualStyleBackColor = true;
            this.L3_RadioButtom.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 1092);
            this.Controls.Add(this.CacheGroup);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.SeriesField);
            this.Controls.Add(this.Model_textBox);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.addProc);
            this.Controls.Add(this.CoresValue);
            this.Controls.Add(this.CoresField);
            this.Controls.Add(this.CoreValueTrack);
            this.Controls.Add(this.ProducerGroup);
            this.Controls.Add(this.ModelField);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form2";
            this.Text = "Добавить процессор";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CoreValueTrack)).EndInit();
            this.ProducerGroup.ResumeLayout(false);
            this.ProducerGroup.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.CacheGroup.ResumeLayout(false);
            this.CacheGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button addProc;
        private System.Windows.Forms.Label CoresValue;
        private System.Windows.Forms.Label CoresField;
        private System.Windows.Forms.TrackBar CoreValueTrack;
        private System.Windows.Forms.GroupBox ProducerGroup;
        private System.Windows.Forms.RadioButton INTEL_Button;
        private System.Windows.Forms.RadioButton AMD_Button;
        private System.Windows.Forms.Label ModelField;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.TextBox Model_textBox;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label SeriesField;
        private System.Windows.Forms.GroupBox CacheGroup;
        private System.Windows.Forms.RadioButton L2_RadioButtom;
        private System.Windows.Forms.RadioButton L1_RadioButtom;
        private System.Windows.Forms.RadioButton L3_RadioButtom;
    }
}