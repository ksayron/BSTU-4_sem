using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab4_5.Modules.classes;

namespace Lab4_5.Modules.Interfaces
{
    public interface IRepository<T1,T2> : IMix<T1,T2>,IUser<T1>,IBook<T2>
    {

    }
    public interface IMix<T1, T2>
    {

    }
        
}
