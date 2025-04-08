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
using System.ComponentModel.DataAnnotations;

namespace Lab2
{
    public partial class Computer_form : Form
    {
        public Computer computer;
        public List<Computer> computers;
        public List<Computer> backup;
        bool ProcFormCall = false;
        public Computer_form()
        {
            InitializeComponent();
            computer = new Computer();
            computers = new List<Computer>();
            backup = new List<Computer>();
            dataGridView1.Columns.Add("Computer Name", "Computer Name");
            dataGridView1.Columns.Add("Computer Type", "Computer Type");
            dataGridView1.Columns.Add("CPU", "Процессор");
            dataGridView1.Columns.Add("Drives", "Диски");
            dataGridView1.Columns.Add("RAM", "Опер. память");
            dataGridView1.Columns.Add("Purchase Date", "Дата закупки");
            dataGridView1.Columns.Add("Price", "Цена");
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
            Logging.Text = "Добавлен процессор" + DateTime.Now;
            ProcFormCall = true;

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
            dataGridView1.Rows.Clear();
            bool conditions_met = true;
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
                        MessageBox.Show("Выберите тип устройства", "Некорректный ввод", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        conditions_met = false;
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
                        conditions_met = false;
                        break;
                    }
            }
            compik.ram.size = (uint)RamValueTrack.Value;
            compik.Proccesor = computer.Proccesor;
            if (HDD_Button.Checked)
            {
                compik.drives.type = EDriveType.HDD;
            }
            else if (SSD_Button.Checked)
            {
                compik.drives.type = EDriveType.SSD;
            }
            else
            {
                conditions_met=false;
                MessageBox.Show("Выберите тип жесткого диска", "Некорректный ввод", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            compik.drives.size = (uint)DriveSizeTrack.Value;
            if (!ProcFormCall)
            {
                conditions_met = false;
                MessageBox.Show("Добавтье процессор!", "Некорректный ввод", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            compik.date = dateTimePicker1.Value;
            if(conditions_met){
                var contex = new ValidationContext(compik, null, null);
                var results = new List<ValidationResult>();
                if (Validator.TryValidateObject(compik, contex, results, true))
                {
                    backup = new List<Computer>(computers);
                    MessageBox.Show("Компутер добавлен", "Добавили", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    computers.Add(compik);
                    foreach (var comp in computers)
                    {
                        richTextBox1.Text += $"{comp.Name} {comp.Type} {comp.Proccesor.Producer} {comp.Proccesor.Series} {comp.Proccesor.Model}  " + '\n';
                        dataGridView1.Rows.Add(
                        comp.Name,
                        comp.Type,
                        comp.Proccesor.Producer.ToString() + ' ' + comp.Proccesor.Series + ' ' + comp.Proccesor.Model,
                        comp.drives.type.ToString() + ' ' + comp.drives.size,
                        comp.ram.type.ToString() + ' ' + comp.ram.size,
                        comp.date,
                        comp.Price
                        );
                    }
                    ProcFormCall = false;
                }
                else
                {
                    foreach (var message in results)
                    {
                        MessageBox.Show(message.ErrorMessage, "Ой", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                Logging.Text = "Добавили компутер" + DateTime.Now;
            }
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
            Logging.Text = "Компутеры запокавали" + DateTime.Now;
        }

        private void GetJSON_button_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            try
            {
                XmlSerializer xml = new XmlSerializer(typeof(List<Computer>));
                using (FileStream fs = new FileStream("computers.xml", FileMode.OpenOrCreate))
                {
                    backup = new List<Computer>(computers); 
                    computers = xml.Deserialize(fs) as List<Computer>;
                    
                }
                foreach (var comp in computers)
                {
                    richTextBox1.Text += $"{comp.Name} {comp.Type} {comp.Proccesor.Producer} {comp.Proccesor.Series} {comp.Proccesor.Model} {comp.Price}$" + '\n';
                    dataGridView1.Rows.Add(
                        comp.Name,
                        comp.Type,
                        comp.Proccesor.Producer.ToString()+' '+comp.Proccesor.Series+ ' ' +comp.Proccesor.Model,
                        comp.drives.type.ToString()+' '+comp.drives.size,
                        comp.ram.type.ToString()+' '+comp.ram.size,
                        comp.date,
                        comp.Price
                        );
                }
                
                MessageBox.Show("Компутеры распокавали", "Добавили", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Ошибка при сериализации", "Ой", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            Logging.Text = "Распаковали компутеры" + DateTime.Now;
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
            Logging.Text = "Подсчет стоимости даvбалатории"+DateTime.Now;
        }

        private void Computer_form_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var searchForm = new SearchForm(computers);
            searchForm.computers = computers;
            searchForm.ShowDialog();
            Logging.Text = "Поиск" + DateTime.Now;
        }

        private void help_Button_Click(object sender, EventArgs e)
        {
            var form3 = new helpForm();
            form3.ShowDialog();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            var form3 = new helpForm();
            form3.ShowDialog();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            var searchForm = new SearchForm(computers);
            searchForm.computers = computers;
            searchForm.ShowDialog();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            dataGridView1.Rows.Clear();
            var temp = computers;
            computers = new List<Computer>(backup);
            backup = new List<Computer>(temp);
            foreach (var comp in computers)
            {
                richTextBox1.Text += $"{comp.Name} {comp.Type} {comp.Proccesor.Producer} {comp.Proccesor.Series} {comp.Proccesor.Model} {comp.Price}$" + '\n';
                dataGridView1.Rows.Add(
                    comp.Name,
                    comp.Type,
                    comp.Proccesor.Producer.ToString() + ' ' + comp.Proccesor.Series + ' ' + comp.Proccesor.Model,
                    comp.drives.type.ToString() + ' ' + comp.drives.size,
                    comp.ram.type.ToString() + ' ' + comp.ram.size,
                    comp.date,
                    comp.Price
                    );
            }
            Logging.Text = "Возврат действия" + DateTime.Now;
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            dataGridView1.Rows.Clear();
            var temp = computers;
            computers = new List<Computer>(backup);
            backup = new List<Computer>(temp);
            foreach (var comp in computers)
            {
                richTextBox1.Text += $"{comp.Name} {comp.Type} {comp.Proccesor.Producer} {comp.Proccesor.Series} {comp.Proccesor.Model} {comp.Price}$" + '\n';
                dataGridView1.Rows.Add(
                    comp.Name,
                    comp.Type,
                    comp.Proccesor.Producer.ToString() + ' ' + comp.Proccesor.Series + ' ' + comp.Proccesor.Model,
                    comp.drives.type.ToString() + ' ' + comp.drives.size,
                    comp.ram.type.ToString() + ' ' + comp.ram.size,
                    comp.date,
                    comp.Price
                    );
            }
            Logging.Text = "Отмена действия" + DateTime.Now;
        }

        private void LogLabel_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                computers[e.RowIndex].Proccesor.DisplayProperties();
            }
        }
    }
}
