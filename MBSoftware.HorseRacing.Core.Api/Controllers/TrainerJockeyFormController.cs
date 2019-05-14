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
        /// api/TrainerJockeyForm
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                // source data is basis UK date so always search basis that timezone
                var britishZone = TimeZoneInfo.FindSystemTimeZoneById("GMT Standard Time");
                var ukDate = TimeZoneInfo.ConvertTime(DateTime.UtcNow, TimeZoneInfo.Utc, britishZone);

                var stats = await _ctx.FetchTrainerJockeyCombo14DayFormAsync(ukDate);
                return Ok(stats);
            }
            catch(Exception ex)
            {
                // log detailed error
                // todo log

                return BadRequest("Error occurred during data fetch of Trainer Jockey form data");
            }
        }
    }
}
