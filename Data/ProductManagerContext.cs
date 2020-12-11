using Microsoft.EntityFrameworkCore;
using ProductManagerTenta1.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductManagerTenta1.Data
{
    class ProductManagerContext : DbContext
    {
        public DbSet<Article> articles { get; protected set; }
        public DbSet<Category> categories { get; protected set; }
        public DbSet<ArticleCategory> articleCategories { get; protected set; }
        public DbSet<CategoryCategory> categoryCategories { get; protected set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Server=.;Database=ProductManagerTenta;Trusted_Connection=True";
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
