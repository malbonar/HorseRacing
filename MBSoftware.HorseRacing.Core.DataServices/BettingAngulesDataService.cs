using MBSoftwareSolutions.HorseRacing.Core.Types;
using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using AutoMapper;

namespace MBSoftware.HorseRacing.Core.DataServices
{
    public class BettingAngulesDataService: IHorsesForConditionsProvider
    {
        private IDbContextFactory _dbProvider;
        private readonly ILogger<BettingAngulesDataService> _logger;
        public BettingAngulesDataService(IDbContextFactory dbProvider, ILogger<BettingAngulesDataService> logger)
        {
            _dbProvider = dbProvider;
            _logger = logger;
        }

        public List<HorseForConditions> FetchHorsesForConditions(DateTime raceDate)
        {
            using (var ctx = _dbProvider.GetHorseRatingsDbContext())
            {
                try
                {
                    // use automapper to map from Entity class to POCO class
                    var bettingAngles = ctx.HorsesForConditions
                        .Where(x => x.RaceDate.Date == raceDate.Date)
                        .Select(x => Mapper.Map<HorseForConditions>(x))
                        .OrderByDescending(x => x.Score)
                        .ToList();
                    return bettingAngles;
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Error fetching HorsesForConditions. {ex.InnerException?.Message ?? ex.Message}");
                    return new List<HorseForConditions>();
                }
            }
        }
    }
}
