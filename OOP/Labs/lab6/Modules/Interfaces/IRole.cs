using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KNP_Library.Modules.Interfaces
{
    interface IRole<T> : IDisposable
    {
        List<T> GetAllRoles();
        T? GetRoleById(int id);
        bool AddRole(T role);
        bool DeleteRoleById(int id);

    }
}
