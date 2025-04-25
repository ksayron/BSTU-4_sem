using Lab4_5.Modules.DAL;
using Lab4_5.Modules.Hash;
using Lab4_5.Modules.View;
using Lab4_5.Modules.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using System.Windows.Input;

namespace Lab4_5.ViewModels
{
    public class RegViewModel : BaseViewModel
    {
        Repository _repository;

        public string Login { get; set; } = "";
        public string Password { get; set; } = "";
        public string Email { get; set; } = "";
        public int CardId { get; set; }

        public ICommand RegistrationCommand { get; }
        public ICommand OpenLoginCommand { get; }
        public ICommand ChangeLanguageRuCommand { get; }
        public ICommand ChangeLanguageEnCommand { get; }

        public RegViewModel()
        {
            //_repository = ((App)Application.Current).repository;
            RegistrationCommand = new RelayCommand(RegistrationExecute);
            OpenLoginCommand = new RelayCommand(OpenLoginExecute);
            ChangeLanguageRuCommand = new RelayCommand(_ => LanguageManager.Instance.ChangeLanguage("ru-RU"));
            ChangeLanguageEnCommand = new RelayCommand(_ => LanguageManager.Instance.ChangeLanguage("en-US"));
        }
        public RegViewModel(Repository repository)
        {
            _repository = repository;

            RegistrationCommand = new RelayCommand(RegistrationExecute);
            OpenLoginCommand = new RelayCommand(OpenLoginExecute);
            ChangeLanguageRuCommand = new RelayCommand(_ => LanguageManager.Instance.ChangeLanguage("ru-RU"));
            ChangeLanguageEnCommand = new RelayCommand(_ => LanguageManager.Instance.ChangeLanguage("en-US"));
        }

        private void RegistrationExecute(object? obj)
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

        private void OpenLoginExecute(object? obj)
        {
            var auth = App.ServiceProvider.GetRequiredService<Auth>();
            if (obj is Window currentWindow)
            {
                auth.Top = currentWindow.Top + 20;
                auth.Left = currentWindow.Left + 20;
            }
            auth.Show();
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
            {
                win.Close();
            }
        }
    }
}

