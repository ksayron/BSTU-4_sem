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
using System.Net.Http;
using System.IO;
using Microsoft.Extensions.DependencyInjection;
using KNP_Library.Views;
using Lab4_5.Modules.ViewModel;

namespace KNP_Library.ViewModels
{
    public class BookAddVIewModel:BaseViewModel
    {
        Repository _repository;
        public UndoRedoManager Manager { get; set; }
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
        public BookAddVIewModel()
        {
            AuthorSelections.Add(new AuthorSelection());

            GenreSelections.Add(new GenreSelection());

            AddBookCommand = new RelayCommand(AddBookExecute,CanAddBookExecute);
            AddAuthorComboCommand = new RelayCommand(_ => AuthorSelections.Add(new AuthorSelection()));
            AddGenreComboCommand = new RelayCommand(_ => GenreSelections.Add(new GenreSelection()));
            ChangeLanguageRuCommand = new RelayCommand(_ => LanguageManager.Instance.ChangeLanguage("ru-RU"));
            ChangeLanguageEnCommand = new RelayCommand(_ => LanguageManager.Instance.ChangeLanguage("en-US"));
            SelectImageCommand = new RelayCommand(_ => UploadFile("image"));
            SelectPdfCommand = new RelayCommand(_ => UploadFile("pdf"));
            ImagePath = "../Resources/Images/BookImg/book.png";
        }
        public BookAddVIewModel(Repository repository)
        {
            _repository = repository;

            AuthorSelections.Add(new AuthorSelection());
            GenreSelections.Add(new GenreSelection());

            AddBookCommand = new RelayCommand(AddBookExecute, CanAddBookExecute);
            AddAuthorCommand = new RelayCommand(AddAuthorExecute, CanAddAuthorExecute);
            AddGenreСommand = new RelayCommand(AddGenreExecute, CanAddAuthorExecute);
            AddAuthorComboCommand = new RelayCommand(_ => AuthorSelections.Add(new AuthorSelection()));
            AddGenreComboCommand = new RelayCommand(_ => GenreSelections.Add(new GenreSelection()));
            ChangeLanguageRuCommand = new RelayCommand(_ => LanguageManager.Instance.ChangeLanguage("ru-RU"));
            ChangeLanguageEnCommand = new RelayCommand(_ => LanguageManager.Instance.ChangeLanguage("en-US"));
            SelectImageCommand = new RelayCommand(_ => UploadFile("image"));
            SelectPdfCommand = new RelayCommand(_ => UploadFile("pdf"));
            ImagePath = "../Resources/Images/BookImg/book.png";

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

        private void AddBookExecute(object? obj)
        {
            var book = new Book();
            book.Title = Title;
            book.AmountAvailible = Amount;
            book.Description = Description;
            book.SmallDescription = ShortDescription;
            book.Authors  = AuthorSelections.Where(a => a.SelectedAuthor != null).Select(a => a.SelectedAuthor!).ToList();
            book.Genres = GenreSelections.Where(g => g.SelectedGenre != null).Select(g => g.SelectedGenre!).ToList();
            book.ImgPath = ImagePath ?? "";
            book.FilePath = PdfPath ?? "";
            if(book.Authors.Count == 0)
            {
                var mes = new Message("Ошибка добавления книги", "Добавтье автора");
                mes.ShowDialog();
                return;
            }
            if (book.Genres.Count == 0)
            {
                var mes = new Message("Ошибка добавления книги", "Добавтье жанр");
                mes.ShowDialog();
                return;
            }
            Manager.ExecuteCommand(new AddBookCommand(_repository.Books, book));
            Close(obj);
            
        }
        private bool CanAddBookExecute(object? obj)
        {
            return Title!= "" && Amount>0;//validation logic
        }
        private void ShowError(string message)
        {
            var msgBox = new Message("Ошибка при добавлении", message);
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
                            if (type == "image") 
                            {
                                ImagePath = result.path;
                                OnPropertyChanged(nameof(ImagePath)); 
                            }

                            else
                            {
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
