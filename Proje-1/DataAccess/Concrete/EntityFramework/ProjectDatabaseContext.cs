using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class ProjectDatabaseContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            

            optionsBuilder.UseNpgsql(@"server=localhost;port=5432;Database=case;user Id=postgres; password=root");
         
        }

        public DbSet<Product> Products { get; set; } 
        public DbSet<Campaign> Campaigns { get; set; } 
        public DbSet<Basket> Baskets { get; set; } 
        public DbSet<BasketProduct> BasketProducts { get; set; } 
      
    }
}
