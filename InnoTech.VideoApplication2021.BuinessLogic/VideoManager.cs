using System.Collections.Generic;
using InnoTech.VideoApplication2021.Models;

namespace InnoTech.VideoApplication2021.BuinessLogic
{
    public class VideoManager
    {
        private static List<Video> _fakeDbVideos = new List<Video>();
        private static int _id = 1;
        public Video Create(Video video)
        {
            video.Id = _id++;
            _fakeDbVideos.Add(video);
            return video;
        }
        
        
    }
}