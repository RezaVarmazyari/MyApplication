using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyApplication.Models;

namespace MyApplication.Data
{
    public class MyApplicationContext : DbContext
    {
        public MyApplicationContext(DbContextOptions<MyApplicationContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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
            #endregion
            base.OnModelCreating(modelBuilder);
        }
    }
}
