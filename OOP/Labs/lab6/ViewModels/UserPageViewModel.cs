using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KNP_Library.Modules.classes;
using KNP_Library.Modules.DAL;
using KNP_Library.Modules.View;
using KNP_Library.Modules.ViewModel;
using KNP_Library;
using System.DirectoryServices;
using KNP_Library.Modules.Interfaces;
using System.Windows.Input;
using Microsoft.Extensions.DependencyInjection;
using KNP_Library.Views;
using static System.Reflection.Metadata.BlobBuilder;
using System.Windows;
using System.Net.Http;
using System.IO;
using Lab4_5.Views;

namespace KNP_Library.ViewModels
{
    class UserPageViewModel : BaseViewModel
    {
        public User CurrentUser { get; set; }
        public string ImgSource { get; set; }
        public Repository _repository {  get; set; }

        public bool IsSelf { get; set; } = false;

        public ICommand EditUserCommand { get; }
        public ICommand DeleteUserCommand { get; }
        public ICommand ShowOrdersCommand { get; }
        public ICommand ShowReviewsCommand { get; }
        public ICommand SelectImageCommand { get; }
        public ICommand ChangeLanguageEnCommand { get; }
        public ICommand ChangeLanguageRuCommand { get; }

        static HttpClientHandler handler = new HttpClientHandler
        {
            ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
        };

        HttpClient client = new HttpClient(handler);
        public UserPageViewModel()
        {

            EditUserCommand = new RelayCommand(EditBookExecute, CanEditBookExecute);
            DeleteUserCommand = new RelayCommand(DeleteBookExecute, CanDeleteBookExecute);

            ChangeLanguageRuCommand = new RelayCommand(_ => LanguageManager.Instance.ChangeLanguage("ru-RU"));
            ChangeLanguageEnCommand = new RelayCommand(_ => LanguageManager.Instance.ChangeLanguage("en-US"));

            CurrentUser = new User();

        }
        public UserPageViewModel(User currentUser)
        {
            EditUserCommand = new RelayCommand(EditBookExecute, CanDeleteBookExecute);
            DeleteUserCommand = new RelayCommand(DeleteBookExecute, CanDeleteBookExecute);
            SelectImageCommand = new RelayCommand(_ => UploadFile("image"));
            ShowReviewsCommand = new RelayCommand(OpenReviwsExecute);
            ShowOrdersCommand = new RelayCommand(OpenOrdersExecute);
            ChangeLanguageRuCommand = new RelayCommand(_ => LanguageManager.Instance.ChangeLanguage("ru-RU"));
            ChangeLanguageEnCommand = new RelayCommand(_ => LanguageManager.Instance.ChangeLanguage("en-US"));

            CurrentUser = currentUser;
            
        }
        private void OpenOrdersExecute(object? obj)
        {
            var book = new Book();
            book.IssuedOrders = CurrentUser.Orders;
            var reviews_vm = new BookPageViewModel(book);
            var reviews_win = new OrdersBox()
            {
                DataContext = reviews_vm,
            };
            reviews_win.ShowDialog();
        }

        private void OpenReviwsExecute(object? obj)
        {
            var book = new Book();
            book.Reviews = CurrentUser.Reviews;
            var reviews_vm = new BookPageViewModel(book);
            var reviews_win = new ReviewsBox()
            {
                DataContext = reviews_vm,
            };
            reviews_win.ShowDialog();
        }
        private void EditBookExecute(object? obj)
        {
            var user_page_vm = new UserEditBoxViewModel(CurrentUser)
            {
                _repository = _repository
            };
            var user_page = new UserEditBox()
            {
                DataContext = user_page_vm,
            };
            user_page.ShowDialog();

            OnPropertyChanged(nameof(CurrentUser));
        }

        private bool CanEditBookExecute(object? obj)
        {
            return CurrentUser.Id >0 && !IsSelf;
        }

        private void DeleteBookExecute(object? obj)
        {
            if (_repository.Users.DeleteUserById(CurrentUser.CardId))
            {
                Close(obj);
            }
        }

        private bool CanDeleteBookExecute(object? obj)
        {
            return CurrentUser.Id > 0 && !IsSelf;
        }
        private void ShowError(string message)
        {
            var msgBox = new Message("Ошибка страницы", message);
            msgBox.ShowDialog();
        }

        private void Close(object? window)
        {
            if (window is Window win)
            {
                win.Close();
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
                                CurrentUser.ProfilePicImage = result.path;
                                _repository.Users.UpdateUser(CurrentUser.CardId, CurrentUser);
                                OnPropertyChanged(nameof(CurrentUser));
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
    }
}
