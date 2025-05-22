using KNP_Library.Modules.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Lab4_5.Views
{
    /// <summary>
    /// Логика взаимодействия для ReviewsBox.xaml
    /// </summary>
    public partial class ReviewsBox : Window
    {
        public List<Review> Reviews { get; set; }
        public ReviewsBox()
        {
            InitializeComponent();
        }
        private void OnlyNumericInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !int.TryParse(e.Text, out _);
        }
    }
}
