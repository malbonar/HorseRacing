using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MBSoftwareSolutions.HorseRacing.Core.Types;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MBSoftware.HorseRacing.Core.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RaceMeetingController : ControllerBase
    {
        private IRaceMeetingProvider _dataService;

        public RaceMeetingController(IRaceMeetingProvider dataService)
        {
            _dataService = dataService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var raceMeetings = await _dataService.FetchMeetings();
                return Ok(raceMeetings);
            }
            catch(Exception ex)
            {
                // log..

                return BadRequest("Error fetching race meetings");
            }
        }
    }
}