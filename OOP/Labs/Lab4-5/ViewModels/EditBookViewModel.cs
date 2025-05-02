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
    internal class EditBookViewModel : BaseViewModel
    {
        Repository _repository;
        public Book CurrentBook; 
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
        public EditBookViewModel()
        {
            var test_author = new Author("Pudgo", "Pudgovanna");
            var test_Genre = new Genre("Dota 2");
            var test_Genre2 = new Genre("Momchik");
            CurrentBook = new Book();
            CurrentBook.Authors.Add(test_author);
            CurrentBook.Authors.Add(test_author);
            CurrentBook.Genres.Add(test_Genre);
            CurrentBook.Genres.Add(test_Genre2);

            foreach (var author in CurrentBook.Authors)
            {
                AuthorSelections.Add(new AuthorSelection { SelectedAuthor = author });
            }
            foreach (var genre in CurrentBook.Genres)
            {
                GenreSelections.Add(new GenreSelection { SelectedGenre = genre });
            }
            OnPropertyChanged(nameof(AuthorSelections));
            OnPropertyChanged(nameof(GenreSelections));

            AddBookCommand = new RelayCommand(AddBookExecute, CanAddBookExecute);
            AddAuthorComboCommand = new RelayCommand(_ => AuthorSelections.Add(new AuthorSelection()));
            AddGenreComboCommand = new RelayCommand(_ => GenreSelections.Add(new GenreSelection()));
            ChangeLanguageRuCommand = new RelayCommand(_ => LanguageManager.Instance.ChangeLanguage("ru-RU"));
            ChangeLanguageEnCommand = new RelayCommand(_ => LanguageManager.Instance.ChangeLanguage("en-US"));


        }
        public EditBookViewModel(Repository repository, Book book)
        {
            _repository = repository;
            CurrentBook = book;

            Title = book.Title;
            OnPropertyChanged(nameof(Title));

            ShortDescription = book.SmallDescription;
            OnPropertyChanged(nameof(ShortDescription));
            Description = book.Description;
            OnPropertyChanged(nameof(Description));

            Amount = book.AmountAvailible;
            OnPropertyChanged(nameof(Amount));


            foreach (var author in CurrentBook.Authors)
            {
                AuthorSelections.Add(new AuthorSelection { SelectedAuthor = author });
            }
            foreach (var genre in CurrentBook.Genres)
            {
                GenreSelections.Add(new GenreSelection { SelectedGenre = genre });
            }
            OnPropertyChanged(nameof(AuthorSelections));
            OnPropertyChanged(nameof(GenreSelections));

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
            CurrentBook.Title = Title;
            CurrentBook.AmountAvailible = Amount;
            CurrentBook.Description = Description;
            CurrentBook.SmallDescription = ShortDescription;
            CurrentBook.Authors = AuthorSelections.Where(s => s.SelectedAuthor != null).Select(s => s.SelectedAuthor!).ToList();

            CurrentBook.Genres = GenreSelections.Where(s => s.SelectedGenre != null).Select(s => s.SelectedGenre!).ToList();
            if (_repository.UpdateBook(CurrentBook.Id,CurrentBook))
            {
                Close(obj);
            }
        }
        private bool CanAddBookExecute(object? obj)
        {
            return Title != "";//validation logic
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
}
