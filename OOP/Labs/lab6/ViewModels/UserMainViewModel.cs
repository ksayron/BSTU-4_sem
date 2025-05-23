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

namespace KNP_Library.ViewModels
{
    public class UserMainViewModel :BaseViewModel
    {
        public User CurrnetUser { get; set; }
        public Author FilterAuthor { get; set; }
        public Genre FilterGenre { get; set; }
        public string SearchQuery { get; set; } = "Search...";

        Repository _repository;

        public ICommand OpenBookPageCommand { get; }
        public ICommand OpenUserPageCommand { get; }
        public ICommand OpenMyProfileCommand { get; }
        public ICommand ApplyFilterCommand { get; }
        public ICommand ApplySearchCommand { get; }
        public ICommand ChangeLanguageRuCommand { get; }
        public ICommand ChangeLanguageEnCommand { get; }
        public ICommand ExitCommand { get; }
        public UserMainViewModel()
        {
            //_repository = repository;
            CurrnetUser = new User();

            OpenBookPageCommand = new RelayCommand(OpenBookPageExecute, CanOpenBookPageExecute);
            OpenMyProfileCommand = new RelayCommand(OpenMyProfileExecute);
            ApplyFilterCommand = new RelayCommand(ApplyFilterExecute);
            ApplySearchCommand = new RelayCommand(ApplySearchExecute);
            ChangeLanguageRuCommand = new RelayCommand(_ => LanguageManager.Instance.ChangeLanguage("ru-RU"));
            ChangeLanguageEnCommand = new RelayCommand(_ => LanguageManager.Instance.ChangeLanguage("en-US"));
            ExitCommand = new RelayCommand(ExitExecute);

            Author none_option_author = new Author("none", "");
            Genre none_option_genre = new Genre("none");
            var test_book = new Book();
            Books = [];
            Books.Add(test_book);
            Authors = [];
            Authors.Add(none_option_author);
            Genres = [];
            Genres.Add(none_option_genre);

        }



        public UserMainViewModel(Repository repository)
        {
            _repository = repository;
            CurrnetUser = new User();

            OpenBookPageCommand = new RelayCommand(OpenBookPageExecute, CanOpenBookPageExecute);
            OpenMyProfileCommand = new RelayCommand(OpenMyProfileExecute);
            ApplyFilterCommand = new RelayCommand(ApplyFilterExecute);
            ApplySearchCommand = new RelayCommand(ApplySearchExecute);
            ChangeLanguageRuCommand = new RelayCommand(_ => LanguageManager.Instance.ChangeLanguage("ru-RU"));
            ChangeLanguageEnCommand = new RelayCommand(_ => LanguageManager.Instance.ChangeLanguage("en-US"));
            ExitCommand = new RelayCommand(ExitExecute);

            Books = new ObservableCollection<Book>(_repository.Books.GetAllBooks());


            Author none_option_author = new Author("none", "");
            Genre none_option_genre = new Genre("none");
            Authors = new ObservableCollection<Author>(_repository.AuthorsGenres.GetAllAuthors());
            Authors.Add(none_option_author);
            Genres = new ObservableCollection<Genre>(_repository.AuthorsGenres.GetAllGenres());
            Genres.Add(none_option_genre);

        }



        private void OpenMyProfileExecute(object? obj)
        {
            var user_page_vm = new UserPageForUserViewModel(CurrnetUser)
            {
                _repository = _repository
            };
            var user_page = new UserPageForUser()
            {
                DataContext = user_page_vm,
            };
            user_page.ShowDialog();
            OnPropertyChanged(nameof(CurrnetUser));
        }

        private void ApplyFilterExecute(object? obj)
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
            if (SearchQuery != "Search...")
            {
                new_books = new ObservableCollection<Book>(new_books.Where(b => b.Title.Contains(SearchQuery)).ToList());
            }
            Books = new_books;
            OnPropertyChanged(nameof(Books));
        }


        private void OpenBookPageExecute(object? obj)
        {
            var what_is = obj.GetType();
            if (obj is Book book)
            {
                
                var book_page_vm = new BookPageForUserViewModel(book, CurrnetUser)
                {
                    _repository = _repository
                };
                
                var book_page = new BookPageForUser()
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
                    PropertyChanged(this, new PropertyChangedEventArgs("Books"));
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
                    PropertyChanged(this, new PropertyChangedEventArgs("Books"));
                }
            }
        }
        public event PropertyChangedEventHandler? PropertyChanged = delegate { };

    }
}
