using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6_LIB
{
    public interface ILifeEvent<T> : IDisposable
    {
        List<T> GetAllEvents();
        T? GetEventById(int id);
        bool DelEvent(int id);
        bool AddEvent(T LifeEvent);
        bool UpdEvent(int id,T LifeEvent);
    }
}
