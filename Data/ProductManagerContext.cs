using Microsoft.EntityFrameworkCore;
using ProductManagerTenta1.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductManagerTenta1.Data
{
    class ProductManagerContext : DbContext
    {
        public DbSet<Article> Articles { get; protected set; }
        public DbSet<Category> Categories { get; protected set; }
     

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Server=.;Database=ProductManagerTenta;Trusted_Connection=True";
            optionsBuilder.UseSqlServer(connectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
               .HasOne(c => c.ParentCategory)
               .WithMany(c => c.Categories)
               .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Category>()
                .HasMany(c => c.Articles)
                .WithMany(a => a.Categories);

            modelBuilder.Entity<Article>()
                .HasKey(i => new { i.Id });

            modelBuilder.Entity<Article>()
              .HasIndex(an => an.ArticleNumber)
              .IsUnique();


        }
    
    }
}
