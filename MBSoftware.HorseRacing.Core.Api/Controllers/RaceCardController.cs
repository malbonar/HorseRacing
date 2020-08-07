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