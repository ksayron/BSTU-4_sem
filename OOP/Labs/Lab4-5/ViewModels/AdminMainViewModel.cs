using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab4_5.Modules.classes;
using Lab4_5.Modules.DAL;
using Lab4_5.Modules.View;
using Lab4_5.Modules.ViewModel;
using Lab4_5;
using System.DirectoryServices;
using Lab4_5.Modules.Interfaces;

namespace Lab4_5.ViewModels
{
    public class AdminMainViewModel : INotifyPropertyChanged
    {
        //Repository repo = ((App)Application.Current).repository;
        //Repository repo = App.ServiceProvider.GetService<Repository>();
        private ObservableCollection<User> _users;
        public ObservableCollection<User> Users
        {
            get { return _users; }
            set
            {
                if(_users != value)
                {
                    _users = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("Users"));
                }
            }
        }
        private ObservableCollection<Book> _books;
        public ObservableCollection<Book> Books
        {
            get { return _books; }
            set
            {
                if (_books != value)
                {
                    _books = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("Books"));
                }
            }
        }
        public event PropertyChangedEventHandler? PropertyChanged = delegate { };
        private void OnDelete()
        {

        }
        private bool CanDelete()
        {
            return true;
        }
        //public Commands DeleteCommand = new RelayCommand(OnDelete, CanDelete);

    }
}
