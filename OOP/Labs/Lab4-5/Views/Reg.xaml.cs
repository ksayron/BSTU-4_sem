using Lab4_5.Modules.DAL;
using Lab4_5.Modules.Hash;
using Lab4_5.Modules.classes;
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
using Lab4_5.Modules.View;
using Lab4_5.ViewModels;

namespace Lab4_5
{
    /// <summary>
    /// Логика взаимодействия для Reg.xaml
    /// </summary>
    public partial class Reg : Window
    {
        Repository repo = ((App)Application.Current).repository;
        public Reg()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)//reg button
        {
            var card_input = Convert.ToInt32(CardInput.Text);

            var login_input = LoginInput.Text;
            var password_input = PasswordInput.Password;
            var email_input = EmailInput.Text;
            if(repo.GetUserByCardId(card_input) is not null)
            {
                var message_box = new Message("Ошибка при регистрации", "Данная карта читателя уже занята");
                message_box.Left = this.Left;
                message_box.Top = this.Top + 150;
                message_box.Show();
                return;
            }
            else
            {
                if (repo.GetUserIdByUsername(login_input) != 0)
                {
                    var message_box = new Message("Ошибка при регистрации", "Данный логин уже занят");
                    message_box.Left = this.Left;
                    message_box.Top = this.Top + 150;
                    message_box.Show();
                    return;
                }
                else
                {
                    if (repo.GetUserIdByUsername(email_input) != 0)
                    {
                        var message_box = new Message("Ошибка при регистрации", "Данная почта уже занята");
                        message_box.Left = this.Left;
                        message_box.Top = this.Top + 150;
                        message_box.Show();
                        return;
                    }
                    else
                    {
                        var hashed_password = SecurePasswordHasher.Hash(password_input);
                        var new_user = new User(card_input, login_input, hashed_password, email_input, 2);
                        if (repo.AddUser(new_user))
                        {
                            var message_box = new Message("Регистрация завершена", "Вы успешно зарегестрировались");
                            message_box.Left = this.Left;
                            message_box.Top = this.Top + 150;
                            message_box.Show();
                            this.Close();
                            var auth_box = new Auth();
                            auth_box.Left = this.Left;
                            auth_box.Top = this.Top - 150;
                            auth_box.Show();
                        }
                        else
                        {
                            var message_box = new Message("Ошибка при регистрации", "Неопознная ошибка. повторите позже");
                            message_box.Left = this.Left;
                            message_box.Top = this.Top + 150;
                            message_box.Show();
                        }
                        
                    }
                }
            }



            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)//auth switch button
        {
            var AuthWind = new Auth();
            AuthWind.Top =this.Top;
            AuthWind.Left =this.Left;
            AuthWind.Show();
            this.Close();
        }
        private void RuButton_Click(object sender, RoutedEventArgs e)
        {
            LanguageManager.Instance.ChangeLanguage("ru-RU");
        }
        private void EnButton_Click(object sender, RoutedEventArgs e)
        {
            LanguageManager.Instance.ChangeLanguage("en-US");
        }

        private void PasswordInput_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext is RegViewModel vm)
            {
                vm.Password = PasswordInput.Password;
            }
        }
    }
}
