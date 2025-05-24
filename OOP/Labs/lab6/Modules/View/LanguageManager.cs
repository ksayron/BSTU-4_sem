using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
using System.Windows;

namespace KNP_Library.Modules.View
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
                    Source = new Uri($"Resources/Dictionary/Dictionary{(languageCode == "ru-RU" ? "RU" : "EN")}.xaml", UriKind.Relative),
                    
                };

                ReplaceDictionary("LanguageDictionary", dictionary);

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
        private void ReplaceDictionary(string key, ResourceDictionary newDict)
        {
            var existing = Application.Current.Resources.MergedDictionaries
                .FirstOrDefault(d => d.Contains(key));

            if (existing != null)
                Application.Current.Resources.MergedDictionaries.Remove(existing);

            newDict[key] = true; 
            Application.Current.Resources.MergedDictionaries.Add(newDict);
        }
        public void ChangeTheme(string themeName)
        {
            var themeDict = new ResourceDictionary
            {
                Source = new Uri($"/YourAssemblyName;component/Themes/{themeName}.xaml", UriKind.Relative)
            };

            ReplaceDictionary("ThemeDictionary", themeDict);
        }
    }
}
