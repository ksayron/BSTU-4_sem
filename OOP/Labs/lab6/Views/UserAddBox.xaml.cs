using KNP_Library.ViewModels;
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

namespace KNP_Library.Views
{
    /// <summary>
    /// Логика взаимодействия для UserAddBox.xaml
    /// </summary>
    public partial class UserAddBox : Window
    {
        public UserAddBox()
        {
            InitializeComponent();
        }
        private void PasswordInput_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext is UserAddBoxViewModel vm)
            {
                vm.Password = PasswordInput.Password;
            }
        }
        private void OnlyNumericInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !int.TryParse(e.Text, out _);
        }
    }
}
