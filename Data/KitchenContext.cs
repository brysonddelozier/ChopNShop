using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ChopNShop.Models;

namespace ChopNShop.Data
{
    public class KitchenContext : DbContext
    {
        public KitchenContext (DbContextOptions<KitchenContext> options)
            : base(options)
        {
        }

        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Inclusion> Inclusions { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Chef> Chefs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            {
                modelBuilder.Entity<Recipe>().ToTable("Recipe");
                modelBuilder.Entity<Inclusion>().ToTable("Inclusion");
                modelBuilder.Entity<Ingredient>().ToTable("Ingredient");
                modelBuilder.Entity<Chef>().ToTable("Chef");
            }
        }
    }
}
