using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab4_5.Modules.classes;
using Lab4_5.Modules.DAL;
using Lab4_5.Modules.View;
using Lab4_5.Modules.ViewModel;
using Lab4_5;
using System.DirectoryServices;
using Lab4_5.Modules.Interfaces;
using System.Windows.Input;
using Microsoft.Extensions.DependencyInjection;

namespace Lab4_5.ViewModels
{
    public class AdminMainViewModel : BaseViewModel
    {
        public User CurrnetUser { get; set; }
        public Author FilterAuthor { get; set; }
        public Genre FilterGenre { get; set; }

        Repository _repository;
        public ICommand AddBookCommand { get; }
        public ICommand EditBookCommand { get; }
        public ICommand DeleteBookCommand { get; }
        public ICommand OpenBookPageCommand { get; }
        public ICommand OpenHomeCommand { get; }
        public ICommand OpenMyProfileCommand { get; }
        public ICommand OpenUserTableCommand { get; }
        public ICommand OpenBookTableCommand { get; }
        public ICommand ApplyFilterCommand { get; }
        public ICommand ChangeLanguageRuCommand { get; }
        public ICommand ChangeLanguageEnCommand { get; }
        public ICommand ExitCommand { get; }
        public AdminMainViewModel()
        {
            //_repository = repository;
            CurrnetUser = new User();

            AddBookCommand = new RelayCommand(AddBookExecute,canAddBookExecute);
            EditBookCommand = new RelayCommand(EditBookExecute, CanEditBookExecute);
            DeleteBookCommand = new RelayCommand(DeleteBookExecute, CanDeleteBookExecute);
            OpenBookPageCommand = new RelayCommand(OpenBookPageExecute, CanOpenBookPageExecute);
            OpenHomeCommand = new RelayCommand(OpenHomeExecute);
            OpenMyProfileCommand = new RelayCommand(OpenHomeExecute);
            OpenUserTableCommand = new RelayCommand(OpenHomeExecute);
            OpenBookTableCommand = new RelayCommand(OpenHomeExecute);
            ApplyFilterCommand = new RelayCommand(ApplyFilterExecute);
            ChangeLanguageRuCommand = new RelayCommand(_ => LanguageManager.Instance.ChangeLanguage("ru-RU"));
            ChangeLanguageEnCommand = new RelayCommand(_ => LanguageManager.Instance.ChangeLanguage("en-US"));
            ExitCommand = new RelayCommand(ExitExecute);

            Author none_option_author = new Author("none", "");
            Genre none_option_genre = new Genre("none");
            Books = [];
            Users = [];
            Authors = [];
            Authors.Add(none_option_author);
            Genres = [];
            Genres.Add(none_option_genre);
        }

        

        public AdminMainViewModel(Repository repository)
        {
            _repository= repository;
            CurrnetUser = new User();

            AddBookCommand = new RelayCommand(AddBookExecute, canAddBookExecute);
            EditBookCommand = new RelayCommand(EditBookExecute,CanEditBookExecute);
            DeleteBookCommand = new RelayCommand(DeleteBookExecute,CanDeleteBookExecute);
            OpenBookPageCommand = new RelayCommand(OpenBookPageExecute,CanOpenBookPageExecute);
            OpenHomeCommand = new RelayCommand(OpenHomeExecute);
            OpenMyProfileCommand = new RelayCommand(OpenHomeExecute);
            OpenUserTableCommand = new RelayCommand(OpenHomeExecute);
            OpenBookTableCommand = new RelayCommand(OpenHomeExecute);
            ApplyFilterCommand = new RelayCommand(ApplyFilterExecute);
            ChangeLanguageRuCommand = new RelayCommand(_ => LanguageManager.Instance.ChangeLanguage("ru-RU"));
            ChangeLanguageEnCommand = new RelayCommand(_ => LanguageManager.Instance.ChangeLanguage("en-US"));
            ExitCommand = new RelayCommand(ExitExecute);

            Books = new ObservableCollection<Book>(_repository.GetAllBooks());
            Users = new ObservableCollection<User>(_repository.GetAllUsers());

            Author none_option_author = new Author("none", "");
            Genre none_option_genre = new Genre("none");
            Authors = new ObservableCollection<Author>(_repository.GetAllAuthors());
            Authors.Add(none_option_author);
            Genres = new ObservableCollection<Genre>(_repository.GetAllGenres());
            Genres.Add(none_option_genre);
        }

        private void AddBookExecute(object? obj)
        {
            var win = App.ServiceProvider.GetRequiredService<BookAddBox>();
            win.ShowDialog();
            Books = new ObservableCollection<Book>(_repository.GetAllBooks());
        }
        private bool canAddBookExecute(object? obj)
        {
            return Books is not null;
        }
        private void EditBookExecute(object? obj)
        {
            throw new NotImplementedException();
        }
        
        private bool CanEditBookExecute(object? obj)
        {
            throw new NotImplementedException();
        }

        private void DeleteBookExecute(object? obj)
        {
            throw new NotImplementedException();
        }

        private bool CanDeleteBookExecute(object? obj)
        {
            throw new NotImplementedException();
        }
        private void ApplyFilterExecute(object? obj)
        {
            var new_books = Books;
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

        private void OpenHomeExecute(object? obj)
        {

        }
        private void OpenBookPageExecute(object? obj)
        {
            var what_is = obj.GetType();
            var mes = new Message("fix", "pls");
        }
        private bool CanOpenBookPageExecute(object? obj)
        {

            return Books is not null;
        }
        private void ExitExecute(object? obj)
        {
            throw new NotImplementedException();
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
        private void OnDelete()
        {

        }
        private bool CanDelete()
        {
            return true;
        }
        //public Commands DeleteCommand = new RelayCommand(OnDelete, CanDelete);

    }
}
