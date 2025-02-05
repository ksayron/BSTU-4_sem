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
        private Proccesor proccesor;  
        public Form2()
        {
            InitializeComponent();
            proccesor = new Proccesor("undefined",1,1.0,1.0,ECacheSize.L1,EArchitecture.x86);

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void RamValueTrack_Scroll(object sender, EventArgs e)
        {

        }

        private void RamValue_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void addProc_Click(object sender, EventArgs e)
        {

        }

        private void DriveSizeValue_Click(object sender, EventArgs e)
        {

        }

        private void DriveSize_Click(object sender, EventArgs e)
        {

        }

        private void DriveSizeTrack_Scroll(object sender, EventArgs e)
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

        }
    }
}
