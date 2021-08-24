using System;
using System.ComponentModel.Design;
using InnoTech.VideoApplication2021.Domain.IRepositories;
using InnoTech.VideoApplication2021.Domain.Services;
using InnoTech.VideoApplication2021.Infrastructure.DataAccess.Repositories;
using InnoTech.VideoApplication2021.SQL.Repositories;
using InnotTech.VideoApplication2021.Core.IServices;

namespace InnoTech.VideoApplication2021.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            //Cheapish DI (Dependency Injection)
            //IVideoRepository repo = new VideoRepositoryInMemory();
            IVideoRepository repo = new VideoRepository();
            IVideoService service = new VideoService(repo);
            
            var menu = new Menu(service);
            menu.Start();
        }
    }
}