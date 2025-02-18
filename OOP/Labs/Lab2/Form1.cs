using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2
{
    public partial class Computer_form : Form
    {
        public Computer computer;
        public Computer_form()
        {
            InitializeComponent();
            computer = new Computer();
        }

        private void DriveSizeTrack_Scroll(object sender, EventArgs e)
        {
            DriveSizeValue.Text = String.Format("Значение: {0} GB", DriveSizeTrack.Value);
            computer.drives.size = (uint)DriveSizeTrack.Value;
        }

        private void RamValueTrack_Scroll(object sender, EventArgs e)
        {
            RamValue.Text = String.Format("Значение: {0} GB", RamValueTrack.Value);
            computer.ram.size = (uint)RamValueTrack.Value;
        }

        private void addProc_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();

            computer.Proccesor = form2.proccesor;
            Proc_richTextBox.Text = "Процессор: \n"+computer.Proccesor.Stats();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            computer.Name = textBox1.Text;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (Type_comboBox.SelectedIndex)
            {
                case 0:
                    {
                        computer.Type = EComType.PC;
                        break;
                    }
                case 1:
                    {
                        computer.Type = EComType.Laptop;
                        break;
                    }
                case 2:
                    {
                        computer.Type = EComType.Server;
                        break;
                    }
                default:
                    {
                        MessageBox.Show("Выберите тип жесткого диска", "Некорректный ввод", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    }
            }
        }

        private void HDD_Button_CheckedChanged(object sender, EventArgs e)
        {
            computer.drives.type = EDriveType.HDD;
        }

        private void SSD_Button_CheckedChanged(object sender, EventArgs e)
        {
            computer.drives.type = EDriveType.SSD;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (RamType_comboBox.SelectedIndex)
            {
                case 0:
                    {
                        computer.ram.type = ERAMType.DDR1;
                        break;
                    }
                case 1:
                    {
                        computer.ram.type = ERAMType.DDR2;
                        break;
                    }
                case 2:
                    {
                        computer.ram.type = ERAMType.DDR3;
                        break;
                    }
                case 3:
                    {
                        computer.ram.type = ERAMType.DDR4;
                        break;
                    }
                case 4:
                    {
                        computer.ram.type = ERAMType.DDR5;
                        break;
                    }
                default:
                    {
                        MessageBox.Show("Выберите тип оперативной памяти", "Некорректный ввод", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    }
            }
        }
    }
}
