using AutoMapper;
using MBSoftwareSolutions.HorseRacing.Core.Types;
using Microsoft.EntityFrameworkCore;
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

        public TrainerJockeyFormDataService(IDbContextFactory dbProvider)
        {
            _dbProvider = dbProvider;
        }
                
        public async Task<List<TrainerJockeyFormLine>> FetchTrainerJockeyCombo14DayFormAsync()
        {
            using(var ctx = _dbProvider.GetHorseRatingsDbContext())
            {
                // use automapper to map from Entity class to POCO class
                var formLines = await ctx.TrainerJockeyComboFormWebEntities.Select(x => Mapper.Map<TrainerJockeyFormLine>(x))
                    .ToListAsync();
                return formLines;
            }
        }
    }
}
