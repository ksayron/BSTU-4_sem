using Lab4_5.Modules.classes;
using Lab4_5.Modules.DAL;
using Lab4_5.ViewModels;
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

namespace Lab4_5
{
    /// <summary>
    /// Логика взаимодействия для BookAddBox.xaml
    /// </summary>
    public partial class BookAddBox : Window
    {
        Repository repo = ((App)Application.Current).repository;
        List<ComboBox> authorCombos = [];
        List<ComboBox> genreCombos = [];
        public BookAddBox()
        {
            InitializeComponent();

            
            //AuthorCombo1.ItemsSource = repo.GetAllAuthors();
            //AuthorCombo1.SelectedIndex = 0;

            //GenreCombo1.ItemsSource = repo.GetAllGenres();
            //GenreCombo1.SelectedIndex = 0;

            //authorCombos.Add(AuthorCombo1);
            //genreCombos.Add(GenreCombo1);

        }
        public BookAddBox(BookAddVIewModel vm) 
        {
            this.DataContext = vm;
            InitializeComponent();

        }
        private void AddAuthorCombo_Click(object sender, RoutedEventArgs e)
        {
            AddNewComboBox(authorCombos, repo.GetAllAuthors(), 12); // Authors start at Row 12
        }

        private void AddGenreCombo_Click(object sender, RoutedEventArgs e)
        {
            AddNewComboBox(genreCombos, repo.GetAllGenres(), 14); // Genres start at Row 14
        }

        private void AddNewComboBox<T>(List<ComboBox> targetList, List<T> dataSource, int startRow)
        {
            // Prevent duplicates
            if (targetList.Count >= dataSource.Count)
            {
                MessageBox.Show("Все элементы уже добавлены.");
                return;
            }

            var newCombo = new ComboBox
            {
                ItemsSource = dataSource,
                SelectedIndex = 0,
                Margin = new Thickness(0, 5, 0, 5)
            };

            int newRow = startRow + targetList.Count * 2;

            
            var rowDef = new RowDefinition { Height = new GridLength(0.15, GridUnitType.Star) };
            MainGrid.RowDefinitions.Insert(newRow, rowDef);

            Grid.SetRow(newCombo, newRow);
            Grid.SetColumn(newCombo, 1);
            Grid.SetColumnSpan(newCombo, 2);
            MainGrid.Children.Add(newCombo);

            targetList.Add(newCombo);
        }
        private void AddBookButton_Click(object sender, RoutedEventArgs e)
        {
            string title = TitleInput.Text;
            string smallDesc = SmallDescInput.Text;
            string fullDesc = FullDescInput.Text;
            int.TryParse(AmountInput.Text, out int amount);
            
            var selectedAuthors = authorCombos
                .Select(cb => cb.SelectedItem as Author)
                .Where(author => author != null)
                .Distinct()
                .ToList();

            var selectedGenres = genreCombos
                .Select(cb => cb.SelectedItem as Genre)
                .Where(genre => genre != null)
                .Distinct()
                .ToList();

            
            if (string.IsNullOrWhiteSpace(title) || amount <= 0 || selectedAuthors.Count < 1 || selectedGenres.Count < 1)
            {
                MessageBox.Show("Пожалуйста, заполните все обязательные поля.");
                return;
            }
            var book = new Book();
            book.Title = title;
            book.AmountAvailible = amount;
            book.Description = fullDesc;
            book.SmallDescription = smallDesc;
            book.Authors = selectedAuthors;
            book.Genres = selectedGenres;
            if (repo.AddBook(book))
            {
                this.Close();
                Message.ShowM("Book successfully added", $"Книга добавлена:\nНазвание: {title}\nАвторы: {string.Join(", ", selectedAuthors)}\nЖанры: {string.Join(", ", selectedGenres)}");
            }
            else
            {
                Message.ShowM("Ошибка при регистрации", "Неопознная ошибка. повторите позже");
            }
            
            
        }
    }
}
