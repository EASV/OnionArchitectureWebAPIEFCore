using System.Collections.Generic;
using InnoTech.VideoApplication2021.Domain.IRepositories;
using InnotTech.VideoApplication2021.Core.Models;

namespace InnoTech.VideoApplication2021.Infrastructure.DataAccess.Repositories
{
    public class VideoRepositoryInMemory : IVideoRepository
    {
        private static List<Video> _videosTable = new List<Video>();
        private static int _id = 1;
        public Video Add(Video video)
        {
            video.Id = _id++;
            _videosTable.Add(video);
            return video;
        }

        public List<Video> FindAll()
        {
            return _videosTable;
        }
    }
}