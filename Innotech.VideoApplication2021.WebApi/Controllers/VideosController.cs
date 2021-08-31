using System.Collections.Generic;
using InnotTech.VideoApplication2021.Core.IServices;
using InnotTech.VideoApplication2021.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Innotech.VideoApplication2021.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VideosController : ControllerBase
    {
        private readonly IVideoService _videoService;

        public VideosController(IVideoService videoService)
        {
            _videoService = videoService;
        }
        
        [HttpGet]
        public List<Video> ReadAll()
        {
            return _videoService.ReadAll();
        }
        
        [HttpGet("{id}")]
        public Video ReadById(int id)
        {
            //Fix later Read by Id 
            return null; 
            //return _videoService.Re();
        }

        [HttpPost]  //Body there a json object that matches 
        public Video Create(Video video)
        {
            if (video == null)
            {
                return null;
            }
            return _videoService.Create(video);
        }
        
        [HttpPut("{id}")]  //Body there a json object that matches 
        public Video Update(int id, Video video)
        {
            return null;
        }

        [HttpDelete("{id}")]
        public Video Delete(long id)
        {
            return null;
        }
    }
}