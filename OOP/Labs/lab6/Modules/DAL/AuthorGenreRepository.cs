using Lab4_5.Modules.classes;
using Lab4_5.Modules.db;
using Lab4_5.Modules.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_5.Modules.DAL
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
            throw new NotImplementedException();
        }

        public bool AddGenre(Genre genre)
        {
            throw new NotImplementedException();
        }

        public bool DeleteAuthorById(int id)
        {
            throw new NotImplementedException();
        }

        public bool DeleteGenreById(int id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public int GetAuthorBySurname(string surname)
        {
            throw new NotImplementedException();
        }

        public Genre? GetGenreById(int id)
        {
            throw new NotImplementedException();
        }

        public int GetGenreByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool UpdateAuthor(int id, Author author)
        {
            throw new NotImplementedException();
        }

        public bool UpdateGenre(int id, Genre genre)
        {
            throw new NotImplementedException();
        }
    }
}
