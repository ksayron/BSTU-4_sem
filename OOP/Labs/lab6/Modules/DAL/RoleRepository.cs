using KNP_Library.Modules.classes;
using KNP_Library.Modules.db;
using KNP_Library.Modules.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KNP_Library.Modules.DAL
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
            var role = GetRoleById(id);
            if (role is null)
            {
                var error = new Message("Error", "No id found");
                error.Show();
                return false;
            }
            this.context.Roles.Remove(role);
            try { this.context.SaveChanges(); }
            catch (Exception ex)
            {
                var error = new Message("Error", ex.Message);
                error.Show();
                return false;
            }
            return true;
        }

        public void Dispose()
        {

        }

        public List<Role> GetAllRoles()
        {
            return this.context.Roles.Include(b => b.Users).ToList();
        }

        public Role? GetRoleById(int id)
        {
            return this.context.Roles.Include(b => b.Users).FirstOrDefault(u => u.Id == id);
        }

 
    }
}
