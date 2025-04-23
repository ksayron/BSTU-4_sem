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
    public interface IRepository : IRepository<User, Book,Author,Genre> { }
    public class Repository : IRepository
    {
        LibraryContext context;
        public Repository()
        {
            context = new LibraryContext();
        }
        public Repository(string ConnString)
        {
            context = new LibraryContext(ConnString);
        }
        public static IRepository Create()
        {
            return new Repository();
        }
        public static IRepository Create(string connString)
        {
            return new Repository(connString);
        }
        public void Init()
        {
            var user_role = new Role();
            user_role.Name = "User";
            AddRole(user_role);
            var admin_role = new Role();
            admin_role.Name = "Admin";
            AddRole(admin_role);
        }
        public bool AddBook(Book book)
        {
            this.context.Books.Add(book);
            try { this.context.SaveChanges(); }
            catch(Exception ex)
            {
                var error = new Message("Error", ex.Message);
                return false;
            }
            return true;
        }

        public bool AddUser(User user)
        {
            this.context.Users.Add(user);
            try { this.context.SaveChanges(); }
            catch(Exception ex)
            {
                var error = new Message("Error",ex.Message);
                error.Show();
                return false;
            }
            return true;
        }
        public bool AddRole(Role role)
        {
            this.context.Roles.Add(role);
            try { this.context.SaveChanges(); }
            catch (Exception ex)
            {
                var error = new Message("Error", ex.Message);
                error.Show();
                return false;
            }
            return true;
        }

        public bool DeleteBookById(int id)
        {
            throw new NotImplementedException();
        }
        public bool DeleteUserById(int id)
        {
            throw new NotImplementedException();
        }

     

        public List<Book> GetAllBooks()
        {
            return this.context.Books.Include(b=>b.Authors).Include(b=>b.Genres).ToList() ;
        }

        public List<User> GetAllUsers()
        {
            return this.context.Users.ToList();
        }

        public List<Book> GetAvaibleBooks()
        {
            return this.context.Books.Where(b => b.AmountAvailible>0).ToList();
        }

        public Book? GetBookById(int id)
        {
            return this.context.Books.Include(b=>b.Authors).Include(b => b.Genres).Include(b => b.Reviews).Include(b => b.IssuedOrders).FirstOrDefault(u => u.Id == id);
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
            return this.context.Books.Include(b => b.Authors).Include(b => b.Genres).Where(b=> b.Rating > rating).ToList();
        }

        public User? GetUserByCardId(int id)
        {
            return this.context.Users.FirstOrDefault(u => u.CardId == id);
        }

        public int GetUserIdByEmail(string email)
        {
            var user = this.context.Users.FirstOrDefault(u => u.Email == email);
            if (user == null)
            {
                return 0;
            }
            else
            {
                return user.CardId;
            }
        }

        public int GetUserIdByUsername(string username)
        {
            var user = this.context.Users.FirstOrDefault(u => u.Username == username);
            if(user == null)
            {
                return 0;
            }
            else
            {
                return user.CardId;
            }
        }

        

        public bool UpdateBook(int id, Book book)
        {
            var updated_book = GetBookById(id);
            if(updated_book is null)
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

        public bool UpdateUser(int id, User user)
        {
            throw new NotImplementedException();
        }

        public void Dispose() { }

        public List<Author> GetAllAuthors()
        {
            return this.context.Authors.ToList();
        }

        public Author? GetAuthorById(int id)
        {
            throw new NotImplementedException();
        }

        public int GetAuthorBySurname(string surname)
        {
            throw new NotImplementedException();
        }

        public bool AddAuthor(Author author)
        {
            throw new NotImplementedException();
        }

        public bool DeleteAuthorById(int id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateAuthor(int id, Author author)
        {
            throw new NotImplementedException();
        }

        public List<Genre> GetAllGenres()
        {
            return this.context.Genres.ToList();
        }

        public Genre? GetGenreById(int id)
        {
            throw new NotImplementedException();
        }

        public int GetGenreByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool AddGenre(Genre genre)
        {
            throw new NotImplementedException();
        }

        public bool DeleteGenreById(int id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateGenre(int id, Genre genre)
        {
            throw new NotImplementedException();
        }
    }
}
