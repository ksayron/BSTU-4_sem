using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KNP_Library.Modules.classes
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public List<User> Users { get; set; }
        public Role()
        {
            Name = "Role_Test";
            Users = [];
        }
        public Role(string NAME)
        {
            Name = NAME;
            Users = [];
        }
    }
}
