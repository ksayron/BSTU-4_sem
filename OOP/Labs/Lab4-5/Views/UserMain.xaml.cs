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

namespace Lab4_5
{
    /// <summary>
    /// Логика взаимодействия для UserMain.xaml
    /// </summary>
    public partial class UserMain : Window
    {
        User user;
        public UserMain()
        {
            InitializeComponent();
            user = new User();
        }
        public UserMain(User user)
        {
            this.user = user;
            InitializeComponent();
        }
    }
}
