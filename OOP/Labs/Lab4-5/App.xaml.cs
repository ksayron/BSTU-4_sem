using Lab4_5.Modules.DAL;
using Lab4_5.Modules.db;
using System.Configuration;
using System.Data;
using System.Windows;

namespace Lab4_5
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public Repository repository;
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            repository = new Repository();
           // repository.Init();
        }
    }

}
