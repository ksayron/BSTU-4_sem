using D_D_CharacterSheet.View;
using System.Configuration;
using System.Data;
using System.Windows;

namespace D_D_CharacterSheet
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var login = new LoginWindow();
            if (login.ShowDialog() == true)
            {
                var mainWindow = new MainWindow(login.LoggedInUser);
                mainWindow.Show();
            }
            else
            {
                Shutdown(); 
            }
        }

    }

}
