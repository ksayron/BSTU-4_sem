﻿using KNP_Library;
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
    /// Логика взаимодействия для NotificationBox.xaml
    /// </summary>
    public partial class NotificationBox : Window
    {
        public NotificationBox(string message)
        {
            InitializeComponent();
            this.DataContext = new { Message = message };

            Task.Delay(8000).ContinueWith(_ =>
            {
                Dispatcher.Invoke(Close);
            });
        }
    }
}
