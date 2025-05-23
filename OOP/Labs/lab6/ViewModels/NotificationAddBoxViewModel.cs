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
using KNP_Library.ViewModels;
using KNP_Library;
using Lab4_5.Modules.classes;

namespace KNP_Library.ViewModels
{
    class NotificationAddBoxViewModel : BaseViewModel
    {
        public Repository _repository;
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
        public DateTime ExpireDate { get; set; } = DateTime.Now;
        public ICommand AddReviewCommand { get; }

        public ICommand ChangeLanguageRuCommand { get; }
        public ICommand ChangeLanguageEnCommand { get; }

        public NotificationAddBoxViewModel()
        {


            AddReviewCommand = new RelayCommand(AddReviewExecute, CanAddReviewExecute);

            ChangeLanguageRuCommand = new RelayCommand(_ => LanguageManager.Instance.ChangeLanguage("ru-RU"));
            ChangeLanguageEnCommand = new RelayCommand(_ => LanguageManager.Instance.ChangeLanguage("en-US"));

        }




        private void AddReviewExecute(object? obj)
        {
            var new_notif = new Notification();
            new_notif.Message = ReviewText;
            new_notif.ExpireAt = ExpireDate;
            if (_repository.Notifications.AddNotification(new_notif))
            {
                Close(obj);
            }
        }
        private bool CanAddReviewExecute(object? obj)
        {
            return (ExpireDate  > DateTime.Now && ReviewText is not null) ;//validation logic
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
