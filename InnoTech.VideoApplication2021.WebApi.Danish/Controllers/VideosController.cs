using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InnotTech.VideoApplication2021.Core.IServices;
using InnotTech.VideoApplication2021.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InnoTech.VideoApplication2021.WebApi.Danish.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideosController : ControllerBase
    {
        private readonly IVideoService _videoService;

        public VideosController(IVideoService videoService)
        {
            _videoService = videoService;
        }

        [HttpPost]
        public Video Create([FromBody] Video video)
        {
            return _videoService.Create(video);
        }

        [HttpGet]
        public List<Video> GetAll()
        {
            return _videoService.ReadAll();
        }
    }
}