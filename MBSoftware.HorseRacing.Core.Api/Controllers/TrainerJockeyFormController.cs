using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using MBSoftwareSolutions.HorseRacing.Core.Types;
using Microsoft.AspNetCore.Mvc;

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
        /// api/TrainerJockeyForm?days=14&racedate=16-may-2019
        /// </summary>
        [HttpGet]
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
                return BadRequest("Error occurred during data fetch of Trainer Jockey form data");
            }
        }
    }
}
