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
    /// Логика взаимодействия для UserEditBox.xaml
    /// </summary>
    public partial class UserEditBox : Window
    {
        public UserEditBox()
        {
            InitializeComponent();
        }
        private void OnlyNumericInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !int.TryParse(e.Text, out _);
        }
    }
}
