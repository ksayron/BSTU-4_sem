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
using Lab4_5.Modules.classes;
using Lab4_5.Modules.Hash;
using Lab4_5.Modules.DAL;
using Lab4_5.Modules.View;
using Lab4_5.ViewModels;

namespace Lab4_5
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
        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext is AuthViewModel vm)
                vm.Password = ((PasswordBox)sender).Password;
        }
        //private void Button_Click(object sender, RoutedEventArgs e)
        //{

        //    var auth_id = repo.GetUserIdByUsername(LoginIput.Text);
        //    if(auth_id == 0)
        //    {
        //        var message_box = new Message("Ошибка при входе", "Неверный логин или пароль");
        //        message_box.Left=this.Left;
        //        message_box.Top=this.Top+150;
        //        message_box.ShowDialog();
        //        return;
        //    }
        //    var auth_user = repo.GetUserByCardId(auth_id);
        //    if (auth_user == null )
        //    {
        //        var message_box = new Message("Ошибка при входе", "Неверный логин или пароль");
        //        message_box.Left = this.Left;
        //        message_box.Top = this.Top + 150;
        //        message_box.ShowDialog();
        //    }
        //    else
        //    {

        //        if (!SecurePasswordHasher.Verify(PasswordInput.Password,auth_user.PasswordHash))
        //        {
        //            var message_box = new Message("Ошибка при входе", "Неверный логин или пароль");
        //            message_box.Left = this.Left;
        //            message_box.Top = this.Top + 150;
        //            message_box.ShowDialog();
        //            return ;

        //        }
        //        else
        //        {
        //            if(auth_user.RoleId==1){var main_form = new UserMain(auth_user);
        //                main_form.Show();
        //                this.Close();
        //            }
        //            if (auth_user.RoleId == 2)
        //            {
        //                var main_form = new AdminMain(auth_user);
        //                main_form.Show();
        //                this.Close();
        //            }
        //        }
        //    }
        //}

        //private void Button_Click_1(object sender, RoutedEventArgs e)
        //{
        //    var reg_form = new Reg();
        //    reg_form.Top = this.Top-20;
        //    reg_form.Left = this.Left-20;
        //    reg_form.Show();
        //    this.Close();
        //}
        //private void RuButton_Click(object sender, RoutedEventArgs e)
        //{
        //    LanguageManager.Instance.ChangeLanguage("ru-RU");
        //}
        //private void EnButton_Click(object sender, RoutedEventArgs e)
        //{
        //    LanguageManager.Instance.ChangeLanguage("en-US");
        //}
    }
}
