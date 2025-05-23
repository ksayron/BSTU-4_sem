using KNP_Library.Modules.classes;
using KNP_Library.Modules.DAL;
using KNP_Library.Modules.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using KNP_Library.Modules.View;

namespace KNP_Library.ViewModels
{
    public class GenreAddBoxViewModel : BaseViewModel
    {
        Repository _repository;
        public string Name { get; set; } = "";



        public ICommand AddGenreCommand { get; }

        public ICommand ChangeLanguageRuCommand { get; }
        public ICommand ChangeLanguageEnCommand { get; }

        public GenreAddBoxViewModel()
        {


            AddGenreCommand = new RelayCommand(AddAuthorExecute, CanAddAuthorExecute);

            ChangeLanguageRuCommand = new RelayCommand(_ => LanguageManager.Instance.ChangeLanguage("ru-RU"));
            ChangeLanguageEnCommand = new RelayCommand(_ => LanguageManager.Instance.ChangeLanguage("en-US"));

        }
        public GenreAddBoxViewModel(Repository repository)
        {
            _repository = repository;



            AddGenreCommand = new RelayCommand(AddAuthorExecute, CanAddAuthorExecute);

            ChangeLanguageRuCommand = new RelayCommand(_ => LanguageManager.Instance.ChangeLanguage("ru-RU"));
            ChangeLanguageEnCommand = new RelayCommand(_ => LanguageManager.Instance.ChangeLanguage("en-US"));


        }



        private void AddAuthorExecute(object? obj)
        {
            var new_genre = new Genre();
            new_genre.Name = Name;

            if (_repository.AuthorsGenres.AddGenre(new_genre))
            {
                Close(obj);
            }
        }
        private bool CanAddAuthorExecute(object? obj)
        {
            return _repository is not null ;//validation logic
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
    }
}
