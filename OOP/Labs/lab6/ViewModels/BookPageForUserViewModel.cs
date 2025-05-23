using KNP_Library.Modules.classes;
using KNP_Library.Modules.DAL;
using KNP_Library.Modules.Interfaces;
using KNP_Library.Modules.View;
using KNP_Library.Modules.ViewModel;
using KNP_Library.Views;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace KNP_Library.ViewModels
{
    public class BookPageForUserViewModel : BaseViewModel
    {
        public Book CurrentBook { get; set; }
        public User CurrnetUser { get; set; }
        public Repository _repository;
        public string ImgSource { get; set; }

        private Visibility _orderButtonVisibility = Visibility.Visible;
        private Visibility _reviewButtonVisibility = Visibility.Visible;
        private Visibility _orderLabelVisibility = Visibility.Collapsed;
        private Visibility _reviewLabelVisibility = Visibility.Collapsed;
        private ObservableCollection<Review> _reviews = [];

        public ObservableCollection<Review> Reviews
        {
            get => _reviews;
            set
            {
                _reviews = value;
                OnPropertyChanged(nameof(Reviews));
            }
        }
        public Visibility OrderButtonVisibility
        {
            get => _orderButtonVisibility;
            set
            {
                _orderButtonVisibility = value;
                OnPropertyChanged();
            }
        }

        public Visibility OrderLabelVisibility
        {
            get => _orderLabelVisibility;
            set
            {
                _orderLabelVisibility = value;
                OnPropertyChanged();
            }
        }
        public Visibility ReviewButtonVisibility
        {
            get => _reviewButtonVisibility;
            set
            {
                _reviewButtonVisibility = value;
                OnPropertyChanged();
            }
        }

        public Visibility ReviewLabelVisibility
        {
            get => _reviewLabelVisibility;
            set
            {
                _reviewLabelVisibility = value;
                OnPropertyChanged();
            }
        }

        public Visibility PdfVisibility { get; set; } = Visibility.Visible;

        public ICommand OpenBookCommand { get; }
        public ICommand OrderBookCommand { get; }
        public ICommand GiveReviewCommand { get; }
        public ICommand ChangeLanguageEnCommand { get; }
        public ICommand ChangeLanguageRuCommand { get; }
        public BookPageForUserViewModel()
        {

            OrderBookCommand = new RelayCommand(OrderBookExecute, CanOrderBookExecute);
            
            OpenBookCommand = new RelayCommand(OpenBookExecute, CanOpenPageExecute);
            ChangeLanguageRuCommand = new RelayCommand(_ => LanguageManager.Instance.ChangeLanguage("ru-RU"));
            ChangeLanguageEnCommand = new RelayCommand(_ => LanguageManager.Instance.ChangeLanguage("en-US"));

            var test_author = new Author("Pudgo", "Pudgovanna");
            var test_Genre = new Genre("Dota 2");
            var test_Genre2 = new Genre("Momchik");
            var rev = new Review();
            CurrentBook = new Book();
            CurrentBook.Authors.Add(test_author);
            CurrentBook.Authors.Add(test_author);
            CurrentBook.Genres.Add(test_Genre);
            CurrentBook.Genres.Add(test_Genre2);
            CurrentBook.Rating = 8.677777;
            CurrentBook.FilePath = "";
            CurrentBook.Reviews.Add(rev);
            ImgSource = "../Resources/Images/BookImg/book.png";//std pic if no pic;
            OnPropertyChanged(nameof(ImgSource));


        }
        public BookPageForUserViewModel(Book currentBook,User currnetUser)
        {
            OrderBookCommand = new RelayCommand(OrderBookExecute, CanOrderBookExecute);
            
            OpenBookCommand = new RelayCommand(OpenBookExecute, CanOpenPageExecute);
            GiveReviewCommand = new RelayCommand(GiveReviewExecute, CanGiveReviewExecute);
            ChangeLanguageRuCommand = new RelayCommand(_ => LanguageManager.Instance.ChangeLanguage("ru-RU"));
            ChangeLanguageEnCommand = new RelayCommand(_ => LanguageManager.Instance.ChangeLanguage("en-US"));

            CurrentBook = currentBook;
            CurrnetUser = currnetUser;
            ImgSource = CurrentBook.ImgPath;

            if (GiveReviewCommand.CanExecute(currnetUser))
            {
                ReviewButtonVisibility = Visibility.Visible;
                ReviewLabelVisibility = Visibility.Collapsed;
            }
            else
            {
                ReviewButtonVisibility = Visibility.Collapsed;
                ReviewLabelVisibility = Visibility.Visible;
            }
            if (OrderBookCommand.CanExecute(currnetUser))
            {
                OrderButtonVisibility = Visibility.Visible;
                OrderLabelVisibility = Visibility.Collapsed;
            }
            else
            {
                OrderButtonVisibility = Visibility.Collapsed;
                OrderLabelVisibility = Visibility.Visible;
            }
            if(CurrentBook.FilePath == string.Empty)
            {
                PdfVisibility = Visibility.Collapsed;
            }
            _repository = App.ServiceProvider.GetRequiredService<Repository>();

            Reviews = new ObservableCollection<Review>(_repository.Reviews.GetReviewsByBookId(CurrentBook.Id).OrderBy(r => r.CreatedAt));
        }

        private void GiveReviewExecute(object? obj)
        {
            var win_vm = new ReviewAddBoxViewModel(CurrentBook, CurrnetUser)
            {
                _repository = _repository
            };
            var win = new ReviewAddBox()
            {
                DataContext = win_vm
            };
            win.ShowDialog();
            ReviewButtonVisibility = Visibility.Collapsed;
            ReviewLabelVisibility = Visibility.Visible;
            CurrentBook = _repository.Books.GetBookById(CurrentBook.Id);
            Reviews = new ObservableCollection<Review>(_repository.Reviews.GetReviewsByBookId(CurrentBook.Id).OrderBy(r => r.CreatedAt));
            OnPropertyChanged(nameof(CurrentBook));
            OnPropertyChanged(nameof(Reviews));
        }

        private bool CanGiveReviewExecute(object? obj)
        {
            return CurrnetUser.Reviews.FirstOrDefault(r => r.BookId == CurrentBook.Id) is null;
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
        private void OrderBookExecute(object? obj)
        {
            if (CurrnetUser.ActiveBooks.Count > 5)
            {
                ShowError("На данный момент у вас уже взято слишком много книг(5 и более)");
                return;
            }
            if (CurrnetUser.ActiveBooks.FirstOrDefault(b=>b.BookId == CurrentBook.Id) is not null)
            {
                ShowError("На данный момент у вас уже взята данная книга");
                return;
            }
            var new_order = new Order();
            new_order.UserId = CurrnetUser.Id;
            new_order.BookId = CurrentBook.Id;
            CurrentBook.AmountAvailible -= 1;
            _repository.Books.UpdateBook(CurrentBook.Id, CurrentBook);
            _repository.Orders.AddOrder(new_order);
            CurrnetUser = _repository.Users.GetUserByCardId(CurrnetUser.CardId);
            CurrentBook = _repository.Books.GetBookById(CurrentBook.Id);
            OnPropertyChanged(nameof(CurrnetUser));
            OnPropertyChanged(nameof(CurrentBook));
            OrderButtonVisibility = Visibility.Collapsed;
            OrderLabelVisibility = Visibility.Visible;


        }

        private bool CanOrderBookExecute(object? obj)
        {
            return CurrentBook.IsAvailible && CurrnetUser.ActiveBooks.FirstOrDefault(r => r.BookId == CurrentBook.Id) is null;
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
