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
using System.Windows;
using Lab4_5.Views;
using Lab4_5.Modules.DAL;
using Lab4_5.Modules.ViewModel;

namespace KNP_Library.ViewModels
{
    public class AdminMainViewModel : BaseViewModel
    {
        public User CurrnetUser { get; set; }
        public Author FilterAuthor { get; set; }
        public Genre FilterGenre { get; set; }
        public string SearchQuery { get; set; } = "Search...";
        public string UserSearchQuery { get; set; } = "User Search...";

        public string BookNameSearch { get; set; } = "";
        public int UserCardIdSearch { get; set; } = 0;

        private Visibility _booksVisibility = Visibility.Visible;
        private Visibility _usersVisibility = Visibility.Collapsed;
        private Visibility _ordersVisibility = Visibility.Collapsed;
        public Visibility BooksVisibility
        {
            get => _booksVisibility;
            set
            {
                _booksVisibility = value;
                OnPropertyChanged();
            }
        }

        public Visibility UsersVisibility
        {
            get => _usersVisibility;
            set
            {
                _usersVisibility = value;
                OnPropertyChanged();
            }
        }
        public Visibility OrdersVisibility
        {
            get => _ordersVisibility;
            set
            {
                _ordersVisibility = value;
                OnPropertyChanged();
            }
        }



        Repository _repository;
        UndoRedoManager manager = new UndoRedoManager();
        public ICommand AddBookCommand { get; }
        public ICommand EditBookCommand { get; }
        public ICommand DeleteBookCommand { get; }

        public ICommand AddUserCommand { get; }
        public ICommand EditUserCommand { get; }
        public ICommand DeleteUserCommand { get; }

        public ICommand AddNotificationCommand { get; }
        public ICommand CloseOrderCommand { get; }


        public ICommand OpenBookPageCommand { get; }
        public ICommand OpenUserPageCommand { get; }
        public ICommand OpenOrderPageCommand { get; }

        public ICommand OpenMyProfileCommand { get; }

        public ICommand OpenUserTableCommand { get; }
        public ICommand OpenBookTableCommand { get; }
        public ICommand OpenOrderTableCommand { get; }
        public ICommand OpenNotificationTableCommand { get; }

        public ICommand ApplyFilterCommand { get; }
        public ICommand ApplySearchCommand { get; }
        public ICommand ApplyUserSearchCommand { get; }
        public ICommand ApplyOrderSearchCommand { get; }

        public ICommand ChangeLanguageRuCommand { get; }
        public ICommand ChangeLanguageEnCommand { get; }
        public ICommand ChangeThemeCommand { get; }
        public ICommand UndoCommand { get; }
        public ICommand RedoCommand { get; }

        public ICommand ExitCommand { get; }
        public ICommand SpamCommand { get; }
        public AdminMainViewModel()
        {
            //_repository = repository;
            CurrnetUser = new User();

            AddBookCommand = new RelayCommand(AddBookExecute,canAddBookExecute);
            EditBookCommand = new RelayCommand(EditBookExecute, CanEditBookExecute);
            DeleteBookCommand = new RelayCommand(DeleteBookExecute, CanDeleteBookExecute);

            AddUserCommand = new RelayCommand(AddBookExecute, canAddBookExecute);
            EditUserCommand = new RelayCommand(EditBookExecute, CanEditBookExecute);
            DeleteUserCommand = new RelayCommand(DeleteBookExecute, CanDeleteBookExecute);

            OpenBookPageCommand = new RelayCommand(OpenBookPageExecute, CanOpenBookPageExecute);
            OpenUserPageCommand = new RelayCommand(OpenUserPageExecute, CanOpenUserPageExecute);

            OpenMyProfileCommand = new RelayCommand(OpenMyProfileExecute);

            OpenUserTableCommand = new RelayCommand(OpenUsersExecute);
            OpenBookTableCommand = new RelayCommand(OpenBooksExecute);

            ApplyFilterCommand = new RelayCommand(ApplyFilterExecute);
            ApplySearchCommand = new RelayCommand(ApplySearchExecute);

            ApplyUserSearchCommand = new RelayCommand(ApplyUserSearchExecute);

            ChangeLanguageRuCommand = new RelayCommand(_ => LanguageManager.Instance.ChangeLanguage("ru-RU"));
            ChangeLanguageEnCommand = new RelayCommand(_ => LanguageManager.Instance.ChangeLanguage("en-US"));
            ExitCommand = new RelayCommand(ExitExecute);
            SpamCommand = new RelayCommand(SpamExecute);

            Author none_option_author = new Author("none", "");
            Genre none_option_genre = new Genre("none");
            Books = [];
            Users = [];
            Authors = [];
            Authors.Add(none_option_author);
            Genres = [];
            Genres.Add(none_option_genre);

            UsersVisibility = Visibility.Collapsed;
            BooksVisibility = Visibility.Visible;
            OrdersVisibility = Visibility.Collapsed;
        }

        private void SpamExecute(object? obj)
        {
            using(var unitOfWork = new UnitOfWork() )
            {
                
                var book = new Book { Title = "Spam book" ,Genres=new List<Genre>(Genres),Authors=new List<Author>(Authors),Description="SpamSpamSpam",SmallDescription="Spam",AmountAvailible=100,Rating=0.0 };
                
                unitOfWork.Books.AddBook(book);

                var review = new Review
                {
                    BookId = unitOfWork.Books.GetBookIdByName(book.Title),
                    Assessment = 10,
                    UserId = 2
                };
                unitOfWork.Complete();
            }
            OnPropertyChanged(nameof(Books));
        }

        public AdminMainViewModel(Repository repository)
        {
            _repository= repository;
            CurrnetUser = new User();

            AddBookCommand = new RelayCommand(AddBookExecute, canAddBookExecute);
            EditBookCommand = new RelayCommand(EditBookExecute, CanEditBookExecute);
            DeleteBookCommand = new RelayCommand(DeleteBookExecute, CanDeleteBookExecute);

            AddUserCommand = new RelayCommand(AddUserExecute, canAddUserExecute);
            EditUserCommand = new RelayCommand(EditUserExecute, CanEditUserExecute);
            DeleteUserCommand = new RelayCommand(DeleteUserExecute, CanDeleteUserExecute);

            AddNotificationCommand = new RelayCommand(AddNotificationExecute);
            CloseOrderCommand = new RelayCommand(CloseOrderExecute, CanCloseOrderExecute);

            OpenBookPageCommand = new RelayCommand(OpenBookPageExecute, CanOpenBookPageExecute);
            OpenUserPageCommand = new RelayCommand(OpenUserPageExecute, CanOpenUserPageExecute);

            OpenMyProfileCommand = new RelayCommand(OpenMyProfileExecute);

            OpenUserTableCommand = new RelayCommand(OpenUsersExecute);
            OpenBookTableCommand = new RelayCommand(OpenBooksExecute);
            OpenOrderTableCommand = new RelayCommand(OpenOrderExecute);
            OpenNotificationTableCommand = new RelayCommand(OpenNotificationExecute);

            ApplyFilterCommand = new RelayCommand(ApplyFilterExecute);
            ApplySearchCommand = new RelayCommand(ApplySearchExecute);
            ApplyUserSearchCommand = new RelayCommand(ApplyUserSearchExecute);
            ApplyOrderSearchCommand = new RelayCommand(ApplyOrderSearchExecute, CanApplyOrderSearchExecute);

            ChangeLanguageRuCommand = new RelayCommand(_ => LanguageManager.Instance.ChangeLanguage("ru-RU"));
            ChangeLanguageEnCommand = new RelayCommand(_ => LanguageManager.Instance.ChangeLanguage("en-US"));
            ChangeThemeCommand = new RelayCommand(_ => LanguageManager.Instance.ToggleTheme());
            
            UndoCommand = new RelayCommand(
                _ => {
                    manager.Undo();
                    Books = new ObservableCollection<Book>(_repository.Books.GetAllBooks());
                    OnPropertyChanged(nameof(Books));
            },
            _=>manager.UndoStackCount>0);
            RedoCommand = new RelayCommand(_ => { 
                manager.Redo();
                Books = new ObservableCollection<Book>(_repository.Books.GetAllBooks());
                OnPropertyChanged(nameof(Books)); },
                _=>manager.RedoStackCount>0);

            ExitCommand = new RelayCommand(ExitExecute);

            Books = new ObservableCollection<Book>(_repository.Books.GetAllBooks());
            Users = new ObservableCollection<User>(_repository.Users.GetAllUsers());
            Orders = new ObservableCollection<Order>(_repository.Orders.GetAllOrders());

            Author none_option_author = new Author("none", "");
            Genre none_option_genre = new Genre("none");
            Authors = new ObservableCollection<Author>(_repository.AuthorsGenres.GetAllAuthors());
            Authors.Add(none_option_author);
            Genres = new ObservableCollection<Genre>(_repository.AuthorsGenres.GetAllGenres());
            Genres.Add(none_option_genre);
            UsersVisibility = Visibility.Collapsed;
            OrdersVisibility = Visibility.Collapsed;
            BooksVisibility = Visibility.Visible;
        }

        private void OpenNotificationExecute(object? obj)
        {
            var notif_add_vm = new NotificationDataGrid(_repository);
            
            var notif_add = new Lab4_5.Views.NotificationDataGrid()
            {
                DataContext = notif_add_vm
            };
            notif_add.ShowDialog();
        }

        private void AddNotificationExecute(object? obj)
        {
            var notif_add_vm = new NotificationAddBoxViewModel()
            {
                _repository = _repository,
            };
            var notif_add = new NotificationAddBox()
            {
                DataContext = notif_add_vm
            };
            notif_add.ShowDialog();
        }

        private void CloseOrderExecute(object? obj)
        {
            if(obj is Order order)
            {
                order.CloseOrder();
                var book = _repository.Books.GetBookById(order.BookId);
                book.AmountAvailible += 1;
                _repository.Orders.UpdateOrderById(order.OrderId, order);
                _repository.Books.UpdateBook(book.Id, book);
                ApplyOrderSearchExecute(obj);
            }
        }

        private bool CanCloseOrderExecute(object? obj)
        {
            if(obj is Order order)
            {
                return order.IsActive;
            }
            return false;
        }

        private void ApplyOrderSearchExecute(object? obj)
        {
            var new_orders = new ObservableCollection<Order>(_repository.Orders.GetAllOrders());
            if (BookNameSearch != "")
            {
                new_orders = new ObservableCollection<Order>(new_orders.Where(b => b.Book.Title.Contains(BookNameSearch)).ToList()); 
            }
            if (UserCardIdSearch > 99999 & UserCardIdSearch < 1000000)
            {
                new_orders = new ObservableCollection<Order>(new_orders.Where(b => b.User.CardId==UserCardIdSearch));
            }
            Orders = new_orders;
            OnPropertyChanged(nameof(Orders));
        }

        private bool CanApplyOrderSearchExecute(object? obj)
        {
            return true;
        }
        private void OpenOrderExecute(object? obj)
        {
            UsersVisibility = Visibility.Collapsed;
            OrdersVisibility = Visibility.Visible;
            BooksVisibility = Visibility.Collapsed;
        }

        private void OpenUserPageExecute(object? obj)
        {
            if(obj is User user)
            {
                bool isSelf = false;
                if(user.Id == CurrnetUser.Id)
                {
                    isSelf = true;
                }
                var user_page_vm = new UserPageViewModel(user) 
                {
                    IsSelf = isSelf,
                    _repository = _repository 
                };
                var user_page = new UserPage()
                {
                    DataContext = user_page_vm,
                };
                user_page.ShowDialog();
            }
            ApplyUserSearchExecute(obj);
            OnPropertyChanged(nameof(Users));
        }

        private bool CanOpenUserPageExecute(object? obj)
        {
            return Users is not null;
        }

        private void OpenBooksExecute(object? obj)
        {
            UsersVisibility = Visibility.Collapsed;
            OrdersVisibility = Visibility.Collapsed;
            BooksVisibility = Visibility.Visible;
        }

        private void OpenUsersExecute(object? obj)
        {
            UsersVisibility = Visibility.Visible;
            BooksVisibility = Visibility.Collapsed;
            OrdersVisibility = Visibility.Collapsed;
        }

        private void OpenMyProfileExecute(object? obj)
        {
            
                
                var user_page_vm = new UserPageViewModel(CurrnetUser)
                {
                    IsSelf = true,
                    _repository = _repository
                };
                var user_page = new UserPage()
                {
                    DataContext = user_page_vm,
                };
                user_page.ShowDialog();
            
            ApplyUserSearchExecute(obj);
            OnPropertyChanged(nameof(Users));
        }

        private void AddBookExecute(object? obj)
        {
            var win_vm = App.ServiceProvider.GetRequiredService<BookAddVIewModel>();
            win_vm.Manager = manager;
            var win = new BookAddBox()
            {
                DataContext = win_vm
            };
            win.ShowDialog();
            if(win.DataContext is BookAddVIewModel vm)
            {
                manager = vm.Manager;
            }
            Books = new ObservableCollection<Book>(_repository.Books.GetAllBooks());
            OnPropertyChanged(nameof(Books));
        }
        private bool canAddBookExecute(object? obj)
        {
            return Books is not null;
        }

        private void AddUserExecute(object? obj)
        {
            var win_vm = App.ServiceProvider.GetRequiredService<UserAddBoxViewModel>();
            var win = new UserAddBox()
            {
                DataContext = win_vm
            };
            win.ShowDialog();
            ApplyUserSearchExecute(obj);
            OnPropertyChanged(nameof(Users));
        }
        private bool canAddUserExecute(object? obj)
        {
            return Users is not null;
        }
        private void EditBookExecute(object? obj)
        {
            if(obj is Book book){var repository = App.ServiceProvider.GetRequiredService<Repository>();
            var win_vm = new EditBookViewModel(repository, book);
            win_vm.Manager = manager;
            var win = new EditBook()
            {
                DataContext = win_vm
            };
            win.ShowDialog();
            if (win.DataContext is BookAddVIewModel vm)
            {
                manager = vm.Manager;
            }
                Books = new ObservableCollection<Book>(_repository.Books.GetAllBooks());
                OnPropertyChanged(nameof(Books));
            }
        }
        
        private bool CanEditBookExecute(object? obj)
        {
            return Books is not null;
        }

        private void EditUserExecute(object? obj)
        {
            if (obj is User user)
            {

                var user_page_vm = new UserEditBoxViewModel(user)
                {
                    _repository = _repository
                };
                var user_page = new UserEditBox()
                {
                    DataContext = user_page_vm,
                };
                user_page.ShowDialog();
            }
            ApplyUserSearchExecute(obj);
            OnPropertyChanged(nameof(Users));
        }

        private bool CanEditUserExecute(object? obj)
        {
            if (obj is User user)
            {
                return user.Id != CurrnetUser.Id;
            }
            return Users is not null;
        }

        private void DeleteBookExecute(object? obj)
        {
            if(obj is Book book)
            {
                manager.ExecuteCommand(new DeleteBookCommand(_repository.Books, book));
                Books = new ObservableCollection<Book>(_repository.Books.GetAllBooks());
                OnPropertyChanged(nameof(Books)); 
            }
        }

        private bool CanDeleteBookExecute(object? obj)
        {
            return Books is not null;
        }

        private void DeleteUserExecute(object? obj)
        {
            if (obj is User user)
            {
                if(user.Id == CurrnetUser.Id)
                {
                    var mes = new Message("deletion error", "Нельзя удалить себя");
                }
                _repository.Users.DeleteUserById(user.Id);
                if (UserSearchQuery.Length > 0)
                {
                    var new_users = new ObservableCollection<User>(_repository.Users.GetAllUsers().Where(u => u.Username.Contains(UserSearchQuery)));
                    Users = new_users;
                }
                else
                {
                    var new_users = new ObservableCollection<User>(_repository.Users.GetAllUsers());
                    Users = new_users;
                }
                OnPropertyChanged(nameof(Users));
            }
        }

        private bool CanDeleteUserExecute(object? obj)
        {
            if(obj is User user)
            {
                return user.Id != CurrnetUser.Id;
            }
            return Users is not null;
        }
        private void ApplyFilterExecute(object? obj)
        {
            var new_books = new ObservableCollection<Book>(_repository.Books.GetAllBooks());
            if (FilterAuthor != null)
            {
                if(FilterAuthor.Name != "none") { new_books = new ObservableCollection<Book>(new_books.Where(b => b.Authors.Contains(FilterAuthor)).ToList()); }
            }
            if (FilterGenre != null )
            {
                if(FilterGenre.Name != "none") { new_books = new ObservableCollection<Book>(new_books.Where(b => b.Genres.Contains(FilterGenre)).ToList()); }
            }
            Books = new_books;
            OnPropertyChanged(nameof(Books));
        }
        private void ApplySearchExecute(object? obj)
        {
            var new_books = new ObservableCollection<Book>(_repository.Books.GetAllBooks());
            if (FilterAuthor != null)
            {
                if (FilterAuthor.Name != "none") { new_books = new ObservableCollection<Book>(new_books.Where(b => b.Authors.Contains(FilterAuthor)).ToList()); }
            }
            if (FilterGenre != null)
            {
                if (FilterGenre.Name != "none") { new_books = new ObservableCollection<Book>(new_books.Where(b => b.Genres.Contains(FilterGenre)).ToList()); }
            }
            if(SearchQuery!= "Search..."){ new_books = new ObservableCollection<Book>(new_books.Where(b => b.Title.Contains(SearchQuery)).ToList()); }
            Books = new_books;
            OnPropertyChanged(nameof(Books));
        }
        private void ApplyUserSearchExecute(object? obj)
        {
            var new_users = new ObservableCollection<User>(_repository.Users.GetAllUsers());
            if (UserSearchQuery != "User Search..."){
                 new_users = new ObservableCollection<User>(_repository.Users.GetAllUsers().Where(u => u.Username.Contains(UserSearchQuery))); 
            }

            Users = new_users;
            OnPropertyChanged(nameof(Users));
        }


        private void OpenBookPageExecute(object? obj)
        {
            var what_is = obj.GetType();
            if (obj is Book book)
            {
                var book_page_vm = new BookPageViewModel(book);
                var book_page = new BookPage()
                {
                    DataContext = book_page_vm
                };
                book_page.ShowDialog();
                OnPropertyChanged(nameof(Books));
            }
            else
            {
                var mes = new Message("fix", "pls");
                mes.Show();
            }
        }
        private bool CanOpenBookPageExecute(object? obj)
        {

            return Books is not null;
        }
        private void ExitExecute(object? obj)
        {
            var auth = App.ServiceProvider.GetRequiredService<Auth>();
            if (obj is Window currentWindow)
            {
                auth.Top = currentWindow.Top + 20;
                auth.Left = currentWindow.Left + 20;
                auth.Show();
                currentWindow.Close();
            }
        }
        public Order SelectedOrder;
        private ObservableCollection<Order> _orders;
        public ObservableCollection<Order> Orders
        {
            get { return _orders; }
            set
            {
                if (_orders != value)
                {
                    _orders = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("Orders"));
                }
            }
        }

        public User SelectedUser;
        private ObservableCollection<User> _users;
        public ObservableCollection<User> Users
        {
            get { return _users; }
            set
            {
                if(_users != value)
                {
                    _users = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("Users"));
                }
            }
        }
        public Book SelectedBook;
        private ObservableCollection<Book> _books;
        public ObservableCollection<Book> Books
        {
            get { return _books; }
            set
            {
                if (_books != value)
                {
                    _books = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("Books"));
                }
            }
        }
        private ObservableCollection<Genre> _genres;
        public ObservableCollection<Genre> Genres
        {
            get { return _genres; }
            set
            {
                if (_genres != value)
                {
                    _genres = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("Genres"));
                }
            }
        }
        private ObservableCollection<Author> _authors;
        public ObservableCollection<Author> Authors
        {
            get { return _authors; }
            set
            {
                if (_authors != value)
                {
                    _authors = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("Authors"));
                }
            }
        }
        public event PropertyChangedEventHandler? PropertyChanged = delegate { };
 
        public void ApplySearch(string query)
        {

        }
    }
}
