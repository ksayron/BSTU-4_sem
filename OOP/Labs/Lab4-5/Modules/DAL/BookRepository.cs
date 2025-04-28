using Lab4_5.Modules.classes;
using Lab4_5.Modules.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_5.Modules.DAL
{
    internal class BookRepository : IBook<Book>
    {
        public bool AddBook(Book book)
        {
            throw new NotImplementedException();
        }

        public bool DeleteBookById(int id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public List<Book> GetAllBooks()
        {
            throw new NotImplementedException();
        }

        public List<Book> GetAvaibleBooks()
        {
            throw new NotImplementedException();
        }

        public Book? GetBookById(int id)
        {
            throw new NotImplementedException();
        }

        public int GetBookIdByName(string name)
        {
            throw new NotImplementedException();
        }

        public List<Book> GetRatedBooks(double rating)
        {
            throw new NotImplementedException();
        }

        public bool UpdateBook(int id, Book book)
        {
            throw new NotImplementedException();
        }
    }
}
