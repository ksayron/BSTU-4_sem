using KNP_Library.ViewModels;
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

namespace KNP_Library.Views
{
    /// <summary>
    /// Логика взаимодействия для ReviewAddBox.xaml
    /// </summary>
    public partial class ReviewAddBox : Window
    {
        public ReviewAddBox()
        {
            InitializeComponent();
        }

        private void RichTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(DataContext is ReviewAddBoxViewModel vm)
            {
                var textRange = new TextRange(ReviewTextBox.Document.ContentStart, ReviewTextBox.Document.ContentEnd);
                vm.ReviewText = textRange.Text;
            }
        }
        private void OnlyNumericInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !int.TryParse(e.Text, out _);
        }
    }
}
