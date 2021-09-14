using System.Collections.Generic;
using System.Linq;
using InnoTech.VideoApplication2021.Domain.IRepositories;
using InnotTech.VideoApplication2021.Core.Models;

namespace InnoTech.VideoApplication2021.EFSql.Repositories
{
    public class GenreRepositoryEF: IGenreRepository
    {
        private readonly VideoApplicationContext _ctx;

        public GenreRepositoryEF(VideoApplicationContext ctx)
        {
            _ctx = ctx;
        }

        public List<Genre> FindAll()
        {
            return _ctx.Genres
                .Select(entity => new Genre
                {
                    Id = entity.Id,
                    Name = entity.Name
                })
                .ToList();
        }

        public Genre ReadById(int id)
        {
            return _ctx.Genres
                .Select(entity => new Genre
                {
                    Id = entity.Id,
                    Name = entity.Name
                })
                .FirstOrDefault(g => g.Id == id);
        }
    }
}