using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D_D_CharacterSheet.Models
{
    public class Character
    {
        public int UserId { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Race { get; set; }
        public string Class { get; set; }
        public int Level { get; set; }
    }

}
