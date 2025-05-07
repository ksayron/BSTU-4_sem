using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_5.Modules.classes
{
    public class Author
    {
        [Key]
        public int Id {  get; set; }
        [Required]
        [StringLength(15)]
        public string Name { get; set; }
        [Required]
        [StringLength(25)]
        public string Surname { get; set; }
        public List<Book> Books { get; set; }

        [NotMapped]
        public string FullName => $"{Name} {Surname}";
        public Author()
        {
            Name = string.Empty;
            Surname = string.Empty;
            Books = new List<Book>();
        }
        public Author(string name,string surname)
        {
            Name = name;
            Surname = surname;
            Books = new List<Book>();
        }
        public override string ToString()
        {
            return $"{Name} {Surname}";
        }
    }

}
