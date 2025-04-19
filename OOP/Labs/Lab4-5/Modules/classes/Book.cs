using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Lab4_5.Modules.classes
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Title { get; set; }
        [Required]
        public string ImgPath { get; set; }
        [StringLength(1000)]
        public string Description { get; set; }
        [StringLength(255)]
        public string SmallDescription { get; set; }
        [Required]
        public int AmountAvailible {  get; set; }
        public bool IsAvailible { get => (AmountAvailible>0); }
        [Range(0,10)]
        public double Rating { get; set; }
        public List<Author> Authors { get; set; }//all authors og the book
        public List<Order> IssuedOrders { get; set; }//all copies of the book that were issied to readers
        public List<Review> Reviews { get; set; }//all reviews for this book
        public List<Genre> Genres { get; set; }//all genres for this book

        public Book()
        {
            Title = string.Empty;
            Description = string.Empty;
            SmallDescription = string.Empty;
            ImgPath = "";
            AmountAvailible = 0;
            Rating = 0;
            Authors = [];
            IssuedOrders = [];
            Reviews = [];
            Genres = [];
        }

    }
}
