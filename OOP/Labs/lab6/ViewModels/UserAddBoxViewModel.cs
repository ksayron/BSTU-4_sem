using KNP_Library.Modules.DAL;
using KNP_Library.Modules.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using KNP_Library.Modules.ViewModel;
using KNP_Library.Modules.View;
using System.Diagnostics.Metrics;
using System.Collections.ObjectModel;
using System.Windows;
using System.Net.Http;
using System.IO;
using System.Text.RegularExpressions;
using KNP_Library.Modules.Hash;
using Microsoft.Extensions.DependencyInjection;
namespace KNP_Library.ViewModels
{
    public class UserAddBoxViewModel : BaseViewModel
    {
        Repository _repository;

        public string Login { get; set; } = "";
        public string Password { get; set; } = "";
        public string Email { get; set; } = "";
        public int CardId { get; set; }

        public bool IsAdmin { get; set; } = false;

        public ICommand RegistrationCommand { get; }
        public ICommand OpenLoginCommand { get; }
        public ICommand ChangeLanguageRuCommand { get; }
        public ICommand ChangeLanguageEnCommand { get; }

        public UserAddBoxViewModel()
        {
            //_repository = ((App)Application.Current).repository;
            RegistrationCommand = new RelayCommand(RegistrationExecute, CanRegister);
            ChangeLanguageRuCommand = new RelayCommand(_ => LanguageManager.Instance.ChangeLanguage("ru-RU"));
            ChangeLanguageEnCommand = new RelayCommand(_ => LanguageManager.Instance.ChangeLanguage("en-US"));
        }

        private bool CanRegister(object? obj)
        {
            return Login.Length > 0 & Password.Length > 0 & CardId > 0 & Email.Length > 0;
        }

        public UserAddBoxViewModel(Repository repository)
        {
            _repository = repository;

            RegistrationCommand = new RelayCommand(RegistrationExecute);
            ChangeLanguageRuCommand = new RelayCommand(_ => LanguageManager.Instance.ChangeLanguage("ru-RU"));
            ChangeLanguageEnCommand = new RelayCommand(_ => LanguageManager.Instance.ChangeLanguage("en-US"));
        }

        private void RegistrationExecute(object? obj)
        {
            var card_input = CardId;

            var login_input = Login;
            var password_input = Password;
            var email_input = Email;
            //валидация
            if (!Regex.IsMatch(card_input.ToString(), @"^(100000|[1-9][0-9]{5})$"))
            {
                ShowError("Неверный номер карты. Он должен быть числом от 100000 до 999999.");
                return;
            }

            if (!Regex.IsMatch(login_input, @"^[^\s!@#$%^&*()+=<>?/\\|`~{}\[\]\""'.,]{8,}$"))
            {
                ShowError("Логин должен содержать не менее 8 символов, без пробелов и запрещённых символов.");
                return;
            }

            if (!Regex.IsMatch(password_input, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&^#()[\]{}|\\/\-+_.:;=,~`])[^\s<>]{8,}$"))
            {
                ShowError("Пароль должен содержать не менее 8 символов, одну заглавную букву, спец. символ(@$!%*?&^#()[\\]{}|\\\\/\\-+_.:;=,~`) и одну цифру, без пробелов.");
                return;
            }

            if (!Regex.IsMatch(email_input, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                ShowError("Введите корректный адрес электронной почты.");
                return;
            }

            //проверка бд
            if (_repository.Users.GetUserByCardId(card_input) is not null)
            {
                ShowError("Данная карта читателя уже занята");
                return;
            }

            if (_repository.Users.GetUserIdByUsername(login_input) != 0)
            {
                ShowError("Данный логин уже занят");
                return;
            }

            if (_repository.Users.GetUserIdByUsername(email_input) != 0)
            {
                ShowError("Данная почта уже занята");
                return;
            }

            //успех
            var hashed_password = SecurePasswordHasher.Hash(password_input);
            int roleId;
            if(IsAdmin)
            {
                roleId = 2;
            }
            else
            {
                roleId = 1;
            }
            var new_user = new User(card_input, login_input, hashed_password, email_input, roleId);
            if (_repository.Users.AddUser(new_user))
            {

                Close(obj);
            }
            else
            {
                ShowError("Неопознанная ошибка. Повторите позже.");
            }

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
