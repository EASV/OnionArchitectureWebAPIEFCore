using InnoTech.VideoApplication2021.EFSql.Entities;
using Microsoft.EntityFrameworkCore;

namespace InnoTech.VideoApplication2021.EFSql
{
    public class VideoApplicationContext: DbContext
    {
        public VideoApplicationContext(DbContextOptions<VideoApplicationContext> opt) : base(opt)
        {
        } 
        public DbSet<VideoEntity> Videos { get; set; }
        public DbSet<GenreEntity> Genres { get; set; }
    }
}