using System;
using MBSoftwareSolutions.HorseRacing.Core.Types;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MBSoftware.HorseRacing.Core.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RaceResultsController : ControllerBase
    {
        private IRaceResultsProvider _raceResultsProvider;

        public RaceResultsController(IRaceResultsProvider raceResultsProvider) 
        {
            _raceResultsProvider = raceResultsProvider; 
        }

        /// <summary>
        /// Fetch race meetings for date in the past
        /// </summary>
        /// <param name="meetingsDate"></param>
        /// <returns>Horse Race Meetings</returns>
        /// <response code="200">Returns Horse Race meetings for selected date</response>
        /// <response code="500">Internal error processing the request</response>
        [HttpGet]
        [Route("GetRaceMeetings/{meetingsDate}")]
        public IActionResult GetRaceMeetings(DateTime meetingsDate)
        {
            var results = _raceResultsProvider.FetchRaceMeetingResults(meetingsDate);
            return new OkObjectResult(results);
        }

        /// <summary>
        /// Fetch the horses that ran in a race
        /// </summary>
        /// <param name="raceId">Identifier of race</param>
        /// <returns>Horses that ran in the race</returns>
        /// <response code="200">Returns horses than ran in the race</response>
        /// <response code="204">No horses found for this race id</response>
        /// <response code="500">Internal error processing the request</response>
        [HttpGet]
        [Route("GetHorsesForRaceResult/{raceId}")]
        public IActionResult GetHorsesForRaceResult(int raceId)
        {
            var results = _raceResultsProvider.GetHorsesForRaceResult(raceId);
            if (results.Count == 0)
                return new NoContentResult();

            return new OkObjectResult(results);
        }
    }
}
