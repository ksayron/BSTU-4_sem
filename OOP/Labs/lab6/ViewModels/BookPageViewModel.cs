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
using System.Windows.Input;
using Microsoft.Extensions.DependencyInjection;

namespace Lab4_5.ViewModels
{
    class BookPageViewModel : BaseViewModel
    {
        public Book CurrentBook { get; set; }
        public string ImgSource { get; set; } 

        public ICommand EditBookCommand { get; }
        public ICommand DeleteBookCommand { get; }
        public ICommand ShowOrdersCommand { get; }
        public ICommand ShowReviewsCommand { get; }
        public ICommand ChangeLanguageEnCommand { get; }
        public ICommand ChangeLanguageRuCommand { get; }
        public BookPageViewModel()
        {
            var test_author= new Author("Pudgo","Pudgovanna");
            var test_Genre= new Genre("Dota 2");
            var test_Genre2= new Genre("Momchik");
            CurrentBook = new Book();
            CurrentBook.Authors.Add(test_author);
            CurrentBook.Authors.Add(test_author);
            CurrentBook.Genres.Add(test_Genre);
            CurrentBook.Genres.Add(test_Genre2);
            ImgSource = "../Resources/Images/BookImg/book.png";//std pic if no pic;
            OnPropertyChanged(nameof(ImgSource));
        }
        public BookPageViewModel(Book currentBook)
        {
            CurrentBook = currentBook;
            ImgSource = CurrentBook.ImgPath;
        }
    }
}
