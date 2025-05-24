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
    public interface IRepository : IRepository<User, Book,Author,Genre> { }
    public class Repository 
    {
        public AuthorGenreRepository AuthorsGenres;
        public BookRepository Books;
        public UserRepository Users;
        public ReviewRepository Reviews;
        public OrderRepository Orders;
        public RoleRepository Roles;
        public NotificationRepository Notifications;

        LibraryContext context;
        public Repository()
        {
            context = new LibraryContext();

            AuthorsGenres = new AuthorGenreRepository(context);
            Books = new BookRepository(context);
            Users = new UserRepository(context);
            Reviews = new ReviewRepository(context);
            Orders = new OrderRepository(context);
            Roles = new RoleRepository(context);
            Notifications = new NotificationRepository(context);
        }
        public Repository(string ConnString)
        {
            context = new LibraryContext(ConnString);

            AuthorsGenres = new AuthorGenreRepository(context);
            Books = new BookRepository(context);
            Users = new UserRepository(context);
            Reviews = new ReviewRepository(context);
            Orders = new OrderRepository(context);
            Roles = new RoleRepository(context);
            Notifications = new NotificationRepository(context);
        }
        
        public void Init()
        {
            var user_role = new Role();
            user_role.Name = "User";
            Roles.AddRole(user_role);
            var admin_role = new Role();
            admin_role.Name = "Admin";
            Roles.AddRole(admin_role);
        }
        
        public void Dispose() { }


    }
}
