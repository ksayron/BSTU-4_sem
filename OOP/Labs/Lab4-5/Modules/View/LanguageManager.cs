using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
using System.Windows;

namespace Lab4_5.Modules.View
{
    public class LanguageManager
    {
        private static LanguageManager instance;
        public static LanguageManager Instance => instance = new LanguageManager();

        public event EventHandler<string> LanguageChanged;

        private LanguageManager() { }

        public void ChangeLanguage(string languageCode)
        {

            try
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(languageCode);
                Thread.CurrentThread.CurrentCulture = new CultureInfo(languageCode);


                var dictionary = new ResourceDictionary
                {
                    Source = new Uri($"Resources/Dictionary/Dictionary{(languageCode == "ru-RU" ? "RU" : "EN")}.xaml", UriKind.Relative)
                };

                Application.Current.Resources.MergedDictionaries.Clear();
                Application.Current.Resources.MergedDictionaries.Add(dictionary);

                foreach (Window window in Application.Current.Windows)
                {
                    window.Language = XmlLanguage.GetLanguage(languageCode);
                    window.UpdateLayout();
                }

                if (Application.Current.MainWindow != null)
                {
                    Application.Current.MainWindow.Language = XmlLanguage.GetLanguage(languageCode);
                    Application.Current.MainWindow.UpdateLayout();
                }

                LanguageChanged?.Invoke(this, languageCode);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    string.Format((string)Application.Current.Resources["ErrorChangingLanguage"], ex.Message),
                    (string)Application.Current.Resources["ErrorTitle"],
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }

        }
    }
}
