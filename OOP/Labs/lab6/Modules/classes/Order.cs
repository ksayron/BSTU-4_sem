using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KNP_Library.Modules.classes
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        [NotMapped]
        public int UserCardId => User.CardId;
        [NotMapped]
        public string BookTitle => Book.Title;

        public bool IsActive => ClosedAt == null;
        [Required]
        public DateTime IssuedAt { get; }
        [Required]
        public DateTime DueAt { get; set; }
        public DateTime? ClosedAt { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int BookId { get; set; }
        public User User { get; set; }

        public Book Book { get; set; }

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
