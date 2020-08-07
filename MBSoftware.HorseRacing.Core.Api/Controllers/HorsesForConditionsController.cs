using System;
using MBSoftwareSolutions.HorseRacing.Core.Types;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MBSoftware.HorseRacing.Core.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HorsesForConditionsController : ControllerBase
    {
        private IHorsesForConditionsProvider _bettingAngleDataService;

        public HorsesForConditionsController(IHorsesForConditionsProvider bettingAngleDataService)
        {
            _bettingAngleDataService = bettingAngleDataService;
        }

        [HttpGet]
        public IActionResult GetHorsesForConditions(DateTime raceDate)
        {
            try
            {
                return new OkObjectResult(_bettingAngleDataService.FetchHorsesForConditions(raceDate.Date));
            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
    }
}