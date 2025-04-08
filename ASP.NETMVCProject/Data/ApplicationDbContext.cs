using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using ASP.NETMVCProject.Models;
using ASP.NETMVCProject.Data;

namespace ASP.NETMVCProject.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options
            ) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }


        /*  protected override void OnModelCreating(ModelBuilder modelBuilder)
          {
              modelBuilder.Entity<Category>().HasData(

              new Category { CategoryId = 1, CategoryName = "Electronics" },
              new Category { CategoryId = 2, CategoryName = "Books" },
              new Category { CategoryId = 3, CategoryName = "Clothing" }
              );

              // Seed Products
                  modelBuilder.Entity<Product>().HasData(
                  new Product { ProductId = 1, ProductName = "Smartphone", CategoryId = 1 },
                  new Product { ProductId = 2, ProductName = "Laptop", CategoryId = 1 },
                  new Product { ProductId = 3, ProductName = "Novel", CategoryId = 2 },
                  new Product { ProductId = 4, ProductName = "T-Shirt", CategoryId = 3 }
              );

          }*/
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Cascade); // This enables cascade delete

            base.OnModelCreating(modelBuilder);
        }
    }

}
