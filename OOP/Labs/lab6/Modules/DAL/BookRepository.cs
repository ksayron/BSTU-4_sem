using Lab4_5.Modules.classes;
using Lab4_5.Modules.db;
using Lab4_5.Modules.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_5.Modules.DAL
{
    public class BookRepository : IBook<Book>
    {
        LibraryContext context;
        public BookRepository()
        {
            context = new LibraryContext();
        }
        public BookRepository(string ConnString)
        {
            context = new LibraryContext(ConnString);
        }
        public BookRepository(LibraryContext context)
        {
            this.context = context;
        }
        public bool AddBook(Book book)
        {
            this.context.Books.Add(book);
            try { this.context.SaveChanges(); }
            catch (Exception ex)
            {
                var error = new Message("Error", ex.Message);
                return false;
            }
            return true;
        }

        public bool DeleteBookById(int id)
        {
            var book = GetBookById(id);
            if (book is null)
            {
                var error = new Message("Error", "No id found");
                error.Show();
                return false;
            }
            this.context.Books.Remove(book);
            try { this.context.SaveChanges(); }
            catch (Exception ex)
            {
                var error = new Message("Error", ex.Message);
                error.Show();
                return false;
            }
            return true;
        }

        public List<Book> GetAllBooks()
        {
            return this.context.Books.Include(b => b.Authors).Include(b => b.Genres).ToList();
        }

        public List<Book> GetAvaibleBooks()
        {
            return this.context.Books.Where(b => b.AmountAvailible > 0).ToList();
        }

        public Book? GetBookById(int id)
        {
            return this.context.Books.Include(b => b.Authors).Include(b => b.Genres).Include(b => b.Reviews).Include(b => b.IssuedOrders).FirstOrDefault(u => u.Id == id);
        }

        public int GetBookIdByName(string name)
        {
            var pos_id = this.context.Books.FirstOrDefault(u => u.Title == name);
            if (pos_id is null)
            {
                return 0;
            }
            return pos_id.Id;
        }

        public List<Book> GetRatedBooks(double rating)
        {
            return this.context.Books.Include(b => b.Authors).Include(b => b.Genres).Where(b => b.Rating > rating).ToList();
        }

        public bool UpdateBook(int id, Book book)
        {
            var updated_book = GetBookById(id);
            if (updated_book is null)
            {
                return false;
            }
            updated_book.Title = book.Title;
            updated_book.Authors = book.Authors;
            updated_book.SmallDescription = book.SmallDescription;
            updated_book.Description = book.Description;
            updated_book.Genres = book.Genres;
            updated_book.AmountAvailible = book.AmountAvailible;
            updated_book.Reviews = book.Reviews;
            updated_book.IssuedOrders = book.IssuedOrders;
            updated_book.ImgPath = book.ImgPath;
            updated_book.FilePath = book.FilePath;
            this.context.Books.Update(updated_book);
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
    }
}
