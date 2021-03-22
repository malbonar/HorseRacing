using System;
using MBSoftwareSolutions.HorseRacing.Core.Types;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MBSoftware.HorseRacing.Core.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HorsesForConditionsController : ControllerBase
    {
        private IHorsesForConditionsProvider _bettingAngleDataService;
        private readonly ILogger<HorsesForConditionsController> _logger;

        public HorsesForConditionsController(IHorsesForConditionsProvider bettingAngleDataService,
            ILogger<HorsesForConditionsController> logger) =>
            (_bettingAngleDataService, _logger) = (bettingAngleDataService, logger);

        /// <summary>
        /// Fetches betting angle for horses that have won in similar conditions
        /// </summary>
        /// <param name="raceDate">Basis date for form calculation</param>
        /// <returns>Horse rating basis same race conditions</returns>
        /// <response code="200">Returns Trainer / Jockey form analysis</response>
        /// <response code="500">Internal error processing the request</response>
        [HttpGet]
        public IActionResult GetHorsesForConditions(DateTime raceDate)
        {
            try
            {
                return new OkObjectResult(_bettingAngleDataService.FetchHorsesForConditions(raceDate.Date));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to GET HorsesForConditions: {ex.InnerException?.Message ?? ex.Message}");
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
    }
}