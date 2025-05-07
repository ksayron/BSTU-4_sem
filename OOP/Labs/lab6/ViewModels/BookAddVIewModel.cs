using Lab4_5.Modules.DAL;
using Lab4_5.Modules.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Lab4_5.Modules.ViewModel;
using Lab4_5.Modules.View;
using System.Diagnostics.Metrics;
using System.Collections.ObjectModel;
using System.Windows;
using static Lab4_5.ViewModels.EditBookViewModel;

namespace Lab4_5.ViewModels
{
    public class BookAddVIewModel:BaseViewModel
    {
        Repository _repository;
        public string Title { get; set; } = "";
        public string ShortDescription { get; set; } = "";
        public string Description { get; set; } = "";
        public int Amount { get; set; } = 1;
        public ObservableCollection<AuthorSelection> AuthorSelections { get; set; } = [];
        public ObservableCollection<Author> Authors { get; set; }
        public ObservableCollection<GenreSelection> GenreSelections { get; set; } = [];
        public ObservableCollection<Genre> Genres { get; set; } = [];

        public ICommand AddBookCommand { get; }
        public ICommand AddAuthorComboCommand { get; }
        public ICommand AddGenreComboCommand { get; }
        public ICommand ChangeLanguageRuCommand { get; }
        public ICommand ChangeLanguageEnCommand { get; }
        public BookAddVIewModel()
        {
            AuthorSelections.Add(new AuthorSelection());

            GenreSelections.Add(new GenreSelection());

            AddBookCommand = new RelayCommand(AddBookExecute,CanAddBookExecute);
            AddAuthorComboCommand = new RelayCommand(_ => AuthorSelections.Add(new AuthorSelection()));
            AddGenreComboCommand = new RelayCommand(_ => GenreSelections.Add(new GenreSelection()));
            ChangeLanguageRuCommand = new RelayCommand(_ => LanguageManager.Instance.ChangeLanguage("ru-RU"));
            ChangeLanguageEnCommand = new RelayCommand(_ => LanguageManager.Instance.ChangeLanguage("en-US"));
        }
        public BookAddVIewModel(Repository repository)
        {
            _repository = repository;

            AuthorSelections.Add(new AuthorSelection());
            GenreSelections.Add(new GenreSelection());

            AddBookCommand = new RelayCommand(AddBookExecute, CanAddBookExecute);
            AddAuthorComboCommand = new RelayCommand(_ => AuthorSelections.Add(new AuthorSelection()));
            AddGenreComboCommand = new RelayCommand(_ => GenreSelections.Add(new GenreSelection()));
            ChangeLanguageRuCommand = new RelayCommand(_ => LanguageManager.Instance.ChangeLanguage("ru-RU"));
            ChangeLanguageEnCommand = new RelayCommand(_ => LanguageManager.Instance.ChangeLanguage("en-US"));

            Authors = new ObservableCollection<Author>(_repository.GetAllAuthors());                          
            Genres = new ObservableCollection<Genre>(_repository.GetAllGenres());
        }

        

        private void AddBookExecute(object? obj)
        {
            var book = new Book();
            book.Title = Title;
            book.AmountAvailible = Amount;
            book.Description = Description;
            book.SmallDescription = ShortDescription;
            book.Authors  = AuthorSelections.Where(a => a.SelectedAuthor != null).Select(a => a.SelectedAuthor!).ToList();
            book.Genres = GenreSelections.Where(g => g.SelectedGenre != null).Select(g => g.SelectedGenre!).ToList();
            if(_repository.AddBook(book))
            {
                Close(obj);
            }
        }
        private bool CanAddBookExecute(object? obj)
        {
            return Title!= "";//validation logic
        }
        private void ShowError(string message)
        {
            var msgBox = new Message("Ошибка при входе", message);
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
    public class AuthorSelection : BaseViewModel
    {
        private Author? _selectedAuthor;
        public Author? SelectedAuthor
        {
            get => _selectedAuthor;
            set
            {
                _selectedAuthor = value;
                OnPropertyChanged();
            }
        }
    }
    public class GenreSelection : BaseViewModel
    {
        private Genre? _selectedGenre;
        public Genre? SelectedGenre
        {
            get => _selectedGenre;
            set
            {
                _selectedGenre = value;
                OnPropertyChanged();
            }
        }
    }
}
