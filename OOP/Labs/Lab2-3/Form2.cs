using System;   
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2
{
    public partial class Form2 : Form
    {
        public Proccesor proccesor;  
        public Form2()
        {
            InitializeComponent();
            proccesor = new Proccesor(EProducer.none, EModel.none,ESeries.none,1,10,10,ECacheSize.none,EArchitecture.none);

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void RamValueTrack_Scroll(object sender, EventArgs e)
        {
           CoresValue.Text = String.Format("Значение: {0} Ядер", CoreValueTrack.Value);
        }

        private void RamValue_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

       

        private void DriveSizeValue_Click(object sender, EventArgs e)
        {

        }

        private void DriveSize_Click(object sender, EventArgs e)
        {

        }



        private void DriveGroup_Enter(object sender, EventArgs e)
        {

        }

        private void TypeLabel_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void NameField_Click(object sender, EventArgs e)
        {

        }

        private void AMD_Button_CheckedChanged(object sender, EventArgs e)
        {
            proccesor.Producer=EProducer.AMD;
        }

        private void INTEL_Button_CheckedChanged(object sender, EventArgs e)
        {
            proccesor.Producer = EProducer.Intel;
        }

        private void Model_textBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        

        private void Hz_trackBar_Scroll(object sender, EventArgs e)
        {
            if (MaxHz_trackBar.Value < Hz_trackBar.Value)
            {
                MaxHz_trackBar.Value = Hz_trackBar.Value;
            }
            Hz_value.Text = String.Format("Значение: {0} Hz", ((float)Hz_trackBar.Value)/10);
            proccesor.Hz = ((float)Hz_trackBar.Value) / 10;
        }

        private void MaxHz_trackBar_Scroll(object sender, EventArgs e)
        {
            if (MaxHz_trackBar.Value < Hz_trackBar.Value)
            {
                MaxHz_trackBar.Value= Hz_trackBar.Value;
            }
            MaxHz_value.Text = String.Format("Значение: {0} Hz", ((float)MaxHz_trackBar.Value) / 10);
            proccesor.MaxHz = ((float)MaxHz_trackBar.Value) / 10;
        }

        private void Model_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            switch (Model_comboBox.SelectedIndex)
            {
                case 0:
                    {
                        proccesor.Model = EModel.M3100;
                        break;
                    }
                case 1:
                    {
                        proccesor.Model = EModel.M3300;
                        break;
                    }
                case 2:
                    {
                        proccesor.Model = EModel.M5500;
                        break;
                    }
                case 3:
                    {
                        proccesor.Model = EModel.M5700;
                        break;
                    }
                case 4:
                    {
                        proccesor.Model = EModel.M5900;
                        break;
                    }
                default:
                    {
                        MessageBox.Show("Выберите модель процессора", "Некорректный ввод", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    }
            }
        }


        private void Series_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (Series_comboBox.SelectedIndex)
            {
                case 0:
                    {
                        proccesor.Series = ESeries.Pentium;
                        break;
                    }
                case 1:
                    {
                        proccesor.Series = ESeries.FX;
                        break;
                    }
                case 2:
                    {
                        proccesor.Series = ESeries.Core;
                        break;
                    }
                case 3:
                    {
                        proccesor.Series = ESeries.Ryzen;
                        break;
                    }
                default:
                    {
                        MessageBox.Show("Выберите серию процессора", "Некорректный ввод", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    }
            }
        }

        private void L1_RadioButtom_CheckedChanged(object sender, EventArgs e)
        {
            proccesor.CacheSize = ECacheSize.L1;
        }

        private void L2_RadioButtom_CheckedChanged(object sender, EventArgs e)
        {
            proccesor.CacheSize = ECacheSize.L2;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            proccesor.CacheSize = ECacheSize.L3;
        }

        private void x64_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            proccesor.Architecture = EArchitecture.x64;
        }

        private void x86_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            proccesor.Architecture = EArchitecture.x86;
        }

        private void addProc_Click(object sender, EventArgs e)
        {
            if (proccesor.Producer == EProducer.none)
            {
                MessageBox.Show("Выберите производителя процессора", "Некорректный ввод", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (proccesor.Model == EModel.none)
            {
                MessageBox.Show("Выберите модель процессора", "Некорректный ввод", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (proccesor.Series == ESeries.none)
            {
                MessageBox.Show("Выберите серию процессора", "Некорректный ввод", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (proccesor.CacheSize == ECacheSize.none)
            {
                MessageBox.Show("Выберите размерность кэша процессора", "Некорректный ввод", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (proccesor.Architecture == EArchitecture.none)
            {
                MessageBox.Show("Выберите архитектруру процессора", "Некорректный ввод", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            proccesor.DisplayProperties();
            this.Close();
        }
    }
}
