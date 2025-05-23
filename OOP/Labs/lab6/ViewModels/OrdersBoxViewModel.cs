using KNP_Library.Modules.classes;
using KNP_Library.Modules.DAL;
using KNP_Library.Modules.ViewModel;
using KNP_Library.ViewModels;
using KNP_Library.Views;
using KNP_Library;
using Lab4_5.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using KNP_Library.Modules.View;
using Microsoft.Extensions.DependencyInjection;

namespace KNP_Library.ViewModels
{
    class OrdersBoxViewModel : BaseViewModel
    {
        public Book CurrentBook { get; set; }
        public User Currentuser { get; set; }
        public string ImgSource { get; set; }

        public ICommand OpenBookCommand { get; }
        public ICommand EditBookCommand { get; }
        public ICommand DeleteBookCommand { get; }
        public ICommand ShowOrdersCommand { get; }
        public ICommand ShowReviewsCommand { get; }
        public ICommand OpenBookPageCommand { get; }
        public ICommand ChangeLanguageEnCommand { get; }
        public ICommand ChangeLanguageRuCommand { get; }
        public OrdersBoxViewModel()
        {

            EditBookCommand = new RelayCommand(EditBookExecute, CanEditBookExecute);
            DeleteBookCommand = new RelayCommand(DeleteBookExecute, CanDeleteBookExecute);
            OpenBookCommand = new RelayCommand(OpenBookExecute, CanOpenPageExecute);
            ChangeLanguageRuCommand = new RelayCommand(_ => LanguageManager.Instance.ChangeLanguage("ru-RU"));
            ChangeLanguageEnCommand = new RelayCommand(_ => LanguageManager.Instance.ChangeLanguage("en-US"));

            var test_author = new Author("Pudgo", "Pudgovanna");
            var test_Genre = new Genre("Dota 2");
            var test_Genre2 = new Genre("Momchik");
            var test_order = new Order();
            CurrentBook = new Book();
            CurrentBook.Authors.Add(test_author);
            CurrentBook.Authors.Add(test_author);
            CurrentBook.Genres.Add(test_Genre);
            CurrentBook.Genres.Add(test_Genre2);
            test_order.Book = CurrentBook;
            CurrentBook.IssuedOrders.Add(test_order);
            CurrentBook.FilePath = "";
            ImgSource = "../Resources/Images/BookImg/book.png";//std pic if no pic;
            OnPropertyChanged(nameof(ImgSource));


        }
        public OrdersBoxViewModel(Book currentBook)
        {
            EditBookCommand = new RelayCommand(EditBookExecute, CanEditBookExecute);
            DeleteBookCommand = new RelayCommand(DeleteBookExecute, CanDeleteBookExecute);
            OpenBookCommand = new RelayCommand(OpenBookExecute, CanOpenPageExecute);
            OpenBookPageCommand = new RelayCommand(OpenBookPageExecute);
            ShowReviewsCommand = new RelayCommand(OpenReviwsExecute);
            ShowOrdersCommand = new RelayCommand(OpenOrdersExecute);
            ChangeLanguageRuCommand = new RelayCommand(_ => LanguageManager.Instance.ChangeLanguage("ru-RU"));
            ChangeLanguageEnCommand = new RelayCommand(_ => LanguageManager.Instance.ChangeLanguage("en-US"));


            CurrentBook = currentBook;
            ImgSource = CurrentBook.ImgPath;
        }

        private void OpenBookPageExecute(object? obj)
        {

        }

        private void OpenOrdersExecute(object? obj)
        {
            var reviews_vm = this;
            var reviews_win = new OrdersBox()
            {
                DataContext = reviews_vm,
            };
            reviews_win.ShowDialog();
        }

        private void OpenReviwsExecute(object? obj)
        {
            var reviews_vm = this;
            var reviews_win = new ReviewsBox()
            {
                DataContext = reviews_vm,
            };
            reviews_win.ShowDialog();
        }

        private void OpenBookExecute(object? obj)
        {
            string pdfUrl = CurrentBook.FilePath;

            try
            {
                System.Diagnostics.Process.Start(new ProcessStartInfo
                {
                    FileName = pdfUrl,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                var mes = new Message("Не удалось открыть PDF-файл: " + ex.Message, "Ошибка");
                mes.ShowDialog();
            }

        }

        private bool CanOpenPageExecute(object? obj)
        {
            return CurrentBook.FilePath.Length > 0;
        }
        private void EditBookExecute(object? obj)
        {
            var repository = App.ServiceProvider.GetRequiredService<Repository>();
            var win_vm = new EditBookViewModel(repository, CurrentBook);
            var win = new EditBook()
            {
                DataContext = win_vm
            };
            win.ShowDialog();
            CurrentBook = repository.Books.GetBookById(CurrentBook.Id);
            OnPropertyChanged(nameof(CurrentBook));
        }

        private bool CanEditBookExecute(object? obj)
        {
            return CurrentBook.Id > 0;
        }

        private void DeleteBookExecute(object? obj)
        {
            if (obj is Window win)
            {
                var repository = App.ServiceProvider.GetRequiredService<Repository>();
                if (repository.Books.DeleteBookById(CurrentBook.Id))
                {
                    win.Close();
                }
            }
        }

        private bool CanDeleteBookExecute(object? obj)
        {
            return CurrentBook.Id > 0;
        }
    }
}
