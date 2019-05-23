using System;
using System.Threading.Tasks;
using MBSoftwareSolutions.HorseRacing.Core.Types;
using Microsoft.AspNetCore.Mvc;

namespace MBSoftware.HorseRacing.Core.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainerJockeyFormController : ControllerBase
    {
        private ITrainerJockeyFormLineProvider _ctx;

        public TrainerJockeyFormController(ITrainerJockeyFormLineProvider ctx)
        {
            _ctx = ctx;            
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
                // log detailed error
                // todo log

                return BadRequest("Error occurred during data fetch of Trainer Jockey form data");
            }
        }
    }
}
