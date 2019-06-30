using AutoMapper;
using MBSoftwareSolutions.HorseRacing.Core.Types;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MBSoftware.HorseRacing.Core.DataServices
{
    /// <summary>
    /// Access data for the TrainerJockey form
    /// Implements an interface abstraction that is available to controller via DI in startup class
    /// </summary>
    public class TrainerJockeyFormDataService : ITrainerJockeyFormLineProvider
    {
        private IDbContextFactory _dbProvider;
        private readonly ILogger<TrainerJockeyFormDataService> _logger;

        public TrainerJockeyFormDataService(IDbContextFactory dbProvider, ILogger<TrainerJockeyFormDataService> logger)
        {
            _dbProvider = dbProvider;
            _logger = logger;
        }
                
        public async Task<List<TrainerJockeyFormLine>> FetchTrainerJockeyCombo14DayFormAsync(DateTime raceDate)
        {
            using(var ctx = _dbProvider.GetHorseRatingsDbContext())
            {
                try
                {
                    // use automapper to map from Entity class to POCO class
                    var formLines = await ctx.TrainerJockeyComboFormWebEntities
                        .Include(x => x.TrainerJockeyComboFormHorse)
                        .Where(x => x.RaceDate.Date == raceDate.Date)
                        .Select(x => Mapper.Map<TrainerJockeyFormLine>(x))
                        .ToListAsync();
                    return formLines;
                }
                catch(Exception ex)
                {
                    // log
                    return new List<TrainerJockeyFormLine>();
                }
            }
        }

        public async Task<List<TrainerJockeyFormLine>> FetchTrainerJockeyComboFormAsync(int days, DateTime raceDate)
        {
            using (var ctx = _dbProvider.GetHorseRatingsDbContext())
            {
                try
                {
                    // use automapper to map from Entity class to POCO class
                    var formLines = await ctx.TrainerJockeyComboFormWebEntities
                        .Include(x => x.TrainerJockeyComboFormHorse)
                        .Where(x => x.RaceDate.Date == raceDate.Date && x.Days == days)
                        .Select(x => Mapper.Map<TrainerJockeyFormLine>(x))
                        .ToListAsync();

                    formLines = formLines.OrderBy(x => x.Trainer).ThenBy(x => x.Jockey).ToList();
                    formLines.ForEach(f =>
                    {
                        f.TrainerJockeyComboFormHorse = f.TrainerJockeyComboFormHorse.OrderBy(h => h.Course).ThenBy(h => h.RaceTime).ToList();
                    });

                    return formLines;
                }
                catch (Exception ex)
                {
                    _logger.LogError("FetchTrainerJockeyComboFormAsync threw exception", ex);
                    return new List<TrainerJockeyFormLine>();
                }
            }
        }
    }
}
