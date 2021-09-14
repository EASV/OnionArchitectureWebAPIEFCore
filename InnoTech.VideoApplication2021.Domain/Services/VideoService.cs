using System;
using System.Collections.Generic;
using InnoTech.VideoApplication2021.Domain.IRepositories;
using InnotTech.VideoApplication2021.Core.IServices;
using InnotTech.VideoApplication2021.Core.Models;

namespace InnoTech.VideoApplication2021.Domain.Services
{
    public class VideoService : IVideoService
    {
        private IVideoRepository _videoRepository;
        private readonly IGenreRepository _genreRepository;

        public VideoService(IVideoRepository videoRepository, IGenreRepository genreRepository)
        {
            _videoRepository = videoRepository;
            _genreRepository = genreRepository;
        }
        
        public Video Create(Video video)
        {
            if (video.Genre == null || video.Genre.Id < 1)
            {
                throw new ArgumentException("To save video you need a Genre with ID");
            }
            return _videoRepository.Add(video);
        }

        public List<Video> ReadAll()
        {
            return _videoRepository.FindAll();
        }

        public Video ReadById(int id)
        {
            return _videoRepository.FindById(id);
        }

        public Video Update(Video video)
        {
            if (video.Title.Length < 2)
            {
                throw new ArgumentException("Title must be 2 or more chars.");
            }
            
            return _videoRepository.Update(video);
        }

        public Video Delete(int id)
        {
            return _videoRepository.Remove(id);
        }
    }
}