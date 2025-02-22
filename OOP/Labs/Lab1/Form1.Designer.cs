namespace Lab1
{
    partial class Form1
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
            this.BitAND = new System.Windows.Forms.Button();
            this.BitOR = new System.Windows.Forms.Button();
            this.ButXOR = new System.Windows.Forms.Button();
            this.BitNOT = new System.Windows.Forms.Button();
            this.inputFirst = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.inputSecond = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ResultBox = new System.Windows.Forms.TextBox();
            this.ToBinButton = new System.Windows.Forms.RadioButton();
            this.ToOctButton = new System.Windows.Forms.RadioButton();
            this.ToDecButton = new System.Windows.Forms.RadioButton();
            this.ToHexButton = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // BitAND
            // 
            this.BitAND.Location = new System.Drawing.Point(602, 71);
            this.BitAND.Name = "BitAND";
            this.BitAND.Size = new System.Drawing.Size(198, 46);
            this.BitAND.TabIndex = 0;
            this.BitAND.Text = "Побитовое И";
            this.BitAND.UseVisualStyleBackColor = true;
            this.BitAND.Click += new System.EventHandler(this.BitAND_Click);
            // 
            // BitOR
            // 
            this.BitOR.Location = new System.Drawing.Point(602, 140);
            this.BitOR.Name = "BitOR";
            this.BitOR.Size = new System.Drawing.Size(198, 46);
            this.BitOR.TabIndex = 1;
            this.BitOR.Text = "Побитовое ИЛИ";
            this.BitOR.UseVisualStyleBackColor = true;
            this.BitOR.Click += new System.EventHandler(this.BitOR_Click);
            // 
            // ButXOR
            // 
            this.ButXOR.Location = new System.Drawing.Point(602, 208);
            this.ButXOR.Name = "ButXOR";
            this.ButXOR.Size = new System.Drawing.Size(198, 46);
            this.ButXOR.TabIndex = 2;
            this.ButXOR.Text = "Исключ. ИЛИ";
            this.ButXOR.UseVisualStyleBackColor = true;
            this.ButXOR.Click += new System.EventHandler(this.ButXOR_Click);
            // 
            // BitNOT
            // 
            this.BitNOT.Location = new System.Drawing.Point(602, 277);
            this.BitNOT.Name = "BitNOT";
            this.BitNOT.Size = new System.Drawing.Size(198, 46);
            this.BitNOT.TabIndex = 3;
            this.BitNOT.Text = "Инверсия";
            this.BitNOT.UseVisualStyleBackColor = true;
            this.BitNOT.Click += new System.EventHandler(this.BitNOT_Click);
            // 
            // inputFirst
            // 
            this.inputFirst.Location = new System.Drawing.Point(71, 86);
            this.inputFirst.Name = "inputFirst";
            this.inputFirst.Size = new System.Drawing.Size(348, 31);
            this.inputFirst.TabIndex = 4;
            this.inputFirst.TextChanged += new System.EventHandler(this.inputFirst_TextChanged);
            this.inputFirst.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.inputFirst_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(75, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "Число 1";
            // 
            // inputSecond
            // 
            this.inputSecond.Location = new System.Drawing.Point(71, 179);
            this.inputSecond.Name = "inputSecond";
            this.inputSecond.Size = new System.Drawing.Size(348, 31);
            this.inputSecond.TabIndex = 6;
            this.inputSecond.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.inputSecond_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(75, 151);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 25);
            this.label2.TabIndex = 7;
            this.label2.Text = "Число 2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(66, 239);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 25);
            this.label3.TabIndex = 9;
            this.label3.Text = "Результат";
            // 
            // ResultBox
            // 
            this.ResultBox.BackColor = System.Drawing.SystemColors.Control;
            this.ResultBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ResultBox.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.ResultBox.Enabled = false;
            this.ResultBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.ResultBox.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ResultBox.Location = new System.Drawing.Point(71, 279);
            this.ResultBox.Name = "ResultBox";
            this.ResultBox.Size = new System.Drawing.Size(489, 49);
            this.ResultBox.TabIndex = 8;
            // 
            // ToBinButton
            // 
            this.ToBinButton.AutoSize = true;
            this.ToBinButton.Location = new System.Drawing.Point(25, 391);
            this.ToBinButton.Name = "ToBinButton";
            this.ToBinButton.Size = new System.Drawing.Size(140, 29);
            this.ToBinButton.TabIndex = 10;
            this.ToBinButton.TabStop = true;
            this.ToBinButton.Text = "Двоичная";
            this.ToBinButton.UseVisualStyleBackColor = true;
            // 
            // ToOctButton
            // 
            this.ToOctButton.AutoSize = true;
            this.ToOctButton.Location = new System.Drawing.Point(185, 391);
            this.ToOctButton.Name = "ToOctButton";
            this.ToOctButton.Size = new System.Drawing.Size(177, 29);
            this.ToOctButton.TabIndex = 11;
            this.ToOctButton.TabStop = true;
            this.ToOctButton.Text = "Восмеричная";
            this.ToOctButton.UseVisualStyleBackColor = true;
            // 
            // ToDecButton
            // 
            this.ToDecButton.AutoSize = true;
            this.ToDecButton.Checked = true;
            this.ToDecButton.Location = new System.Drawing.Point(380, 391);
            this.ToDecButton.Name = "ToDecButton";
            this.ToDecButton.Size = new System.Drawing.Size(161, 29);
            this.ToDecButton.TabIndex = 12;
            this.ToDecButton.TabStop = true;
            this.ToDecButton.Text = "Десятичная";
            this.ToDecButton.UseVisualStyleBackColor = true;
            // 
            // ToHexButton
            // 
            this.ToHexButton.AutoSize = true;
            this.ToHexButton.Location = new System.Drawing.Point(565, 391);
            this.ToHexButton.Name = "ToHexButton";
            this.ToHexButton.Size = new System.Drawing.Size(246, 29);
            this.ToHexButton.TabIndex = 13;
            this.ToHexButton.TabStop = true;
            this.ToHexButton.Text = "Шестнадцатиричная";
            this.ToHexButton.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 450);
            this.Controls.Add(this.ToHexButton);
            this.Controls.Add(this.ToDecButton);
            this.Controls.Add(this.ToOctButton);
            this.Controls.Add(this.ToBinButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ResultBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.inputSecond);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.inputFirst);
            this.Controls.Add(this.BitNOT);
            this.Controls.Add(this.ButXOR);
            this.Controls.Add(this.BitOR);
            this.Controls.Add(this.BitAND);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BitAND;
        private System.Windows.Forms.Button BitOR;
        private System.Windows.Forms.Button ButXOR;
        private System.Windows.Forms.Button BitNOT;
        private System.Windows.Forms.TextBox inputFirst;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox inputSecond;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ResultBox;
        private System.Windows.Forms.RadioButton ToBinButton;
        private System.Windows.Forms.RadioButton ToOctButton;
        private System.Windows.Forms.RadioButton ToDecButton;
        private System.Windows.Forms.RadioButton ToHexButton;
    }
}

