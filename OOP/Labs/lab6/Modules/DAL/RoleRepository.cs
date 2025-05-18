using Lab4_5.Modules.classes;
using Lab4_5.Modules.db;
using Lab4_5.Modules.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_5.Modules.DAL
{
    public class RoleRepository : IRole<Role>
    {
        LibraryContext context;
        public RoleRepository()
        {
            context = new LibraryContext();
        }
        public RoleRepository(string ConnString)
        {
            context = new LibraryContext(ConnString);
        }
        public RoleRepository(LibraryContext context)
        {
            this.context = context;
        }

        public bool AddRole(Role role)
        {
            this.context.Roles.Add(role);
            try { this.context.SaveChanges(); }
            catch (Exception ex)
            {
                var error = new Message("Error", ex.Message);
                error.Show();
                return false;
            }
            return true;
        }

        public bool DeleteRoleById(int id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public List<Role> GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public Role? GetRoleById(int id)
        {
            throw new NotImplementedException();
        }

        public int GetRoleIdByName(string username)
        {
            throw new NotImplementedException();
        }

        public bool UpdateRole(int id, Role role)
        {
            throw new NotImplementedException();
        }
    }
}
