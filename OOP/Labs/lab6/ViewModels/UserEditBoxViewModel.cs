using KNP_Library.Modules.classes;
using KNP_Library.Modules.DAL;
using KNP_Library.Modules.Hash;
using KNP_Library.Modules.View;
using KNP_Library.Modules.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;


namespace KNP_Library.ViewModels
{
    class UserEditBoxViewModel : BaseViewModel
    {
        public Repository _repository;
        public User CurrentUser { get; set; }
        public string Login { get; set; } = "";
        public string ImagePath { get; set; } = "";
        public string Email { get; set; } = "";
        public int CardId { get; set; } = 0;
        public bool IsAdmin { get; set; } = false;

        public ICommand EditUserCommand { get; }
        public ICommand OpenLoginCommand { get; }
        public ICommand SelectImageCommand { get; }
        public ICommand ChangeLanguageRuCommand { get; }
        public ICommand ChangeLanguageEnCommand { get; }

        static HttpClientHandler handler = new HttpClientHandler
        {
            ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
        };

        HttpClient client = new HttpClient(handler);

        public UserEditBoxViewModel()
        {
            //_repository = ((App)Application.Current).repository;
            EditUserCommand = new RelayCommand(RegistrationExecute, CanRegister);
           
            ChangeLanguageRuCommand = new RelayCommand(_ => LanguageManager.Instance.ChangeLanguage("ru-RU"));
            ChangeLanguageEnCommand = new RelayCommand(_ => LanguageManager.Instance.ChangeLanguage("en-US"));
        }

        private bool CanRegister(object? obj)
        {
            return Login.Length > 0 & CardId > 0 & Email.Length > 0;
        }

        public UserEditBoxViewModel(User currentUser)
        {
            CurrentUser = currentUser;
            EditUserCommand = new RelayCommand(RegistrationExecute,CanRegister);
            SelectImageCommand = new RelayCommand(_ => UploadFile("image"));
            ChangeLanguageRuCommand = new RelayCommand(_ => LanguageManager.Instance.ChangeLanguage("ru-RU"));
            ChangeLanguageEnCommand = new RelayCommand(_ => LanguageManager.Instance.ChangeLanguage("en-US"));
            Login = CurrentUser.Username;
            ImagePath = CurrentUser.ProfilePicImage;
            Email = CurrentUser.Email;
            CardId = CurrentUser.CardId;
            if (CurrentUser.RoleId == 2)
            {
                IsAdmin = true;
            }
        }

        private void RegistrationExecute(object? obj)
        {
            var card_input = CardId;

            var login_input = Login;

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



            if (!Regex.IsMatch(email_input, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                ShowError("Введите корректный адрес электронной почты.");
                return;
            }

            //проверка бд
            if (_repository.Users.GetUserByCardId(card_input) is not null && card_input!=CurrentUser.CardId)
            {
                ShowError("Данная карта читателя уже занята");
                return;
            }

            if (_repository.Users.GetUserIdByUsername(login_input) != 0 && login_input != CurrentUser.Username)
            {
                ShowError("Данный логин уже занят");
                return;
            }

            if (_repository.Users.GetUserIdByUsername(email_input) != 0 && email_input != CurrentUser.Email)
            {
                ShowError("Данная почта уже занята");
                return;
            }

            //успех
            var old_cardid=CurrentUser.CardId;
            CurrentUser.Username = login_input;
            CurrentUser.Email = email_input;
            CurrentUser.CardId = card_input;
            CurrentUser.ProfilePicImage = ImagePath;
            if (IsAdmin)
            {
                CurrentUser.RoleId = 2;
            }
            if (_repository.Users.UpdateUser(old_cardid,CurrentUser))
            {
                Close(obj);
            }
            else
            {
                ShowError("Неопознанная ошибка. Повторите позже.");
            }

        }

        private void UploadFile(string type)
        {
            var dialog = new Microsoft.Win32.OpenFileDialog
            {
                Filter = type == "image" ? "Image Files|*.jpg;*.png;*.jpeg" : "none"
            };

            if (dialog.ShowDialog() == true)
            {
                string filePath = dialog.FileName;
                var fileContent = new StreamContent(File.OpenRead(filePath));
                var formData = new MultipartFormDataContent
                {
                    { fileContent, "file", Path.GetFileName(filePath) }
                };

                try
                {
                    var response = client.PostAsync("https://localhost:7273/upload", formData).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var json = response.Content.ReadAsStringAsync().Result;
                        var result = System.Text.Json.JsonSerializer.Deserialize<UploadResponse>(json);
                        if (result != null)
                        {
                            if (type == "image")
                            {
                                ImagePath = result.path;
                                
                                OnPropertyChanged(nameof(ImagePath));
                            }


                        }
                    }
                    else
                    {
                        ShowError("Ошибка при загрузке файла: " + response.ReasonPhrase);
                    }
                }
                catch (Exception ex)
                {
                    ShowError("Ошибка соединения: " + ex.Message);
                }
            }
        }

        private class UploadResponse
        {
            public string path { get; set; }
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