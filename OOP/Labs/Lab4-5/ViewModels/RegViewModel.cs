using Lab4_5.Modules.classes;
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
            var card_input = CardId;

            var login_input = Login;
            var password_input = Password;
            var email_input = Email;
            if (_repository.GetUserByCardId(card_input) is not null)
            {
                ShowError("Данная карта читателя уже занята");
                return;
            }
            else
            {
                if (_repository.GetUserIdByUsername(login_input) != 0)
                {
                   
                    ShowError("Данный логин уже занят");
                    return;
                }
                else
                {
                    if (_repository.GetUserIdByUsername(email_input) != 0)
                    {
                        ShowError("Данная почта уже занята");
                        return;
                    }
                    else
                    {
                        var hashed_password = SecurePasswordHasher.Hash(password_input);
                        var new_user = new User(card_input, login_input, hashed_password, email_input, 2);
                        if (_repository.AddUser(new_user))
                        {
                            var message_box = new Message("Регистрация завершена", "Вы успешно зарегестрировались");
                            message_box.Show();
                            Close(obj);
                            var auth_box = new Auth();
                            auth_box.Show();
                        }
                        else
                        {
                            ShowError("Неопознная ошибка.повторите позже");
                        }

                    }
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
            var msgBox = new Message("Ошибка при регестрации", message);
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

