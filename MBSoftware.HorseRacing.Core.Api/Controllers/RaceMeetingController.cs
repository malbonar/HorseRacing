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

        /// <summary>
        /// Fetch all meetings for specified date
        /// </summary>
        /// <returns>All race meetings for specified date</returns>
        /// <response code="200">race meetings for specified date</response>
        /// <response code="500">Internal error processing the request</response>
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