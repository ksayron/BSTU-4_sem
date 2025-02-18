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
            this.x86_radioButton = new System.Windows.Forms.RadioButton();
            this.x64_radioButton = new System.Windows.Forms.RadioButton();
            this.SeriesField = new System.Windows.Forms.Label();
            this.CacheGroup = new System.Windows.Forms.GroupBox();
            this.L3_RadioButtom = new System.Windows.Forms.RadioButton();
            this.L2_RadioButtom = new System.Windows.Forms.RadioButton();
            this.L1_RadioButtom = new System.Windows.Forms.RadioButton();
            this.Hz_value = new System.Windows.Forms.Label();
            this.Hz_label = new System.Windows.Forms.Label();
            this.Hz_trackBar = new System.Windows.Forms.TrackBar();
            this.MaxHz_value = new System.Windows.Forms.Label();
            this.MaxHZ_label = new System.Windows.Forms.Label();
            this.MaxHz_trackBar = new System.Windows.Forms.TrackBar();
            this.Model_comboBox = new System.Windows.Forms.ComboBox();
            this.Series_comboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.CoreValueTrack)).BeginInit();
            this.ProducerGroup.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.CacheGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Hz_trackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxHz_trackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // addProc
            // 
            this.addProc.Location = new System.Drawing.Point(179, 952);
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
            this.CoresValue.Location = new System.Drawing.Point(53, 376);
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
            this.CoresField.Location = new System.Drawing.Point(54, 297);
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
            this.CoreValueTrack.Location = new System.Drawing.Point(58, 326);
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
            this.ModelField.Location = new System.Drawing.Point(53, 110);
            this.ModelField.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ModelField.Name = "ModelField";
            this.ModelField.Size = new System.Drawing.Size(89, 25);
            this.ModelField.TabIndex = 110;
            this.ModelField.Text = "Модель";
            this.ModelField.Click += new System.EventHandler(this.NameField_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.x86_radioButton);
            this.groupBox2.Controls.Add(this.x64_radioButton);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.groupBox2.Location = new System.Drawing.Point(59, 523);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(344, 91);
            this.groupBox2.TabIndex = 124;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Архитектура";
            // 
            // x86_radioButton
            // 
            this.x86_radioButton.AutoSize = true;
            this.x86_radioButton.Location = new System.Drawing.Point(189, 38);
            this.x86_radioButton.Margin = new System.Windows.Forms.Padding(4);
            this.x86_radioButton.Name = "x86_radioButton";
            this.x86_radioButton.Size = new System.Drawing.Size(78, 29);
            this.x86_radioButton.TabIndex = 1;
            this.x86_radioButton.TabStop = true;
            this.x86_radioButton.Text = "x86";
            this.x86_radioButton.UseVisualStyleBackColor = true;
            this.x86_radioButton.CheckedChanged += new System.EventHandler(this.x86_radioButton_CheckedChanged);
            // 
            // x64_radioButton
            // 
            this.x64_radioButton.AutoSize = true;
            this.x64_radioButton.Location = new System.Drawing.Point(20, 38);
            this.x64_radioButton.Margin = new System.Windows.Forms.Padding(4);
            this.x64_radioButton.Name = "x64_radioButton";
            this.x64_radioButton.Size = new System.Drawing.Size(78, 29);
            this.x64_radioButton.TabIndex = 0;
            this.x64_radioButton.TabStop = true;
            this.x64_radioButton.Text = "x64";
            this.x64_radioButton.UseVisualStyleBackColor = true;
            this.x64_radioButton.CheckedChanged += new System.EventHandler(this.x64_radioButton_CheckedChanged);
            // 
            // SeriesField
            // 
            this.SeriesField.AutoSize = true;
            this.SeriesField.Location = new System.Drawing.Point(54, 202);
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
            this.CacheGroup.Location = new System.Drawing.Point(59, 424);
            this.CacheGroup.Margin = new System.Windows.Forms.Padding(4);
            this.CacheGroup.Name = "CacheGroup";
            this.CacheGroup.Padding = new System.Windows.Forms.Padding(4);
            this.CacheGroup.Size = new System.Drawing.Size(483, 91);
            this.CacheGroup.TabIndex = 128;
            this.CacheGroup.TabStop = false;
            this.CacheGroup.Text = "Размерность кэша";
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
            this.L2_RadioButtom.CheckedChanged += new System.EventHandler(this.L2_RadioButtom_CheckedChanged);
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
            this.L1_RadioButtom.CheckedChanged += new System.EventHandler(this.L1_RadioButtom_CheckedChanged);
            // 
            // Hz_value
            // 
            this.Hz_value.AutoSize = true;
            this.Hz_value.Location = new System.Drawing.Point(52, 738);
            this.Hz_value.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Hz_value.Name = "Hz_value";
            this.Hz_value.Size = new System.Drawing.Size(182, 25);
            this.Hz_value.TabIndex = 133;
            this.Hz_value.Text = "Значение: 1.0 Hz";
            // 
            // Hz_label
            // 
            this.Hz_label.AutoSize = true;
            this.Hz_label.Location = new System.Drawing.Point(56, 628);
            this.Hz_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Hz_label.Name = "Hz_label";
            this.Hz_label.Size = new System.Drawing.Size(93, 25);
            this.Hz_label.TabIndex = 132;
            this.Hz_label.Text = "Частота";
            // 
            // Hz_trackBar
            // 
            this.Hz_trackBar.LargeChange = 20;
            this.Hz_trackBar.Location = new System.Drawing.Point(57, 673);
            this.Hz_trackBar.Margin = new System.Windows.Forms.Padding(4);
            this.Hz_trackBar.Maximum = 120;
            this.Hz_trackBar.Minimum = 10;
            this.Hz_trackBar.Name = "Hz_trackBar";
            this.Hz_trackBar.Size = new System.Drawing.Size(359, 90);
            this.Hz_trackBar.TabIndex = 50;
            this.Hz_trackBar.Value = 10;
            this.Hz_trackBar.Scroll += new System.EventHandler(this.Hz_trackBar_Scroll);
            // 
            // MaxHz_value
            // 
            this.MaxHz_value.AutoSize = true;
            this.MaxHz_value.Location = new System.Drawing.Point(55, 901);
            this.MaxHz_value.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.MaxHz_value.Name = "MaxHz_value";
            this.MaxHz_value.Size = new System.Drawing.Size(182, 25);
            this.MaxHz_value.TabIndex = 136;
            this.MaxHz_value.Text = "Значение: 1.0 Hz";
            // 
            // MaxHZ_label
            // 
            this.MaxHZ_label.AutoSize = true;
            this.MaxHZ_label.Location = new System.Drawing.Point(59, 791);
            this.MaxHZ_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.MaxHZ_label.Name = "MaxHZ_label";
            this.MaxHZ_label.Size = new System.Drawing.Size(154, 25);
            this.MaxHZ_label.TabIndex = 135;
            this.MaxHZ_label.Text = "Макс. частота";
            // 
            // MaxHz_trackBar
            // 
            this.MaxHz_trackBar.LargeChange = 20;
            this.MaxHz_trackBar.Location = new System.Drawing.Point(60, 836);
            this.MaxHz_trackBar.Margin = new System.Windows.Forms.Padding(4);
            this.MaxHz_trackBar.Maximum = 120;
            this.MaxHz_trackBar.Minimum = 10;
            this.MaxHz_trackBar.Name = "MaxHz_trackBar";
            this.MaxHz_trackBar.Size = new System.Drawing.Size(359, 90);
            this.MaxHz_trackBar.TabIndex = 50;
            this.MaxHz_trackBar.Value = 10;
            this.MaxHz_trackBar.Scroll += new System.EventHandler(this.MaxHz_trackBar_Scroll);
            // 
            // Model_comboBox
            // 
            this.Model_comboBox.FormattingEnabled = true;
            this.Model_comboBox.Items.AddRange(new object[] {
            "3100",
            "3300",
            "5500",
            "5700",
            "5900"});
            this.Model_comboBox.Location = new System.Drawing.Point(61, 149);
            this.Model_comboBox.Name = "Model_comboBox";
            this.Model_comboBox.Size = new System.Drawing.Size(358, 33);
            this.Model_comboBox.TabIndex = 137;
            this.Model_comboBox.SelectedIndexChanged += new System.EventHandler(this.Model_comboBox_SelectedIndexChanged);
            // 
            // Series_comboBox
            // 
            this.Series_comboBox.FormattingEnabled = true;
            this.Series_comboBox.Items.AddRange(new object[] {
            "Pentium",
            "FX",
            "Core",
            "Ryzen"});
            this.Series_comboBox.Location = new System.Drawing.Point(59, 243);
            this.Series_comboBox.Name = "Series_comboBox";
            this.Series_comboBox.Size = new System.Drawing.Size(360, 33);
            this.Series_comboBox.TabIndex = 138;
            this.Series_comboBox.SelectedIndexChanged += new System.EventHandler(this.Series_comboBox_SelectedIndexChanged);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(692, 1037);
            this.Controls.Add(this.Series_comboBox);
            this.Controls.Add(this.Model_comboBox);
            this.Controls.Add(this.MaxHz_value);
            this.Controls.Add(this.MaxHZ_label);
            this.Controls.Add(this.MaxHz_trackBar);
            this.Controls.Add(this.Hz_value);
            this.Controls.Add(this.Hz_label);
            this.Controls.Add(this.Hz_trackBar);
            this.Controls.Add(this.CacheGroup);
            this.Controls.Add(this.SeriesField);
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
            ((System.ComponentModel.ISupportInitialize)(this.Hz_trackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxHz_trackBar)).EndInit();
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
        private System.Windows.Forms.RadioButton x86_radioButton;
        private System.Windows.Forms.RadioButton x64_radioButton;
        private System.Windows.Forms.Label SeriesField;
        private System.Windows.Forms.GroupBox CacheGroup;
        private System.Windows.Forms.RadioButton L2_RadioButtom;
        private System.Windows.Forms.RadioButton L1_RadioButtom;
        private System.Windows.Forms.RadioButton L3_RadioButtom;
        private System.Windows.Forms.Label Hz_value;
        private System.Windows.Forms.Label Hz_label;
        private System.Windows.Forms.TrackBar Hz_trackBar;
        private System.Windows.Forms.Label MaxHz_value;
        private System.Windows.Forms.Label MaxHZ_label;
        private System.Windows.Forms.TrackBar MaxHz_trackBar;
        private System.Windows.Forms.ComboBox Model_comboBox;
        private System.Windows.Forms.ComboBox Series_comboBox;
    }
}