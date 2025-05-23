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

namespace KNP_Library.ViewModels
{
    public class AuthorAddBoxViewModel : BaseViewModel
    {
        Repository _repository;
        public string Name { get; set; } = "";
        public string Surname { get; set; } = "";



        public ICommand AddAuthorCommand { get; }

        public ICommand ChangeLanguageRuCommand { get; }
        public ICommand ChangeLanguageEnCommand { get; }

        public AuthorAddBoxViewModel()
        {


            AddAuthorCommand = new RelayCommand(AddAuthorExecute, CanAddAuthorExecute);

            ChangeLanguageRuCommand = new RelayCommand(_ => LanguageManager.Instance.ChangeLanguage("ru-RU"));
            ChangeLanguageEnCommand = new RelayCommand(_ => LanguageManager.Instance.ChangeLanguage("en-US"));

        }
        public AuthorAddBoxViewModel(Repository repository)
        {
            _repository = repository;



            AddAuthorCommand = new RelayCommand(AddAuthorExecute, CanAddAuthorExecute);

            ChangeLanguageRuCommand = new RelayCommand(_ => LanguageManager.Instance.ChangeLanguage("ru-RU"));
            ChangeLanguageEnCommand = new RelayCommand(_ => LanguageManager.Instance.ChangeLanguage("en-US"));


        }



        private void AddAuthorExecute(object? obj)
        {
            var new_author = new Author();
            new_author.Name = Name;
            new_author.Surname = Surname;

            if (_repository.AuthorsGenres.AddAuthor(new_author))
            {
                Close(obj);
            }
        }
        private bool CanAddAuthorExecute(object? obj)
        {
            return Name != "" & Surname != "";//validation logic
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
