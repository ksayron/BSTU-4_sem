using Lab4_5.Modules.DAL;
using Lab4_5.ViewModels;
using Lab4_5.Modules.db;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Data;
using System.Windows;
using System;
using System.Windows.Media;
using Lab4_5.Views;

namespace Lab4_5
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public Repository repository;
        public static IServiceProvider ServiceProvider { get; private set; }
        private void ConfigureServices()
        {
            var services = new ServiceCollection();

            string connStr = ConfigurationManager.ConnectionStrings["LocalConnection"].ConnectionString;
            
            services.AddSingleton<Repository>(sp =>
                new Repository(connStr)
            );

            services.AddTransient<AuthViewModel>();
            services.AddTransient<Auth>();

            services.AddTransient<RegViewModel>();
            services.AddTransient<Reg>();

            services.AddTransient<AdminMainViewModel>();
            services.AddTransient<AdminMain>();

            services.AddTransient<BookAddVIewModel>();
            services.AddTransient<BookAddBox>();

            services.AddTransient<EditBookViewModel>();
            services.AddTransient<EditBook>();


            ServiceProvider = services.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            ConfigureServices();
            base.OnStartup(e);
            var first_win = ServiceProvider.GetRequiredService<Auth>();
            first_win.Show();
            //repository = new Repository();
            // repository.Init();
        }

        private void OnExit(object sender, ExitEventArgs e)
        {
            // Dispose of services if needed
            if (ServiceProvider is IDisposable disposable)
            {
                disposable.Dispose();
            }
        }
    }

}
