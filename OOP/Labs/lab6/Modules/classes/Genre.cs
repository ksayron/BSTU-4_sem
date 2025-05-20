using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KNP_Library.Modules.classes
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public List<Book> Books { get; set; }
        public Genre()
        {
            Name = string.Empty;
            Books = new List<Book>();
        }
        public Genre(string name)
        {
            Name = name;
            Books = new List<Book>();
        }
        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
