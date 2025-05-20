using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KNP_Library.Modules.classes;

namespace KNP_Library.Modules.Interfaces
{
    public interface IUser<T> : IDisposable
    {
        List<T> GetAllUsers();
        T? GetUserByCardId(int id);
        int GetUserIdByUsername(string username);
        int GetUserIdByEmail(string email);
        bool AddUser(T user);
        bool DeleteUserById(int id);
        bool UpdateUser(int id,T user);
        

    }
}
