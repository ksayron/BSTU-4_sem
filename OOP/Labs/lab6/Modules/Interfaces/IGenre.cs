using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_5.Modules.Interfaces
{
    public interface IGenre<T>:IDisposable
    {
        List<T> GetAllGenres();
        T? GetGenreById(int id);
        int GetGenreByName(string name);
        bool AddGenre(T genre);
        bool DeleteGenreById(int id);
        bool UpdateGenre(int id, T genre);
    }
}
