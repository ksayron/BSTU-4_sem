using KNP_Library.ViewModels;
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

namespace Lab4_5.Views
{
    /// <summary>
    /// Логика взаимодействия для NotificationAddBox.xaml
    /// </summary>
    public partial class NotificationAddBox : Window
    {
        public NotificationAddBox()
        {
            InitializeComponent();
        }
        private void RichTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (DataContext is NotificationAddBoxViewModel vm)
            {
                var textRange = new TextRange(ReviewTextBox.Document.ContentStart, ReviewTextBox.Document.ContentEnd);
                vm.ReviewText = textRange.Text;
            }
        }
    }
}
