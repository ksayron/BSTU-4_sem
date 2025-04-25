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

namespace Lab4_5.ViewModels
{
    public class BookAddVIewModel:BaseViewModel
    {
        Repository _repository;
        public string Title { get; set; } = "";
        public string ShortDescription { get; set; } = "";
        public string Description { get; set; } = "";
        public int Amount { get; set; } = 1;
        public ObservableCollection<Author> SelectedAuthors { get; set; } = [];
        public ObservableCollection<Author> Authors { get; set; }
        public List<Author> Authors_l { get; set; } = [];
        public ObservableCollection<Genre> SelectedGenres { get; set; } = [];
        public ObservableCollection<Genre> Genres { get; set; } = [];
        public List<Genre> Genres_l { get; set; } = [];
        public List<string> test = new List<string> { "123", "23" };

        public ICommand AddBookCommand { get; }
        public ICommand AddAuthorComboCommand { get; }
        public ICommand AddGenreComboCommand { get; }
        public ICommand ChangeLanguageRuCommand { get; }
        public ICommand ChangeLanguageEnCommand { get; }
        public BookAddVIewModel()
        {
            SelectedAuthors.Add(null);

            SelectedGenres.Add(null);

            AddBookCommand = new RelayCommand(AddBookExecute,CanAddBookExecute);
            AddAuthorComboCommand = new RelayCommand(_ => SelectedAuthors.Add(null));
            AddGenreComboCommand = new RelayCommand(_ => SelectedGenres.Add(null));
            ChangeLanguageRuCommand = new RelayCommand(_ => LanguageManager.Instance.ChangeLanguage("ru-RU"));
            ChangeLanguageEnCommand = new RelayCommand(_ => LanguageManager.Instance.ChangeLanguage("en-US"));
        }
        public BookAddVIewModel(Repository repository)
        {
            _repository = repository;

            SelectedAuthors.Add(null);
            SelectedGenres.Add(null);

            AddBookCommand = new RelayCommand(AddBookExecute, CanAddBookExecute);
            AddAuthorComboCommand = new RelayCommand(_ => SelectedAuthors.Add(null));
            AddGenreComboCommand = new RelayCommand(_ => SelectedGenres.Add(null));
            ChangeLanguageRuCommand = new RelayCommand(_ => LanguageManager.Instance.ChangeLanguage("ru-RU"));
            ChangeLanguageEnCommand = new RelayCommand(_ => LanguageManager.Instance.ChangeLanguage("en-US"));

            Authors = new ObservableCollection<Author>(_repository.GetAllAuthors());   
            Authors_l = new List<Author>(_repository.GetAllAuthors());            
            Genres = new ObservableCollection<Genre>(_repository.GetAllGenres());
            Genres_l = new List<Genre>(_repository.GetAllGenres());
        }

        

        private void AddBookExecute(object? obj)
        {
            Close(obj);
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
}
