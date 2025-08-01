
using CaseDataAccess.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseDataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-R0966DO;Initial Catalog=CaseStudyDb;Integrated Security=True;Trusted_Connection=True;TrustServerCertificate=True");
            }
        }

        public DbSet<User> Users { get; set; }
        public DbSet<TodoItem> TodoItems { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<User>()
            .Property(u => u.Id)
            .UseIdentityColumn();

            modelBuilder.Entity<TodoItem>()
            .Property(t => t.Id)
            .UseIdentityColumn();

            modelBuilder.Entity<TodoItem>()
            .Property(t => t.IsCompleted)
            .HasDefaultValue(false);

            modelBuilder.Entity<TodoItem>()
            .Property(t => t.CreatedAt)
            .HasDefaultValueSql("GETDATE()");

        }
    }
}
