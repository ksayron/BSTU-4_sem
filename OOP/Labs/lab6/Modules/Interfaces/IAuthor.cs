using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KNP_Library.Modules.Interfaces
{
    public interface IAuthor<T> : IDisposable
    {
        List<T> GetAllAuthors();
        T? GetAuthorById(int id);
        bool AddAuthor(T author);
        bool DeleteAuthorById(int id);
    }
}
