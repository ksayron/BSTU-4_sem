using KNP_Library.Modules.classes;
using KNP_Library.Modules.DAL;
using KNP_Library.Modules.Interfaces;
using KNP_Library.Modules.View;
using KNP_Library.Modules.ViewModel;
using KNP_Library.Views;
using Lab4_5.Views;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace KNP_Library.ViewModels
{
    class UserPageForUserViewModel : BaseViewModel
    {
        public User CurrnetUser { get; set; }
        public Repository _repository;
        public string ImgSource { get; set; } = "../Resources/Images/ProfPic/virusi.jpg";

        public bool CanExtend => ExtendOrderCommand.CanExecute(this);




        public ICommand OpenLogCommand { get; }
        public ICommand OpenBookPageCommand { get; }
        public ICommand ExtendOrderCommand { get; }
        public ICommand SelectImageCommand { get; }
        public ICommand ChangeLanguageEnCommand { get; }
        public ICommand ChangeLanguageRuCommand { get; }
        
        static HttpClientHandler handler = new HttpClientHandler
        {
            ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
        };

        HttpClient client = new HttpClient(handler);
        public UserPageForUserViewModel()
        {

            ChangeLanguageRuCommand = new RelayCommand(_ => LanguageManager.Instance.ChangeLanguage("ru-RU"));
            ChangeLanguageEnCommand = new RelayCommand(_ => LanguageManager.Instance.ChangeLanguage("en-US"));

            CurrnetUser = new User();
            var new_order = new Order();
            var new_order2 = new Order();
            var new_book = new Book();
            new_book.Title = "Test";
            new_order.Book = new_book;
            new_order2.Book = new_book;
            new_order2.CloseOrder();
            CurrnetUser.Orders.Add(new_order);
            CurrnetUser.Orders.Add(new_order2);
            
            OnPropertyChanged(nameof(CurrnetUser));


        }
        public UserPageForUserViewModel(User currnetUser)
        {
            OpenLogCommand = new RelayCommand(OpenLogExecute, CanOpenLogExecute);
            OpenBookPageCommand = new RelayCommand(OpenBookPageExecute);

            ExtendOrderCommand = new RelayCommand(ExtendOrderExecute, CanExtendOrderExecute);
            SelectImageCommand = new RelayCommand(_ => UploadFile("image"));
            ChangeLanguageRuCommand = new RelayCommand(_ => LanguageManager.Instance.ChangeLanguage("ru-RU"));
            ChangeLanguageEnCommand = new RelayCommand(_ => LanguageManager.Instance.ChangeLanguage("en-US"));
            CurrnetUser = currnetUser;

        }


        private void OpenBookPageExecute(object? obj)
        {
            var what_is = obj.GetType();
            if (obj is Order order)
            {
                var repository = App.ServiceProvider.GetRequiredService<Repository>();
                var book_page_vm = new BookPageForUserViewModel(order.Book, CurrnetUser)
                {
                    _repository = repository
                };

                var book_page = new BookPageForUser()
                {
                    DataContext = book_page_vm
                };
                book_page.ShowDialog();
            }
            else
            {
                var mes = new Message("fix", "pls");
                mes.Show();
            }
        }

        private void OpenLogExecute(object? obj)
        {
            var user_log = new UserBookLog()
            {
                DataContext = this
            };
            user_log.ShowDialog();

        }

        private bool CanOpenLogExecute(object? obj)
        {
            return CurrnetUser.HistoryLog.Count > 0;
        }
        private void ExtendOrderExecute(object? obj)
        {
            if (obj is Order order)
            {
                if (order.DueAt > DateTime.Now.AddMonths(2))
                {
                    ShowError("Нельзя продлить >2 месяцев");
                    return;
                }
                order.DueAt = order.DueAt.AddMonths(1);
                _repository.Orders.UpdateOrderById(order.OrderId,order);
                CurrnetUser = _repository.Users.GetUserByCardId(CurrnetUser.CardId);
                OnPropertyChanged(nameof(CurrnetUser));
            }
        }

        private bool CanExtendOrderExecute(object? obj)
        {

            return _repository is not null ;
        }

        private void ShowError(string message)
        {
            var msgBox = new Message("Ошибка при продлении", message);
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
                Filter = type == "image" ? "Image Files|*.jpg;*.png;*.jpeg":"none" 
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
                                CurrnetUser.ProfilePicImage = result.path;
                                _repository.Users.UpdateUser(CurrnetUser.CardId, CurrnetUser);
                                OnPropertyChanged(nameof(CurrnetUser));
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