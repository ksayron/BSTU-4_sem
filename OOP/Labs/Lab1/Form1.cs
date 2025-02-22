using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void BitAND_Click(object sender, EventArgs e)
        {
            int Number1 = Convert.ToInt32(inputFirst.Text);
            int Number2 = Convert.ToInt32(inputSecond.Text);
            Number1 = Number1 & Number2;
            if (ToBinButton.Checked)
            {
                string binary = Convert.ToString(Number1, 2);
                ResultBox.Text = binary;
            }
            if (ToOctButton.Checked)
            {
                string octal = Convert.ToString(Number1, 8);
                ResultBox.Text = octal;
            }
            if (ToDecButton.Checked)
            {
                ResultBox.Text = Number1.ToString();
            }
            if (ToHexButton.Checked)
            {
                string hex = Convert.ToString(Number1, 16);
                ResultBox.Text = hex;
            }
            
            
            
        }

        private void BitOR_Click(object sender, EventArgs e)
        {
            int Number1 = Convert.ToInt32(inputFirst.Text);
            int Number2 = Convert.ToInt32(inputSecond.Text);
            Number1 = Number1 | Number2;
            if (ToBinButton.Checked)
            {
                string binary = Convert.ToString(Number1, 2);
                ResultBox.Text = binary;
            }
            if (ToOctButton.Checked)
            {
                string octal = Convert.ToString(Number1, 8);
                ResultBox.Text = octal;
            }
            if (ToDecButton.Checked)
            {
                ResultBox.Text = Number1.ToString();
            }
            if (ToHexButton.Checked)
            {
                string hex = Convert.ToString(Number1, 16);
                ResultBox.Text = hex;
            }

        }


        private void inputFirst_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !(e.KeyChar == '-'))
            {
                e.Handled = true; 

                MessageBox.Show("Вводите только числа.", "Некорректный ввод", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void inputSecond_KeyPress(object sender, KeyPressEventArgs e)
        {
             if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !(e.KeyChar == '-'))
            {
                e.Handled = true; 

                MessageBox.Show("Вводите только числа.", "Некорректный ввод", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void ButXOR_Click(object sender, EventArgs e)
        {
            int Number1 = Convert.ToInt32(inputFirst.Text);
            int Number2 = Convert.ToInt32(inputSecond.Text);
            Number1 = Number1 ^ Number2;
            if (ToBinButton.Checked)
            {
                string binary = Convert.ToString(Number1, 2);
                ResultBox.Text = binary;
            }
            if (ToOctButton.Checked)
            {
                string octal = Convert.ToString(Number1, 8);
                ResultBox.Text = octal;
            }
            if (ToDecButton.Checked)
            {
                ResultBox.Text = Number1.ToString();
            }
            if (ToHexButton.Checked)
            {
                string hex = Convert.ToString(Number1, 16);
                ResultBox.Text = hex;
            }

        }

        private void BitNOT_Click(object sender, EventArgs e)
        {
            int Number1 = Convert.ToInt32(inputFirst.Text);
            Number1 = ~Number1;
            if (ToBinButton.Checked)
            {
                string binary = Convert.ToString(Number1, 2);
                ResultBox.Text = binary;
            }
            if (ToOctButton.Checked)
            {
                string octal = Convert.ToString(Number1, 8);
                ResultBox.Text = octal;
            }
            if (ToDecButton.Checked)
            {
                ResultBox.Text = Number1.ToString();
            }
            if (ToHexButton.Checked)
            {
                string hex = Convert.ToString(Number1, 16);
                ResultBox.Text = hex;
            }

        }

        private void inputFirst_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
