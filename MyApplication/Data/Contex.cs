using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyApplication.Models;
using MyApplication.Data;

namespace MyApplication.Data
{
    public class MyApplicationContext : DbContext
    {
        public MyApplicationContext(DbContextOptions<MyApplicationContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryToProduct> CategoryToProducts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Item> Items { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryToProduct>()
            .HasKey(t => new { t.ProductId, t.CategoryId });

            //for floent relationship
            // modelBuilder.Entity<Product>(
            //     p =>
            //     {
            //         p.HasKey(w => w.Id);
            //         p.OwnsOne<Item>(w => w.Item);
            //         p.HasOne<Item>(w => w.Item).WithOne(w => w.Product)
            //          .HasForeignKey<Item>(w => w.Id);
            //     }
            // );

            modelBuilder.Entity<Item>(
                i =>
                {
                    i.Property(w => w.Price).HasColumnType("Money");
                    i.HasKey(w => w.Id);
                }
            );

            #region Seed Data Category
            modelBuilder.Entity<Category>().HasData(
            new Category()
            {
                Id = 1,
                Name = "لباس زمستان",
                Description = "لباس زمستان"
            },
            new Category()
            {
                Id = 2,
                Name = "لباس تابستان",
                Description = "لباس تابستان"
            },
            new Category()
            {
                Id = 3,
                Name = "لباس بهاره",
                Description = "لباس بهاره"
            }
            );

            modelBuilder.Entity<Item>().HasData(
                new Item()
                {
                    Id = 1,
                    Price = 85000,
                    QuantityInStock = 5
                },
                 new Item()
                 {
                     Id = 2,
                     Price = 1000000,
                     QuantityInStock = 7
                 },
                new Item()
                {
                    Id = 3,
                    Price = 250000,
                    QuantityInStock = 5
                }
            );
            modelBuilder.Entity<Product>().HasData(
                new Product()
                {
                    Id = 1,
                    Name = "دوره  اول ",
                    Description = "دوره جامع اول"
                },
                 new Product()
                 {
                     Id = 2,
                     Name = "دوره دوم ",
                     Description = "دوره جامع دوم "
                 },
                 new Product()
                 {
                     Id = 3,
                     Name = "دوره سوم",
                     Description = "دوره جامع سوم"
                 }
            );
            modelBuilder.Entity<CategoryToProduct>().HasData(
                new CategoryToProduct() { CategoryId = 1, ProductId = 1 },
                new CategoryToProduct() { CategoryId = 2, ProductId = 1 },
                new CategoryToProduct() { CategoryId = 3, ProductId = 1 },
                new CategoryToProduct() { CategoryId = 4, ProductId = 1 },
                  new CategoryToProduct() { CategoryId = 1, ProductId = 2},
                new CategoryToProduct() { CategoryId = 2, ProductId = 2 },
                new CategoryToProduct() { CategoryId = 3, ProductId = 2 },
                new CategoryToProduct() { CategoryId = 4, ProductId = 2 },
                  new CategoryToProduct() { CategoryId = 1, ProductId =3 },
                new CategoryToProduct() { CategoryId = 2, ProductId = 3 },
                new CategoryToProduct() { CategoryId = 3, ProductId = 3},
                new CategoryToProduct() { CategoryId = 4, ProductId = 3 },
                  new CategoryToProduct() { CategoryId = 1, ProductId = 4 },
                new CategoryToProduct() { CategoryId = 2, ProductId = 4 },
                new CategoryToProduct() { CategoryId = 3, ProductId = 4 },
                new CategoryToProduct() { CategoryId = 4, ProductId = 4 }
                );
            #endregion
            base.OnModelCreating(modelBuilder);
        }

    }

}
