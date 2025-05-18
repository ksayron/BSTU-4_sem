using Lab4_5.Modules.classes;
using Lab4_5.Modules.db;
using Lab4_5.Modules.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Lab4_5.Modules.DAL
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
