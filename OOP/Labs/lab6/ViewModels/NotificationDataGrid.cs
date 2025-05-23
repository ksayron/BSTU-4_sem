using KNP_Library.Modules.DAL;
using KNP_Library.Modules.ViewModel;
using Lab4_5.Modules.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows;
using KNP_Library.Modules.View;

namespace KNP_Library.ViewModels
{
    class NotificationDataGrid : BaseViewModel
    {
        public Repository _repository;

        
        public List<Notification> Notifications { get; set; }
        
        public ICommand DeleteNotification { get; }

        public ICommand ChangeLanguageRuCommand { get; }
        public ICommand ChangeLanguageEnCommand { get; }

        public NotificationDataGrid()
        {


            DeleteNotification = new RelayCommand(DeleteNotificationExecute );

            ChangeLanguageRuCommand = new RelayCommand(_ => LanguageManager.Instance.ChangeLanguage("ru-RU"));
            ChangeLanguageEnCommand = new RelayCommand(_ => LanguageManager.Instance.ChangeLanguage("en-US"));

        }

        public NotificationDataGrid(Repository repository)
        {
            _repository = repository;

            DeleteNotification = new RelayCommand(DeleteNotificationExecute);

            ChangeLanguageRuCommand = new RelayCommand(_ => LanguageManager.Instance.ChangeLanguage("ru-RU"));
            ChangeLanguageEnCommand = new RelayCommand(_ => LanguageManager.Instance.ChangeLanguage("en-US"));
            Notifications = repository.Notifications.GetAllNotifications();

        }



        private void DeleteNotificationExecute(object? obj)
        {
            if(obj is Notification notification)
            {
                _repository.Notifications.DeleteNotificationById(notification.Id);
                Notifications = _repository.Notifications.GetAllNotifications();
                OnPropertyChanged(nameof(Notifications));
            }
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
