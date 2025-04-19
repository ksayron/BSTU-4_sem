using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_5.Modules.classes
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        [Required]
        public int UserId { get; set; }
        public User User { get; set; }
        [Required]
        public int BookId { get; set; }
        public Book Book { get; set; }
        public bool IsActive => ClosedAt != null;
        [Required]
        public DateTime IssuedAt { get; }
        [Required]
        public DateTime DueAt { get; set; }
        public DateTime? ClosedAt { get; private set; }
        public Order()
        {
            IssuedAt = DateTime.Now;
            DueAt = DateTime.Now.AddMonths(1);
        }
        public void CloseOrder()
        {
            ClosedAt = DateTime.Now;
        }
    }
}
