using KNP_Library.Modules.DAL;
using KNP_Library.Modules.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using KNP_Library.Modules.ViewModel;
using KNP_Library.Modules.View;
using System.Diagnostics.Metrics;
using System.Collections.ObjectModel;
using System.Windows;
using static KNP_Library.ViewModels.EditBookViewModel;
using KNP_Library.Modules.Interfaces;
using System.Net.Http;
using System.IO;
using KNP_Library.Views;
using Microsoft.Extensions.DependencyInjection;


namespace KNP_Library.ViewModels
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

        static HttpClientHandler handler = new HttpClientHandler
        {
            ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
        };

        HttpClient client = new HttpClient(handler);
        public string? ImagePath { get; set; }
        public string? PdfPath { get; set; }

        public ICommand AddBookCommand { get; }
        public ICommand AddAuthorComboCommand { get; }
        public ICommand AddAuthorCommand { get; }
        public ICommand AddGenreComboCommand { get; }
        public ICommand AddGenreСommand { get; }
        public ICommand ChangeLanguageRuCommand { get; }
        public ICommand ChangeLanguageEnCommand { get; }
        public ICommand SelectImageCommand { get; }
        public ICommand SelectPdfCommand { get; }
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
            SelectImageCommand = new RelayCommand(_ => UploadFile("image"));
            SelectPdfCommand = new RelayCommand(_ => UploadFile("pdf"));

            Title = CurrentBook.Title;
            OnPropertyChanged(nameof(Title));

            ShortDescription = CurrentBook.SmallDescription;
            OnPropertyChanged(nameof(ShortDescription));
            Description = CurrentBook.Description;
            OnPropertyChanged(nameof(Description));

            Amount = CurrentBook.AmountAvailible;
            OnPropertyChanged(nameof(Amount));

            ImagePath = CurrentBook.ImgPath;
            OnPropertyChanged(nameof(ImagePath));
            PdfPath = CurrentBook.FilePath;
            OnPropertyChanged(nameof(PdfPath));


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

            ImagePath = book.ImgPath;
            OnPropertyChanged(nameof(ImagePath));
            PdfPath = book.FilePath;
            OnPropertyChanged(nameof(PdfPath));

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
            AddAuthorCommand = new RelayCommand(AddAuthorExecute, CanAddAuthorExecute);
            AddGenreСommand = new RelayCommand(AddGenreExecute, CanAddAuthorExecute);
            ChangeLanguageRuCommand = new RelayCommand(_ => LanguageManager.Instance.ChangeLanguage("ru-RU"));
            ChangeLanguageEnCommand = new RelayCommand(_ => LanguageManager.Instance.ChangeLanguage("en-US"));
            SelectImageCommand = new RelayCommand(_ => UploadFile("image"));
            SelectPdfCommand = new RelayCommand(_ => UploadFile("pdf"));

            Authors = new ObservableCollection<Author>(_repository.AuthorsGenres.GetAllAuthors());
            Genres = new ObservableCollection<Genre>(_repository.AuthorsGenres.GetAllGenres());
            
        }

        private void AddGenreExecute(object? obj)
        {
            var win_vm = App.ServiceProvider.GetRequiredService<GenreAddBoxViewModel>();
            var win = new GenreAddBox()
            {
                DataContext = win_vm
            };
            win.ShowDialog();
            Genres = new ObservableCollection<Genre>(_repository.AuthorsGenres.GetAllGenres());
            OnPropertyChanged(nameof(Genres));
        }

        private void AddAuthorExecute(object? obj)
        {
            var win_vm = App.ServiceProvider.GetRequiredService<AuthorAddBoxViewModel>();
            var win = new AuthorAddBox()
            {
                DataContext = win_vm
            };
            win.ShowDialog();
            Authors = new ObservableCollection<Author>(_repository.AuthorsGenres.GetAllAuthors());
            OnPropertyChanged(nameof(Authors));
        }

        private bool CanAddAuthorExecute(object? obj)
        {
            return _repository is not null;
        }

        private void UploadFile(string type)
        {
            var dialog = new Microsoft.Win32.OpenFileDialog
            {
                Filter = type == "image" ? "Image Files|*.jpg;*.png;*.jpeg" : "PDF Files|*.pdf"
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
                            if (type == "image") { ImagePath = result.path; OnPropertyChanged(nameof(ImagePath)); }
                            
                            else {
                                PdfPath = result.path;
                                OnPropertyChanged(nameof(PdfPath));
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

        private void AddBookExecute(object? obj)
        {
            CurrentBook.Title = Title;
            CurrentBook.AmountAvailible = Amount;
            CurrentBook.Description = Description;
            CurrentBook.SmallDescription = ShortDescription;
            CurrentBook.Authors = AuthorSelections.Where(s => s.SelectedAuthor != null).Select(s => s.SelectedAuthor!).ToList();
            CurrentBook.Genres = GenreSelections.Where(s => s.SelectedGenre != null).Select(s => s.SelectedGenre!).ToList();
            CurrentBook.ImgPath = ImagePath;
            CurrentBook.FilePath = PdfPath;
            if (_repository.Books.UpdateBook(CurrentBook.Id,CurrentBook))
            {
                Close(obj);
            }
        }
        private bool CanAddBookExecute(object? obj)
        {
            return Title != "" && Amount > 0;//validation logic
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
