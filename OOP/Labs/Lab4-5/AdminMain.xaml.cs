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
    /// Логика взаимодействия для AdminMain.xaml
    /// </summary>
    public partial class AdminMain : Window
    {
        User user;
        public AdminMain()
        {
            user = new User();
            InitializeComponent();
        }
        public AdminMain(User auth_user)
        {
            user = auth_user;
            InitializeComponent();
            this.UserNameLabel.Content = user.Username;
            switch (user.ProfilePicId)
            {
                case 0:
                    {
                        this.ProfilePicImage.Visibility = Visibility.Hidden;
                        break;
                    };
                case 1:
                    {
                        //this.ProfilePicImage.Source.SetCurrentValue()
                        this.ProfilePicImage.Visibility = Visibility.Visible;
                        break;
                    }
                

            }
        }
    }
}
