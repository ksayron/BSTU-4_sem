using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KNP_Library.Modules.Interfaces
{
    public interface IGenre<T>:IDisposable
    {
        List<T> GetAllGenres();
        T? GetGenreById(int id);
        bool AddGenre(T genre);
        bool DeleteGenreById(int id);
    }
}
