using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Lab4_5.Modules.classes;
using Lab4_5.Modules.DAL;
using Lab4_5.Modules.View;
using Lab4_5.ViewModels;
namespace Lab4_5
{
    /// <summary>
    /// Логика взаимодействия для AdminMain.xaml
    /// </summary>
    public partial class AdminMain : Window
    {

        //Repository repo = ((App)Application.Current).repository;
        User user;
        bool need_to_apply_filters = false;
        Author none_option_author = new Author("none","");
        Genre none_option_genre = new Genre("none");
        public AdminMain()
        {
            user = new User();
            InitializeComponent();
        }
        public AdminMain(User auth_user)
        {
            user = auth_user;
            InitializeComponent();
            switch (user.ProfilePicId)
            {
                case 0:
                    {
                        this.ProfilePicImage.Visibility = Visibility.Hidden;
                        break;
                    };
                case 1:
                    {
                        //BitmapImage ProfPic = new BitmapImage();
                        //ProfPic.BeginInit();
                        //ProfPic.UriSource = new Uri("./Resources/Images/ProfPic/2.jpg");
                        //ProfPic.EndInit();
                        //this.ProfilePicImage.Source = ProfPic;
                        this.ProfilePicImage.Visibility = Visibility.Visible;
                        break;
                    }
                

            }
        }

        private void AddBookButton_Click(object sender, RoutedEventArgs e)
        {
            //var new_form = new BookAddBox();
            //new_form.ShowDialog();
            //this.BooksGrid.ItemsSource = repo.GetAllBooks();
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void SearchBox_KeyDown(object sender, KeyEventArgs e)
        {
            //if(e.Key == Key.Enter)
            //{
            //    if (!need_to_apply_filters)
            //    {
            //        this.BooksGrid.ItemsSource = repo.GetAllBooks().Where(b => b.Title.Contains(SearchBox.Text));
            //    }
            //    else
            //    {
            //        var search_res = repo.GetAllBooks().Where(b => b.Title.Contains(SearchBox.Text));
            //        apply_filter(search_res);
            //    }
            //}
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //var search_res = repo.GetAllBooks();
            //if (SearchBox.Text.Length>0)
            //{
            //    search_res = search_res.Where(b => b.Title.Contains(SearchBox.Text)).ToList();
            //}
            //var filtered_items = apply_filter(search_res);
            //BooksGrid.ItemsSource = filtered_items;
            //need_to_apply_filters = true;

        }
        private IEnumerable<Book> apply_filter(IEnumerable<Book> search_result)
        {
            if (AuthorFilter_Combo.SelectedItem is Author author && author.Name!="none")
            {
                search_result = search_result.Where(b => b.Authors.Contains(author));
            }
            if (GenreFilter_Combo.SelectedItem is Genre genre && genre.Name != "none")
            {
                search_result = search_result.Where(b => b.Genres.Contains(genre));
            }
            return search_result;
        }

        private void BooksGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            
            e.Cancel = true;
        }
        //private void RuButton_Click(object sender, RoutedEventArgs e)
        //{
        //    LanguageManager.Instance.ChangeLanguage("ru-RU");
        //}
        //private void EnButton_Click(object sender, RoutedEventArgs e)
        //{
        //    LanguageManager.Instance.ChangeLanguage("en-US");
        //}

        private void BooksGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            string headername = e.Column.Header.ToString();
            e.Column.IsReadOnly = true;
            if (headername == "Id")
            {
                e.Column.IsReadOnly = true;
            }
            if(headername == "Authors" && headername == "Reviews" && headername == "IssuedOrders" && headername =="ImgPath")
            {
                e.Cancel=true;
            }
            if(headername == "authors")
            {
                //set refrence here
            }

        }
    }
}
