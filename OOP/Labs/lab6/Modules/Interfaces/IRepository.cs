using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KNP_Library.Modules.classes;

namespace KNP_Library.Modules.Interfaces
{
    public interface IRepository<T1,T2,T3,T4> : IMix<T1,T2,T3,T4>,IUser<T1>,IBook<T2>,IAuthor<T3>,IGenre<T4>
    {

    }
    public interface IMix<T1, T2, T3, T4>
    {

    }
        
}
