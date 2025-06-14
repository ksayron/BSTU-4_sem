using KNP_Library.Modules.DAL;
using KNP_Library.Modules.db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_5.Modules.DAL
{
    public interface IUnitOfWork : IDisposable
    {
        AuthorGenreRepository AuthorsGenres { get; }
        BookRepository Books { get; }
        UserRepository Users { get; }
        ReviewRepository Reviews { get; }
        OrderRepository Orders { get; }
        RoleRepository Roles { get; }
        NotificationRepository Notifications { get; }

        int Complete(); // SaveChanges
    }

    public class UnitOfWork : IUnitOfWork
    {
        private readonly LibraryContext _context;
        public AuthorGenreRepository AuthorsGenres { get; }
        public BookRepository Books { get; }
        public UserRepository Users { get; }
        public ReviewRepository Reviews { get; }
        public OrderRepository Orders { get; }
        public RoleRepository Roles { get; }
        public NotificationRepository Notifications { get; }

        public UnitOfWork()
            : this(new LibraryContext()) { }

        public UnitOfWork(string connString)
            : this(new LibraryContext(connString)) { }

        private UnitOfWork(LibraryContext context)
        {
            _context = context;

            AuthorsGenres = new AuthorGenreRepository(_context);
            Books = new BookRepository(_context);
            Users = new UserRepository(_context);
            Reviews = new ReviewRepository(_context);
            Orders = new OrderRepository(_context);
            Roles = new RoleRepository(_context);
            Notifications = new NotificationRepository(_context);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }

}
