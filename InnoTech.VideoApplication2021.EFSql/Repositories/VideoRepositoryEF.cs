using System.Collections.Generic;
using System.Linq;
using InnoTech.VideoApplication2021.Domain.IRepositories;
using InnoTech.VideoApplication2021.EFSql.Entities;
using InnotTech.VideoApplication2021.Core.Models;

namespace InnoTech.VideoApplication2021.EFSql.Repositories
{
    public class VideoRepositoryEF: IVideoRepository
    {
        private readonly VideoApplicationContext _ctx;

        public VideoRepositoryEF(VideoApplicationContext ctx)
        {
            _ctx = ctx;
        }

        public Video Add(Video video)
        {
            var entity = new VideoEntity
            {
                Title = video.Title,
                StoryLine = video.StoryLine,
                ReleaseDate = video.ReleaseDate,
                GenreId = video.Genre.Id
            };
            var savedEntity = _ctx.Videos.Add(entity).Entity;
            _ctx.SaveChanges();
            return new Video
            {
                Id = savedEntity.Id,
                Title = savedEntity.Title,
                StoryLine = savedEntity.StoryLine,
                ReleaseDate = savedEntity.ReleaseDate,
                Genre = new Genre
                {
                    Id = savedEntity.GenreId
                }
            };
        }

        public List<Video> FindAll()
        {
            return _ctx.Videos
                .Select(videoEntity => new Video
                {
                    Id = videoEntity.Id,
                    StoryLine = videoEntity.StoryLine,
                    Title = videoEntity.Title,
                    ReleaseDate = videoEntity.ReleaseDate,
                    Genre = new Genre
                    {
                        Id = videoEntity.GenreId
                    }
                })
                .ToList();
        }

        public Video FindById(int id)
        {
            return _ctx.Videos
                .Select(videoEntity => new Video
                {
                    Id = videoEntity.Id,
                    StoryLine = videoEntity.StoryLine,
                    Title = videoEntity.Title,
                    ReleaseDate = videoEntity.ReleaseDate,
                    Genre = new Genre
                    {
                        Id = videoEntity.GenreId
                    }
                })
                .FirstOrDefault(v => v.Id == id);
        }

        public Video Update(Video video)
        {
            var entity = new VideoEntity
            {
                Id = video.Id.Value,
                Title = video.Title,
                StoryLine = video.StoryLine,
                ReleaseDate = video.ReleaseDate,
                GenreId = video.Genre.Id
            };
            var savedEntity = _ctx.Videos.Update(entity).Entity;
            _ctx.SaveChanges();
            return new Video
            {
                Id = savedEntity.Id,
                Title = savedEntity.Title,
                StoryLine = savedEntity.StoryLine,
                ReleaseDate = savedEntity.ReleaseDate,
                Genre = new Genre
                {
                    Id = savedEntity.GenreId
                }
            };
        }

        public Video Remove(int id)
        {
            var savedEntity = _ctx.Videos.Remove(new VideoEntity { Id = id }).Entity;
            _ctx.SaveChanges();
            return new Video
            {
                Id = savedEntity.Id,
                Title = savedEntity.Title,
                StoryLine = savedEntity.StoryLine,
                ReleaseDate = savedEntity.ReleaseDate,
                Genre = new Genre
                {
                    Id = savedEntity.GenreId
                }
            };
        }
    }
}