using D_D_CharacterSheet.Data;
using D_D_CharacterSheet.Models;
using D_D_CharacterSheet.View;
using System.Data;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace D_D_CharacterSheet
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly DatabaseManager _db = new();
        private User _currentUser;

        public MainWindow(User user)
        {
            InitializeComponent();
            _currentUser = user;
            LoadData();
        }

        private void LoadData()
        {
            CharacterGrid.ItemsSource = _db.GetCharactersByUser(_currentUser.Id);
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            var editor = new CharacterEditWindow();
            if (editor.ShowDialog() == true)
            {
                _db.AddCharacter(editor.Character);
                LoadData();
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (CharacterGrid.SelectedItem is DataRowView row)
            {
                int id = (int)(long)row["Id"];
                _db.DeleteCharacter(id,_currentUser.Id); 
                LoadData();
            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (CharacterGrid.SelectedItem is DataRowView row)
            {
                var editor = new CharacterEditWindow(new Character
                {
                    Id = (int)(long)row["Id"],
                    Name = row["Name"].ToString(),
                    Race = row["Race"].ToString(),
                    Class = row["Class"].ToString(),
                    Level = (int)(long)row["Level"]
                });

                if (editor.ShowDialog() == true)
                {
                    _db.UpdateCharacter(editor.Character); 
                    LoadData();
                }
            }
        }
    }
}