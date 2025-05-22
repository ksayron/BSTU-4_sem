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

namespace KNP_Library
{
    /// <summary>
    /// Логика взаимодействия для Message.xaml
    /// </summary>
    public partial class Message : Window
    {
        public Message()
        {
            InitializeComponent();
        }
        public Message(string title,string message)
        {
            InitializeComponent();
            this.Title = title;
            this.MessageLabel.Text = message;
            
        }
        public Message(string title, string message,double top,double left)
        {
            this.Top = top;
            this.Left = left;
            InitializeComponent();
            this.Title = title;
            this.MessageLabel.Text = message;

        }

        public static void ShowM(string title, string message)
        {
            var message_box = new Message(title, message);
            message_box.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
