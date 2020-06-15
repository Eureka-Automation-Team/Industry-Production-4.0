using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using IndustryProduction.Services;
using Microsoft.AspNetCore.Mvc;

namespace IndustryProduction.Controllers
{
    [Route("api/[controller]")]
    public class StreamingController : Controller
    {
        private IVideoStreamService _streamingService;

        public StreamingController(IVideoStreamService streamingService)
        {
            _streamingService = streamingService;
        }

        [HttpGet("{name}")]
        public async Task<FileStreamResult> Get(string name)
        {
            var stream = await _streamingService.GetVideoByName(name);
            return new FileStreamResult(stream, "video/mp4");
        }
    }
}