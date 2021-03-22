using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using MBSoftwareSolutions.HorseRacing.Core.Types;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace MBSoftware.HorseRacing.Core.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainerJockeyFormController : ControllerBase
    {
        private ITrainerJockeyFormLineProvider _ctx;
        private readonly ILogger<TrainerJockeyFormController> _logger;

        public TrainerJockeyFormController(ITrainerJockeyFormLineProvider ctx, ILogger<TrainerJockeyFormController> logger)
        {
            _ctx = ctx;
            _logger = logger;
        }

        /// <summary>
        /// Fetch Trainer / Jockey form analysis basis a specified date and either 14 or 30 day form. Authorised access
        /// </summary>
        /// <param name="days">form basis 14 or 30 days</param>
        /// <param name="raceDate">Form data as at this date</param>
        /// <returns>Trainer / Jockey form analysis</returns>
        /// <response code="200">Returns Trainer / Jockey form analysis</response>
        /// <response code="401">Unauthorised access. Request must be made from known application</response>
        /// <response code="500">Internal error processing the request</response>
        [HttpGet]
        [Authorize(Policy = "read:trainerjockeystats")]
        public async Task<IActionResult> Get(int days, DateTime raceDate)
        {
            try
            {
                var stats = await _ctx.FetchTrainerJockeyComboFormAsync(days, raceDate);
                return Ok(stats);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to GET TrainerJockeyForm: {ex.InnerException?.Message ?? ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// Fetch Trainer / Jockey form analysis basis most recent loaded date and either 14 or 30 day form. Authorised access
        /// </summary>
        /// <param name="days"></param>
        /// <returns>Trainer / Jockey form analysis</returns>
        /// <response code="200">Returns Trainer / Jockey form analysis</response>
        /// <response code="401">Unauthorised access. Request must be made from known application</response>
        /// <response code="500">Internal error processing the request</response>
        [HttpGet]
        //[ResponseCache(VaryByQueryKeys = ["days"])]
        [Route("GetLatest")]
        [Authorize(Policy = "read:trainerjockeystats")]
        public async Task<IActionResult> GetLatest(int days)
        {
            try
            {
                var stats = await _ctx.FetchTrainerJockeyComboFormAsync(days);
                return Ok(stats);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to GET TrainerJockeyForm: {ex.InnerException?.Message ?? ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
