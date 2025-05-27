using D_D_CharacterSheet.Data;
using D_D_CharacterSheet.Models;
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
using System.Windows.Threading;

namespace D_D_CharacterSheet.View
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private readonly DatabaseManager _db = new();
        public User LoggedInUser { get; private set; }

        public LoginWindow()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            var user = _db.AuthenticateUser(UsernameBox.Text, PasswordBox.Password);
            if (user != null)
            {
                LoggedInUser = user;
                DialogResult = true;
                Close();
            }
            else
            {
                MessageBox.Show("Неправильный логин или пароль");
            }
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            bool created = _db.RegisterUser(UsernameBox.Text, PasswordBox.Password);
            if (created)
                MessageBox.Show("Вы успешно зарегестрировались!");
            else
                MessageBox.Show("Данный логин уже занят");
        }
    }
}
