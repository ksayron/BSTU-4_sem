using KNP_Library.Modules.DAL;
using KNP_Library.Modules.Hash;
using KNP_Library.Modules.ViewModel;
using KNP_Library.Modules.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using Lab4_5.Views;

namespace KNP_Library.ViewModels
{
    public class AuthViewModel : BaseViewModel
    {
        Repository _repository;

        public string Login { get; set; } = "";
        public string Password { get; set; } = "";

        public ICommand LoginCommand { get; }
        public ICommand OpenRegisterCommand { get; }
        public ICommand ChangeLanguageRuCommand { get; }
        public ICommand ChangeLanguageEnCommand { get; }

        public AuthViewModel()
        {

            LoginCommand = new RelayCommand(LoginExecute);
            OpenRegisterCommand = new RelayCommand(OpenRegisterExecute);
            ChangeLanguageRuCommand = new RelayCommand(_ => LanguageManager.Instance.ChangeLanguage("ru-RU"));
            ChangeLanguageEnCommand = new RelayCommand(_ => LanguageManager.Instance.ChangeLanguage("en-US"));
        }
        public AuthViewModel(Repository repository)
        {
            _repository = repository;

            LoginCommand = new RelayCommand(LoginExecute);
            OpenRegisterCommand = new RelayCommand(OpenRegisterExecute);
            ChangeLanguageRuCommand = new RelayCommand(_ => LanguageManager.Instance.ChangeLanguage("ru-RU"));
            ChangeLanguageEnCommand = new RelayCommand(_ => LanguageManager.Instance.ChangeLanguage("en-US"));
        }

        private void LoginExecute(object? obj)
        {
            var userId = _repository.Users.GetUserIdByUsername(Login);
            if (userId == 0)
            {
                ShowError("Неверный логин или пароль");
                return;
            }

            var user = _repository.Users.GetUserByCardId(userId);
            if (user == null || !SecurePasswordHasher.Verify(Password, user.PasswordHash))
            {
                ShowError("Неверный логин или пароль");
                return;
            }

            switch (user.RoleId)
            {
                case 1:
                    {
                        var vm = App.ServiceProvider.GetRequiredService<UserMainViewModel>();
                        vm.CurrnetUser = user;
                        var mainWindow = new UserMain()
                        {
                            DataContext = vm
                        };
                        mainWindow?.Show();
                        var start_pos = mainWindow.Top+mainWindow.Height;
                        var edge_pos = mainWindow.Left + mainWindow.Width;
                        foreach(var notif in _repository.Notifications.GetAllActiveNotifications())
                        {
                           
                            var notif_win = new NotificationBox(notif.Message);
                            notif_win.Left = edge_pos;
                            notif_win.Top = start_pos;
                            notif_win.Show();
                            start_pos -= 110;
                        }
                        Close(obj);
                        break;
                    }
                case 2:
                    {
                        var vm = App.ServiceProvider.GetRequiredService<AdminMainViewModel>();
                        vm.CurrnetUser = user;
                        var mainWindow = new AdminMain()
                        {
                            DataContext = vm
                        };
                        mainWindow?.Show();
                        Close(obj);
                        break;
                    }
            }

            
        }

        private void OpenRegisterExecute(object? obj)
        {
            var reg = App.ServiceProvider.GetRequiredService<Reg>();
            if (obj is Window currentWindow)
            {
                reg.Top = currentWindow.Top - 20;
                reg.Left = currentWindow.Left - 20;
            }
            reg.Show();
            Close(obj);
        }

        private void ShowError(string message)
        {
            var msgBox = new Message("Ошибка при входе", message);
            msgBox.ShowDialog();
        }

        private void Close(object? window)
        {
            if (window is Window win)
                win.Close();
        }
    }
}
