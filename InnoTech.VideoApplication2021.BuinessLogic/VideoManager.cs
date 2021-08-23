using System.Collections.Generic;
using InnoTech.VideoApplication2021.DataAccessLayer;
using InnoTech.VideoApplication2021.Models;

namespace InnoTech.VideoApplication2021.BuinessLogic
{
    public class VideoManager
    {
        private readonly IFakeDB _fakeDb;

        public VideoManager()
        {
            _fakeDb = new FakeDB();
        }
        public Video Create(Video video)
        {
            return _fakeDb.AddVideo(video);
        }
    }
}