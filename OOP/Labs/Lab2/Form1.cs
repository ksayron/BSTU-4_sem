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
    public partial class Компьютер : Form
    {
        public Компьютер()
        {
            InitializeComponent();
        }

        private void DriveSizeTrack_Scroll(object sender, EventArgs e)
        {
            DriveSizeValue.Text = String.Format("Значение: {0} GB", DriveSizeTrack.Value);
        }

        private void RamValueTrack_Scroll(object sender, EventArgs e)
        {
            RamValue.Text = String.Format("Значение: {0} GB", RamValueTrack.Value);
        }
    }
}
