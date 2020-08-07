using System;
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

                // return new StatusCodeResult(StatusCodes.Status500InternalServerError);
                return new OkObjectResult(ex.StackTrace);
            }
        }
    }
}