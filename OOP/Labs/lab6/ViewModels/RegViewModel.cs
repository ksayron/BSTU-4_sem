﻿using KNP_Library.Modules.classes;
using KNP_Library.Modules.DAL;
using KNP_Library.Modules.Hash;
using KNP_Library.Modules.View;
using KNP_Library.Modules.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace KNP_Library.ViewModels
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
            RegistrationCommand = new RelayCommand(RegistrationExecute,CanRegister);
            OpenLoginCommand = new RelayCommand(OpenLoginExecute);
            ChangeLanguageRuCommand = new RelayCommand(_ => LanguageManager.Instance.ChangeLanguage("ru-RU"));
            ChangeLanguageEnCommand = new RelayCommand(_ => LanguageManager.Instance.ChangeLanguage("en-US"));
        }

        private bool CanRegister(object? obj)
        {
            return Login.Length>0 & Password.Length > 0 & CardId >0 & Email.Length>0;
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

            if (!Regex.IsMatch(password_input, @"^(?=.*[A-Z])(?=.*\d)[^\s]{8,}$"))
            {
                ShowError("Пароль должен содержать не менее 8 символов, одну заглавную букву и одну цифру, без пробелов.");
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

            if (_repository.Users.GetUserIdByEmail(email_input) != 0)
            {
                ShowError("Данная почта уже занята");
                return;
            }

            //успех
            var hashed_password = SecurePasswordHasher.Hash(password_input);
            var new_user = new User(card_input, login_input, hashed_password, email_input, 1);
            if (_repository.Users.AddUser(new_user))
            {
                try
                {
                    SendRegistrationEmail(email_input, login_input);
                }
                catch (Exception ex)
                {
                    ShowError($"Регистрация прошла, но не удалось отправить письмо: {ex.Message}");
                }

                var message_box = new Message("Регистрация завершена", "Вы успешно зарегистрировались");
                message_box.Show();

                var auth = App.ServiceProvider.GetRequiredService<Auth>();
                if (obj is Window currentWindow)
                {
                    auth.Top = currentWindow.Top + 20;
                    auth.Left = currentWindow.Left + 20;
                }
                auth.Show();
                Close(obj);
            }
            else
            {
                ShowError("Неопознанная ошибка. Повторите позже.");
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


        private void SendRegistrationEmail(string toEmail, string userName)
        {
            var fromAddress = new MailAddress("kucheruk05work@gmail.com", "KNP-Library");
            var toAddress = new MailAddress(toEmail, userName);
            const string fromPassword = "gaay hzgt pmmz xhzp"; 
            const string subject = "Регистрация в KNP-Library";
            string body = $"Здравствуйте, {userName}!\n\nВы успешно зарегистрировались в KNP-Library!\n\n";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address,fromPassword)
            };

            using var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            };
            smtp.Send(message);
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

