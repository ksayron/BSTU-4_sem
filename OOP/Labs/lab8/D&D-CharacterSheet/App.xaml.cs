using D_D_CharacterSheet.Data;
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
             DatabaseManager _db = new();
            _db.EnsureDatabaseCreated();
            var login = new LoginWindow();
            login.Show();
        }

    }

}
