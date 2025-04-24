using Lab4_5.Modules.DAL;
using Lab4_5.Modules.Hash;
using Lab4_5.Modules.ViewModel;
using Lab4_5.Modules.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;

namespace Lab4_5.ViewModels
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
            //_repository = ((App)Application.Current).repository;

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
            var userId = _repository.GetUserIdByUsername(Login);
            if (userId == 0)
            {
                ShowError("Неверный логин или пароль");
                return;
            }

            var user = _repository.GetUserByCardId(userId);
            if (user == null || !SecurePasswordHasher.Verify(Password, user.PasswordHash))
            {
                ShowError("Неверный логин или пароль");
                return;
            }

            switch (user.RoleId)
            {
                case 1:
                    {
                        var mainWindow = new UserMain(user);
                        mainWindow?.Show();
                        Close(obj);
                        break;
                    }
                case 2:
                    {
                        var mainWindow = new AdminMain(user);
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
