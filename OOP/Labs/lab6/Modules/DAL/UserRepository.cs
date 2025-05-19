using KNP_Library.Modules.classes;
using KNP_Library.Modules.Interfaces;
using KNP_Library.Modules.db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KNP_Library.Modules.DAL
{
    public class UserRepository : IUser<User>
    {
        LibraryContext context;
        public UserRepository()
        {
            context = new LibraryContext();
        }
        public UserRepository(string ConnString)
        {
            context = new LibraryContext(ConnString);
        }
        public UserRepository(LibraryContext context)
        {
            this.context = context;
        }
        public bool AddUser(User user)
        {
            this.context.Users.Add(user);
            try { this.context.SaveChanges(); }
            catch (Exception ex)
            {
                var error = new Message("Error", ex.Message);
                error.Show();
                return false;
            }
            return true;
        }

        public List<User> GetAllUsers()
        {
            return this.context.Users.ToList();
        }
        public bool DeleteUserById(int id)
        {
            var user = GetUserByCardId(id);
            if (user is null)
            {
                var error = new Message("Error", "No id found");
                error.Show();
                return false;
            }
            this.context.Users.Remove(user);
            try { this.context.SaveChanges(); }
            catch (Exception ex)
            {
                var error = new Message("Error", ex.Message);
                error.Show();
                return false;
            }
            return true;
        }

        public User? GetUserByCardId(int id)
        {
            return this.context.Users.FirstOrDefault(u => u.CardId == id);
        }

        public int GetUserIdByEmail(string email)
        {
            var user = this.context.Users.FirstOrDefault(u => u.Email == email);
            if (user == null)
            {
                return 0;
            }
            else
            {
                return user.CardId;
            }
        }

        public int GetUserIdByUsername(string username)
        {
            var user = this.context.Users.FirstOrDefault(u => u.Username == username);
            if (user == null)
            {
                return 0;
            }
            else
            {
                return user.CardId;
            }
        }

        public bool UpdateUser(int id, User user)
        {
            var updated_user = GetUserByCardId(id);
            if (updated_user is null)
            {
                return false;
            }
            updated_user.Username = user.Username;
            updated_user.PasswordHash = user.PasswordHash;
            updated_user.Email = user.Email;
            updated_user.UserRole = user.UserRole;
            updated_user.Orders = user.Orders;
            updated_user.Reviews = user.Reviews;
            updated_user.ProfilePicId = user.ProfilePicId;
            this.context.Users.Update(updated_user);
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
    }
}
