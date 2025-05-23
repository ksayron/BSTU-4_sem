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
using System.Windows.Documents;

namespace KNP_Library.ViewModels
{
    public class ReviewAddBoxViewModel : BaseViewModel
    {
        public Repository _repository;
        public int Assessment { get; set; } = 0;
        private FlowDocument _reviewDocument = new FlowDocument();
        public FlowDocument ReviewDocument
        {
            get => _reviewDocument;
            set
            {
                _reviewDocument = value;
                OnPropertyChanged();
            }
        }

        public string ReviewText;

        public bool IsSuccess { get; set; } = false;

        public User ReviewUser { get; set; }
        public Book ReviewBook { get; set; }
        public ICommand AddReviewCommand { get; }

        public ICommand ChangeLanguageRuCommand { get; }
        public ICommand ChangeLanguageEnCommand { get; }

        public ReviewAddBoxViewModel()
        {


            AddReviewCommand = new RelayCommand(AddReviewExecute, CanAddReviewExecute);

            ChangeLanguageRuCommand = new RelayCommand(_ => LanguageManager.Instance.ChangeLanguage("ru-RU"));
            ChangeLanguageEnCommand = new RelayCommand(_ => LanguageManager.Instance.ChangeLanguage("en-US"));

        }
        public ReviewAddBoxViewModel(Book currnetBook,User currentUser)
        {

            ReviewBook = currnetBook;
            ReviewUser = currentUser;


            AddReviewCommand = new RelayCommand(AddReviewExecute, CanAddReviewExecute);

            ChangeLanguageRuCommand = new RelayCommand(_ => LanguageManager.Instance.ChangeLanguage("ru-RU"));
            ChangeLanguageEnCommand = new RelayCommand(_ => LanguageManager.Instance.ChangeLanguage("en-US"));


        }



        private void AddReviewExecute(object? obj)
        {
            var new_review = new Review();
            new_review.BookId = ReviewBook.Id;
            new_review.UserId = ReviewUser.Id;
            new_review.Assessment = Assessment;
            new_review.Text = ReviewText;


            if (_repository.Reviews.AddReview(new_review,ReviewBook))
            {
                Close(obj);
            }
        }
        private bool CanAddReviewExecute(object? obj)
        {
            return (Assessment>0 & Assessment<11) ;//validation logic
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
