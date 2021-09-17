
using InnoTech.VideoApplication2021.EFCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace InnoTech.VideoApplication2021.EFCore
{
    public class VideoApplicationDbContext : DbContext
    {
        public VideoApplicationDbContext(DbContextOptions<VideoApplicationDbContext> options) : base(options) {}
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InsuranceEntity>()
                .HasData(new InsuranceEntity { Id = 1, Name = "SafeStuff", Price = 22 });
            modelBuilder.Entity<InsuranceEntity>()
                .HasData(new InsuranceEntity { Id = 2, Name = "Other Stuff", Price = 222 });
            modelBuilder.Entity<InsuranceEntity>()
                .HasData(new InsuranceEntity { Id = 3, Name = "Bingo Stuff", Price = 2222 });
            
        }

        public DbSet<InsuranceEntity> Insurances { get; set; }
    }
}