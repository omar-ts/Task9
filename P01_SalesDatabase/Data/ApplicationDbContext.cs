using Microsoft.EntityFrameworkCore;
using P01_SalesDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01_SalesDatabase.Data
{
    internal class ApplicationDbContext : DbContext
    {
        DbSet<Product> Products { get; set; }
        DbSet<Customer> Customers { get; set; }
        DbSet<Store> Stores { get; set; }
        DbSet<Sale> Sales { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=task9;Integrated Security=True;TrustServerCertificate=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Product table
            modelBuilder.Entity<Product>()
                .Property(e => e.Name)
                .IsUnicode(true)
                .HasMaxLength(50);

            //Customer table
            modelBuilder.Entity<Customer>()
                .Property(e => e.Name)
                .IsUnicode(true)
                .HasMaxLength(100);
            modelBuilder.Entity<Customer>()
                .Property(e => e.Email)
                .IsUnicode(false)
                .HasMaxLength(80);

            //Store table
            modelBuilder.Entity<Store>()
                .Property(e => e.Name)
                .IsUnicode(true)
                .HasMaxLength(80);

        }
    }
}
