using KNP_Library.Modules.classes;
using KNP_Library.Modules.db;
using KNP_Library.Modules.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace KNP_Library.Modules.DAL
{
    public class ReviewRepository : IReview<Review,Book>
    {
        LibraryContext context;
        public ReviewRepository()
        {
            context = new LibraryContext();
        }
        public ReviewRepository(string ConnString)
        {
            context = new LibraryContext(ConnString);
        }
        public ReviewRepository(LibraryContext context)
        {
            this.context = context;
        }

        public bool AddReview(Review review, Book book)
        {
            using var transaction = this.context.Database.BeginTransaction();
            try
            {
                // Attach book if it's not already tracked
                if (!this.context.Books.Local.Any(b => b.Id == book.Id))
                {
                    this.context.Books.Attach(book);
                }

                // Add review
                this.context.Reviews.Add(review);

                book.Reviews.Add(review); 
                book.Rating = book.Reviews.Average(r => r.Assessment); 

                this.context.SaveChanges(); 
                transaction.Commit();       
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();     // Roll back if anything fails
                var error = new Message("Error", ex.Message);
                error.Show();
                return false;
            }
        }


        public bool DeleteReviewById(int id)
        {
            var review = GetReviewById(id);
            if (review is null)
            {
                var error = new Message("Error", "No id found");
                error.Show();
                return false;
            }
            this.context.Reviews.Remove(review);
            try { this.context.SaveChanges(); }
            catch (Exception ex)
            {
                var error = new Message("Error", ex.Message);
                error.Show();
                return false;
            }
            return true;
        }

        public void Dispose()
        {

        }

        public List<Review> GetAllReviews()
        {
            return this.context.Reviews.Include(b => b.ReviewUser).Include(b => b.ReviewBook).ToList();
        }

        public Review? GetReviewById(int id)
        {
            return this.context.Reviews.Include(b => b.ReviewBook).Include(b => b.ReviewUser).FirstOrDefault(u => u.Id == id);
        }

        public List<Review> GetReviewsByBookId(int bookid)
        {
            return this.context.Reviews.Include(b => b.ReviewUser).Include(b => b.ReviewBook).Where(r=>r.BookId==bookid).ToList();
        }

        public List<Review> GetReviewsByUserId(int userid)
        {
            return this.context.Reviews.Include(b => b.ReviewUser).Include(b => b.ReviewBook).Where(r => r.UserId == userid).ToList();
        }
    }
}
