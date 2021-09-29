using System;
using System.Collections.Generic;
using InnoTech.PetShopApplication2021.EFCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace InnoTech.PetShopApplication2021.EFCore
{
    public class PetShopApplicationDbContext : DbContext
    {
        public PetShopApplicationDbContext(DbContextOptions<PetShopApplicationDbContext> options) : base(options) {}
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var random = new Random();
            var names = new List<string> { "Wuf", "Muh", "Niav" };
            for (var i = 1; i < 1000; i++)
            {
                var petName = $"{names[random.Next(0, 3)]} {i}";
                modelBuilder.Entity<PetEntity>()
                    .HasData(new PetEntity
                    {
                        Id = i,
                        Name = petName
                    });
            }
            
        }

        public DbSet<PetEntity> Pets { get; set; }
    }
}