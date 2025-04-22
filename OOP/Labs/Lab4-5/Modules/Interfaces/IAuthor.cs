using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_5.Modules.Interfaces
{
    public interface IAuthor<T> : IDisposable
    {
        List<T> GetAllAuthors();
        T? GetAuthorById(int id);
        int GetAuthorBySurname(string surname);
        bool AddAuthor(T author);
        bool DeleteAuthorById(int id);
        bool UpdateAuthor(int id, T author);
    }
}
