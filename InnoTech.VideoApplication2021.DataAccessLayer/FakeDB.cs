using System.Collections.Generic;
using InnoTech.VideoApplication2021.Models;

namespace InnoTech.VideoApplication2021.DataAccessLayer
{
    public class FakeDB : IFakeDB
    {
        private static List<Video> _fakeDbVideos = new List<Video>();
        private static int _id = 1;

        public Video AddVideo(Video video)
        {
            video.Id = _id++;
            return video;
        }

        public int DeleteVideo(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}