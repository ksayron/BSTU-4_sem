using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KNP_Library.Modules.classes;
using Lab4_5.Modules.classes;

namespace KNP_Library.Modules.db
{
    public class LibraryContext : DbContext
    {
        public string ConnectionString { get; private set; } = @"Server=WIN-UCLB12VI625\SQLEXPRESS; Database = LibraryDB; TrustServerCertificate=True; " +
                                                                @"Trusted_Connection=true; User Id=Library_User; Password=password;";
        public LibraryContext() : base()
        {
            Database.EnsureCreated();
        }
        public LibraryContext(string connStr) : base()
        {
            ConnectionString = connStr;
            Database.EnsureCreated();
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Notification> Notifications { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(ConnectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users").HasKey(p => p.Id);

            modelBuilder.Entity<User>().Property(p => p.Id).IsRequired();
            modelBuilder.Entity<User>().Property(p => p.CardId).IsRequired();
            modelBuilder.Entity<User>().Property(p => p.Username).IsRequired().HasMaxLength(25);
            modelBuilder.Entity<User>().Property(p => p.PasswordHash).IsRequired();
            modelBuilder.Entity<User>().Property(p => p.Email).IsRequired();
            modelBuilder.Entity<User>().Property(p => p.ProfilePicImage).HasMaxLength(1000);
            modelBuilder.Entity<User>().Property(p => p.RoleId).IsRequired();
            modelBuilder.Entity<User>().Property(p => p.CreatedAt).IsRequired();

            modelBuilder.Entity<User>()
                .HasMany(u => u.Orders)
                .WithOne(o => o.User)
                .HasForeignKey(o => o.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Book>().ToTable("Books").HasKey(p => p.Id);
            modelBuilder.Entity<Book>().Property(p => p.Id).IsRequired();
            modelBuilder.Entity<Book>().Property(p => p.Title).IsRequired().HasMaxLength(255);
            modelBuilder.Entity<Book>().Property(p => p.ImgPath).IsRequired();
            modelBuilder.Entity<Book>().Property(p => p.FilePath).HasMaxLength(1000);
            modelBuilder.Entity<Book>().Property(p => p.Description).IsRequired().HasMaxLength(1000);
            modelBuilder.Entity<Book>().Property(p => p.SmallDescription).IsRequired().HasMaxLength(255);
            modelBuilder.Entity<Book>().Property(p => p.AmountAvailible).IsRequired();

            modelBuilder.Entity<Book>()
                .HasMany(b => b.IssuedOrders)
                .WithOne(o => o.Book)
                .HasForeignKey(o => o.BookId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Author>().ToTable("Authors").HasKey(a => a.Id);
            modelBuilder.Entity<Author>().Property(a => a.Name).IsRequired().HasMaxLength(15);
            modelBuilder.Entity<Author>().Property(a => a.Surname).IsRequired().HasMaxLength(25);
            modelBuilder.Entity<Author>().HasIndex(a => new { a.Name, a.Surname }).IsUnique();

            modelBuilder.Entity<Book>()
                .HasMany(b => b.Authors)
                .WithMany(a => a.Books)
                .UsingEntity(j => j.ToTable("BookAuthors"));

            modelBuilder.Entity<Order>().ToTable("Orders").HasKey(o => o.OrderId);
            modelBuilder.Entity<Order>().Property(o => o.IssuedAt).IsRequired();
            modelBuilder.Entity<Order>().Property(o => o.DueAt).IsRequired();
            modelBuilder.Entity<Order>().Property(o => o.ClosedAt);

            modelBuilder.Entity<Role>().ToTable("Roles").HasKey(r => r.Id);
            modelBuilder.Entity<Role>().Property(r => r.Name).IsRequired();
            modelBuilder.Entity<User>().
                HasOne(u => u.UserRole).
                WithMany( r => r.Users).
                HasForeignKey(u => u.RoleId).
                OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Genre>().ToTable("Genres").HasKey(g => g.Id);
            modelBuilder.Entity<Genre>().Property(g => g.Name).IsRequired();

            modelBuilder.Entity<Book>().
                HasMany(b => b.Genres).
                WithMany(g => g.Books).
                UsingEntity(j => j.ToTable("BookGenres"));
            
            modelBuilder.Entity<Review>().ToTable("Reviews").HasKey(r=>r.Id);
            modelBuilder.Entity<Review>().Property(r => r.Assessment).IsRequired();
            modelBuilder.Entity<Review>().Property(r => r.Text).HasMaxLength(255);
            modelBuilder.Entity<Review>().Property(r => r.CreatedAt).IsRequired();

            modelBuilder.Entity<User>().
                HasMany(u => u.Reviews).
                WithOne(r => r.ReviewUser).
                HasForeignKey(r => r.UserId).
                OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Book>().
                HasMany(b => b.Reviews).
                WithOne(r => r.ReviewBook).
                HasForeignKey(r => r.BookId).
                OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Notification>().ToTable("Notification").HasKey(n => n.Id);
            modelBuilder.Entity<Notification>().Property(r => r.Message).IsRequired();
            modelBuilder.Entity<Notification>().Property(r => r.ExpireAt).IsRequired();

            base.OnModelCreating(modelBuilder);
        }
    }
}
