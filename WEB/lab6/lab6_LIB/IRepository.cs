using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6_LIB
{
    public interface IRepository<T1, T2> : IMix<T1, T2>, ICelebrity<T1>, ILifeEvent<T2> 
    {

    }
    public interface IMix<T1, T2>
    {
        List<T2> GetEventsByCelebId(int CelebID);
        T1? GetCelebByEventId(int Eventid);
    }
}
