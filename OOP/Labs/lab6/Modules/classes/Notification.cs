using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_5.Modules.classes
{
    public class Notification
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Message { get; set; }
    
        [Required]
        public DateTime ExpireAt { get; set; }

        public bool IsActive => DateTime.Now <= ExpireAt;

        public Notification()
        {
            Message = "";
            ExpireAt = DateTime.Now;
        }
    }
}
