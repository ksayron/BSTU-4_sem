using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6_LIB
{
    public interface ICelebrity<T>:IDisposable
    {
        List<T> GetAllCelebrity();
        T? GetCelebById (int id);
        bool DelCelebrity (int id);
        bool AddCelebrity (T celebrity);
        bool UpdCelebrity (int id, T celebrity);
        int  GetCelebdByName (string name);
    }
}
