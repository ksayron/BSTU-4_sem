using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KNP_Library.Modules.classes
{
    public class Review
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        public User ReviewUser { get; set; }
        [Required]
        public int BookId { get; set; }
        public Book ReviewBook { get; set; }
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
        [NotMapped]
        public string StarAssessment { get
            {
                string star_text = "";
                for(int i = 0; i < Assessment; i=i+2)
                {
                    star_text += "★";
                }
                if(Assessment % 2 ==1)
                {
                    star_text += "⯨";
                }
                return star_text;
            } }
    }
}
