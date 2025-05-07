using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_5.Modules.Interfaces
{
    public interface IBook<T> : IDisposable
    {
        List<T> GetAllBooks();
        List<T> GetAvaibleBooks();
        List<T> GetRatedBooks(double rating);
        T? GetBookById(int id);
        int GetBookIdByName(string name);
        bool AddBook(T book);
        bool DeleteBookById(int id);
        bool UpdateBook(int id,T book);
        
    }
}
