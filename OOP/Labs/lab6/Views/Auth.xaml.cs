using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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
using KNP_Library.Modules.classes;
using KNP_Library.Modules.Hash;
using KNP_Library.Modules.DAL;
using KNP_Library.Modules.View;
using KNP_Library.ViewModels;

namespace KNP_Library
{
    /// <summary>
    /// Логика взаимодействия для Auth.xaml
    /// </summary>
    public partial class Auth : Window
    {
        //Repository repo = ((App)Application.Current).repository;
        public Auth()
        {
            InitializeComponent();
        }
        public Auth(AuthViewModel vm)
        {
            InitializeComponent();
            DataContext = vm;
        }


        private void PasswordInput_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext is AuthViewModel vm)
            {
                vm.Password = PasswordInput.Password;
            }
        }

    }
}
