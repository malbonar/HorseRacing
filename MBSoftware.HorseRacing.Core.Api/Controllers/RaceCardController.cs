using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MBSoftwareSolutions.HorseRacing.Core.Types;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MBSoftware.HorseRacing.Core.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RaceCardController : ControllerBase
    {
        private IRaceCardProvider _raceCardProvider;

        public RaceCardController(IRaceCardProvider raceCardProvider)
        {
            _raceCardProvider = raceCardProvider;
        }

        /// <summary>
        /// Fetch Horses for race on today's card. Authorised access
        /// </summary>
        /// <param name="id">Race Identifier</param>
        /// <returns>Horses declared to run in this race</returns>
        /// <response code="200">Returns runners for race</response>
        /// <response code="401">Unauthorised access. Request must be made from known application</response>
        /// <response code="500">Internal error processing the request</response>
        [HttpGet]
        [Route("{id}/horses")]
        [Authorize(Policy = "read:racecards")]
        public async Task<IActionResult> FetchHorses(int id)
        {
            try
            {
                return new OkObjectResult(await _raceCardProvider.FetchHorsesForRace(id));
            }
            catch(Exception ex)
            {
                // todo - log
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// Fetch details for a horse race on today's card. Authorised access
        /// </summary>
        /// <param name="course">Course where horse race is to be run</param>
        /// <param name="raceTime">Time race will be run</param>
        /// <returns>Race details</returns>
        /// <response code="200">Returns race details</response>
        /// <response code="401">Unauthorised access. Request must be made from known application</response>
        /// <response code="500">Internal error processing the request</response>
        [HttpGet]
        [Authorize(Policy = "read:racecards")]
        public IActionResult GetRaceCard(string course, string raceTime)
        {
            try
            {
                return new OkObjectResult(_raceCardProvider.FetchRaceCard(course, raceTime));
            }
            catch (Exception ex)
            {
                // todo - log
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// Fetch previous runs of all horses in a race from today's card. Authorised access
        /// </summary>
        /// <param name="raceId"></param>
        /// <returns></returns>
        /// <response code="200">Returns previous runs of all horses in race</response>
        /// <response code="401">Unauthorised access. Request must be made from known application</response>
        /// <response code="500">Internal error processing the request</response>
        [HttpGet]
        [Authorize(Policy = "read:racecards")]
        [Route("GetPreviousRuns/{raceId}")]
        public IActionResult GetPreviousRuns(int raceId)
        {
            try
            {
                return new OkObjectResult(_raceCardProvider.FetchHorseHistoryForRace(raceId));
            }
            catch (Exception ex)
            {
                // todo - log
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
    }
}