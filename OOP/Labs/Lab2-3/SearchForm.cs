using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Lab2
{
    public partial class SearchForm : Form
    {
        public List<Computer> computers;
        string query;
        public List<Computer> responce;
        string regex = @"^\d+\$$";

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
                    if(!Regex.IsMatch(query,regex)){
                        if (comp.Name.Contains(query))
                        {
                            responce.Add(comp);

                        }

                    }
                    else
                    {
                        string purge = query.Replace("$", "");
                        int search = 0;
                        if(!int.TryParse(purge, out search) && purge != "")
                        {
                            MessageBox.Show("Ошибка при обработке запроса", "Ой", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        if (comp.Price<search)
                        {
                            responce.Add(comp);

                        }
                    }

                }
                
            }
            if (sortBy_comboBox.SelectedIndex == 1)
            {
                responce = responce.OrderBy(comp => comp.Price).ToList<Computer>();
            }
            XmlSerializer xml = new XmlSerializer(typeof(List<Computer>));
            using (StreamWriter writer = new StreamWriter("search.xml"))
            {
                xml.Serialize(writer, responce);
            }
            foreach (var comp in responce)
            {
                richTextBox1.Text += $"{comp.Name} {comp.Type} {comp.Proccesor.Producer} {comp.Proccesor.Series} {comp.Proccesor.Model} {comp.Price}$" + '\n';
            }
        }

        private void sortBy_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            responce = new List<Computer>();
            query = textBox1.Text;
            foreach (var comp in computers)
            {
                if (query != "")
                {
                    if (comp.Name.Contains(query))
                    {
                        responce.Add(comp);

                    }

                }
                else
                {
                    responce.Add(comp);
                }

            }
            richTextBox1.Text = "";
            if (sortBy_comboBox.SelectedIndex == 1)
            {
                responce = responce.OrderBy(comp => comp.Price).ToList<Computer>();
            }
            foreach (var comp in responce)
            {
                richTextBox1.Text += $"{comp.Name} {comp.Type} {comp.Proccesor.Producer} {comp.Proccesor.Series} {comp.Proccesor.Model} {comp.Price}$" + '\n';
            }
        }
    }
}
