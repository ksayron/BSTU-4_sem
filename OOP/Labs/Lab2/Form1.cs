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
using System.Text.Json;
using System.Xml.Serialization;
using System.IO;

namespace Lab2
{
    public partial class Computer_form : Form
    {
        public Computer computer;
        public List<Computer> computers;
        public Computer_form()
        {
            InitializeComponent();
            computer = new Computer();
            computers = new List<Computer>();
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

    

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if(dateTimePicker1.Value < DateTime.Today)
            {
                computer.date = dateTimePicker1.Value;
            }
            else
            {
                MessageBox.Show("Введите корректную дату", "Некорректный ввод", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void Calc_button_Click(object sender, EventArgs e)
        {
            computer.CalculatePrice();
            Price_label.Text += Math.Round(computer.Price,2)+" $" ;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";

            var compik = new Computer();
            compik.Name = textBox1.Text;
            compik.drives.size = (uint)DriveSizeTrack.Value;
            switch (Type_comboBox.SelectedIndex)
            {
                case 0:
                    {
                        compik.Type = EComType.PC;
                        break;
                    }
                case 1:
                    {
                        compik.Type = EComType.Laptop;
                        break;
                    }
                case 2:
                    {
                        compik.Type = EComType.Server;
                        break;
                    }
                default:
                    {
                        MessageBox.Show("Выберите тип жесткого диска", "Некорректный ввод", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    }
            }
            switch (RamType_comboBox.SelectedIndex)
            {
                case 0:
                    {
                        compik.ram.type = ERAMType.DDR1;
                        break;
                    }
                case 1:
                    {
                        compik.ram.type = ERAMType.DDR2;
                        break;
                    }
                case 2:
                    {
                        compik.ram.type = ERAMType.DDR3;
                        break;
                    }
                case 3:
                    {
                        compik.ram.type = ERAMType.DDR4;
                        break;
                    }
                case 4:
                    {
                        compik.ram.type = ERAMType.DDR5;
                        break;
                    }
                default:
                    {
                        MessageBox.Show("Выберите тип оперативной памяти", "Некорректный ввод", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    }
            }
            compik.Proccesor = computer.Proccesor;
            if (HDD_Button.Checked)
            {
                compik.drives.type = EDriveType.HDD;
            }
            else if (SSD_Button.Checked)
            {
                compik.drives.type = EDriveType.SSD;
            }
            compik.date = dateTimePicker1.Value;
            computers.Add(compik);
            foreach(var comp in computers)
            {
                richTextBox1.Text += $"{comp.Name} {comp.Type} {comp.Proccesor.Producer} {comp.Proccesor.Series} {comp.Proccesor.Model}  " + '\n';
            }
            MessageBox.Show("Компутер добавлен", "Добавили", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void SaveJSON_button_Click(object sender, EventArgs e)
        {
            try
            {
                XmlSerializer xml = new XmlSerializer(typeof(List<Computer>));
                using (StreamWriter writer = new StreamWriter("computers.xml"))
                {
                    xml.Serialize(writer, computers);
                }
                MessageBox.Show("Компутеры запокавали", "Добавили", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch{
                MessageBox.Show("Ошибка при сериализации", "Ой", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void GetJSON_button_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            try
            {
                XmlSerializer xml = new XmlSerializer(typeof(List<Computer>));
                using (FileStream fs = new FileStream("computers.xml", FileMode.OpenOrCreate))
                {
                    computers = xml.Deserialize(fs) as List<Computer>;
                    
                }
                foreach (var comp in computers)
                {
                    richTextBox1.Text += $"{comp.Name} {comp.Type} {comp.Proccesor.Producer} {comp.Proccesor.Series} {comp.Proccesor.Model}  " + '\n';
                }
                MessageBox.Show("Компутеры распокавали", "Добавили", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Ошибка при сериализации", "Ой", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double sum = 0.0;
            foreach(var computer in computers)
            {
                computer.CalculatePrice();
                sum += computer.Price;
            }
            label4.Text ="Стоимость:"+ Math.Round(sum, 2) + " $";
        }

        private void Computer_form_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var searchForm = new SearchForm(computers);
            searchForm.computers = computers;
            searchForm.ShowDialog();
        }

        private void help_Button_Click(object sender, EventArgs e)
        {
            var form3 = new helpForm();
            form3.ShowDialog();
        }
    }
}
