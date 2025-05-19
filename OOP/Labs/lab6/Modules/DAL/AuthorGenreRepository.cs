using KNP_Library.Modules.classes;
using KNP_Library.Modules.db;
using KNP_Library.Modules.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KNP_Library.Modules.DAL
{
    public class AuthorGenreRepository : IAuthor<Author>, IGenre<Genre>
    {
        LibraryContext context;
        public AuthorGenreRepository()
        {
            context = new LibraryContext();
        }
        public AuthorGenreRepository(string ConnString)
        {
            context = new LibraryContext(ConnString);
        }
        public AuthorGenreRepository(LibraryContext context)
        {
            this.context = context;
        }

        public bool AddAuthor(Author author)
        {
            this.context.Authors.Add(author);
            try { this.context.SaveChanges(); }
            catch (Exception ex)
            {
                var error = new Message("Error", ex.Message);
                return false;
            }
            return true;
        }

        public bool AddGenre(Genre genre)
        {
            this.context.Genres.Add(genre);
            try { this.context.SaveChanges(); }
            catch (Exception ex)
            {
                var error = new Message("Error", ex.Message);
                return false;
            }
            return true;
        }

        public bool DeleteAuthorById(int id)
        {
            var author = GetAuthorById(id);
            if (author is null)
            {
                var error = new Message("Error", "No id found");
                error.Show();
                return false;
            }
            this.context.Authors.Remove(author);
            try { this.context.SaveChanges(); }
            catch (Exception ex)
            {
                var error = new Message("Error", ex.Message);
                error.Show();
                return false;
            }
            return true;
        }

        public bool DeleteGenreById(int id)
        {
            var genre = GetGenreById(id);
            if (genre is null)
            {
                var error = new Message("Error", "No id found");
                error.Show();
                return false;
            }
            this.context.Genres.Remove(genre);
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

        public List<Author> GetAllAuthors()
        {
            return this.context.Authors.ToList();
        }

        public List<Genre> GetAllGenres()
        {
            return this.context.Genres.ToList();
        }

        public Author? GetAuthorById(int id)
        {
            return this.context.Authors.Include(b => b.Books).FirstOrDefault(u => u.Id == id);
        }


        public Genre? GetGenreById(int id)
        {
            return this.context.Genres.Include(b => b.Books).FirstOrDefault(u => u.Id == id);
        }




    }
}
