using D_D_CharacterSheet.Models;
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

namespace D_D_CharacterSheet.View
{
    /// <summary>
    /// Логика взаимодействия для CharacterEditWindow.xaml
    /// </summary>
    public partial class CharacterEditWindow : Window
    {
        public Character Character { get; private set; } = new Character();
        public User User { get; private set; }

        public CharacterEditWindow(User user, Character character = null)
        {
            InitializeComponent();
            User = user;
            if (character != null)
            {
                Character = character;
                NameBox.Text = character.Name;
                RaceBox.Text = character.Race;
                ClassBox.Text = character.Class;
                LevelBox.Text = character.Level.ToString();
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            Character = new Character
            {
                Id = Character.Id,
                UserId = User.Id,
                Name = NameBox.Text,
                Race = RaceBox.Text,
                Class = ClassBox.Text,
                Level = int.Parse(LevelBox.Text)
            };
            DialogResult=true;
            Close();
        }
    }
}
