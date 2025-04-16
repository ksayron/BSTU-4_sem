using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6_MSSQL_LIB
{
    public class Context : DbContext
    {
        public string? ConnectionString { get; private set; } = null;
        public Context(string connectionString) : base()
        {
            this.ConnectionString = connectionString;
            //this.Database.EnsureCreated();
            //this.Database.EnsureDeleted();
        }
        public Context() : base()
        {
            //this.Database.EnsureCreated();
            //this.Database.EnsureDeleted();
        }
        public DbSet<Celebrity> Celebrities {get;set;}
        public DbSet<LifeEvent> Events {get;set;}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            if( this.ConnectionString is null) this.ConnectionString = string.Empty;
            optionsBuilder.UseSqlServer(this.ConnectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Celebrity>().ToTable("Celebrities").HasKey(p => p.Id);
            modelBuilder.Entity<Celebrity>().Property(p => p.Id).IsRequired();
            modelBuilder.Entity<Celebrity>().Property(p => p.FullName).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Celebrity>().Property(p => p.Nationality).IsRequired();
            modelBuilder.Entity<Celebrity>().Property(p => p.ReqPhotoPath).HasMaxLength(200);

            modelBuilder.Entity<LifeEvent>().ToTable("LifeEvents").HasKey(p=>p.Id);
            modelBuilder.Entity<LifeEvent>().ToTable("LifeEvents");
            modelBuilder.Entity<LifeEvent>().Property(p => p.Id).IsRequired();
            modelBuilder.Entity<LifeEvent>().ToTable("LifeEvents").HasOne<Celebrity>().WithMany().HasForeignKey(p=>p.CelebrityId);
            modelBuilder.Entity<LifeEvent>().Property(p => p.CelebrityId).IsRequired();
            modelBuilder.Entity<LifeEvent>().Property(p => p.Date);
            modelBuilder.Entity<LifeEvent>().Property(p => p.Description).HasMaxLength(256);
            modelBuilder.Entity<LifeEvent>().Property(p => p.ReqPhotoPath).HasMaxLength(256);

            base.OnModelCreating(modelBuilder);
        }
    }
}
