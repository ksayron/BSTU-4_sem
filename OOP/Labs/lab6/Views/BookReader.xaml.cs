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
    /// Логика взаимодействия для BookReader.xaml
    /// </summary>
    public partial class BookReader : Window
    {
        public BookReader()
        {
            InitializeComponent();
        }
        public BookReader(string pdfFilePath)
        {
            InitializeComponent();

            var pdfUri = new Uri(pdfFilePath);

            PdfWebViewer.Navigate(pdfUri);
        }
    }
}
