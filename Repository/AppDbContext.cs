﻿using Core.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options) 
        { 
           

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }  
        public DbSet<ProductFeature> ProductFeatures { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            //modelBuilder.ApplyConfiguration(new ProductConfiguration());
            //modelBuilder.ApplyConfiguration(new ProductFeatureConfiguration());

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());  // configures all type  named interface(IEntityTypeConfiguration) by doing reflection


            modelBuilder.Entity<ProductFeature>().HasData(new ProductFeature()
            {

                Id = 1,
                ProductId = 1,
                Color = "Siyah",
                Height = 20,
                Width = 120
            },
            new ProductFeature()
            {

                Id = 2,
                ProductId = 2,
                Color = "Mavi",
                Height = 20,
                Width = 120
            }); ;

            base.OnModelCreating(modelBuilder); 
        }


    }
}
