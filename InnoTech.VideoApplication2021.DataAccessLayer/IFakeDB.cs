using InnoTech.VideoApplication2021.Models;

namespace InnoTech.VideoApplication2021.DataAccessLayer
{
    public interface IFakeDB
    {
        public Video AddVideo(Video video);
        public int DeleteVideo(int id);
    }
}