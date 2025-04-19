using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_5.Modules.classes
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

    }
}
