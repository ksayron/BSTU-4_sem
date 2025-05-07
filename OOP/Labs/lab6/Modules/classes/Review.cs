using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Lab4_5.Modules.classes
{
    public class Review
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        public User ReviewUser { get; set; }
        [Required]
        [Range(1, 10)]
        public int Assessment { get; set; }
        [StringLength(255)]
        public string Text { get; set; }
        [Required]
        public DateTime CreatedAt { get; private set; }
        public Review()
        {
            Text = string.Empty;
            CreatedAt = DateTime.Now;
        }
        public Review(int userId, int score, string text)
        {
            UserId = userId;
            Assessment = score;
            Text = text;
            CreatedAt = DateTime.Now;
        }
    }
}
