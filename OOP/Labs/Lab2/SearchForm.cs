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
    public partial class SearchForm : Form
    {
        public List<Computer> computers;
        string query;
        public List<Computer> responce;
        public SearchForm()
        {

            InitializeComponent();

        }
        public SearchForm(List<Computer> comps)
        {
            computers = comps;
            InitializeComponent();
            foreach (var comp in computers)
            {
                richTextBox1.Text += $"{comp.Name} {comp.Type} {comp.Proccesor.Producer} {comp.Proccesor.Series} {comp.Proccesor.Model} {comp.Price}$" + '\n';
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            responce = new List<Computer>();
            query = textBox1.Text;
            richTextBox1.Text = "";
            foreach (var comp in computers)
            {
                if(query != null)
                {
                    if (comp.Name.Contains(query))
                    {
                        responce.Add(comp);
                        
                    }
                   
                }
                
            }
            if (sortBy_comboBox.SelectedIndex == 1)
            {
                responce = responce.OrderBy(comp => comp.Price);
            }
            foreach (var comp in responce)
            {
                richTextBox1.Text += $"{comp.Name} {comp.Type} {comp.Proccesor.Producer} {comp.Proccesor.Series} {comp.Proccesor.Model} {comp.Price}$" + '\n';
            }
        }
    }
}
