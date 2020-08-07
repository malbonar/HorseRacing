using AutoMapper;
using MBSoftwareSolutions.HorseRacing.Core.Types;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MBSoftware.HorseRacing.Core.DataServices
{
    public class RaceMeetingDataService : IRaceMeetingProvider, IRaceCardProvider
    {
        private IDbContextFactory _dbProvider;

        public RaceMeetingDataService(IDbContextFactory dbProvider)
        {
            _dbProvider = dbProvider;
        }

        public async Task<List<HorseRaceMeeting>> FetchMeetings()
        {
            var meetings = new List<HorseRaceMeeting>();

            using (var ctx = _dbProvider.GetHorseRatingsDbContext())
            {
                var races = await ctx.RaceCard.Select(x => Mapper.Map<RaceCard>(x)).ToListAsync();
                meetings = HorseRaceMeeting.ExtractRaceMeetings(races)
                    .OrderBy(x => x.Course)
                    .ToList();
            }

            return meetings;
        }

        /// <summary>
        /// Fetch the horses for a given race.
        /// Usage is required as not returning any horses when viewing the race meetings
        /// </summary>
        /// <param name="raceId">Identifies the race</param>
        /// <returns>Horses for a given race</returns>
        public async Task<List<HorseRaceRunner>> FetchHorsesForRace(int raceId)
        {
            var horses = new List<HorseRaceRunner>();

            using (var ctx = _dbProvider.GetHorseRatingsDbContext())
            {
                horses = await ctx.RaceCardHorse
                    .Where(x => x.RaceCardId == raceId)
                    .Select(x => Mapper.Map<HorseRaceRunner>(x))
                    .ToListAsync();
            }

            return horses;
        }
        
        /// <summary>
        /// Fetch a race for a given course and time. The date is set as only one loaded in the db
        /// </summary>
        /// <param name="course"></param>
        /// <param name="raceTime"></param>
        /// <returns></returns>
        public RaceCard FetchRaceCard(string course, string raceTime)
        {
            var raceCard = new RaceCard();

            using (var ctx = _dbProvider.GetHorseRatingsDbContext())
            {
                raceCard = ctx.RaceCard
                    .Include(x => x.RaceCardHorse)
                    .Where(x => x.Course == course && x.RaceTime == raceTime)
                    .Select(x => Mapper.Map<RaceCard>(x)).FirstOrDefault();
            }

            return raceCard;
        }

        /// <summary>
        /// Fetches previous run history of all horses for a single race.
        /// The previous run data is populated by Azure functions
        /// </summary>
        /// <param name="raceId">Identifier for the race, which is passed to the filter for horse previous runs</param>
        /// <returns>Previous runs of all horses running in this race</returns>
        public List<HorsePreviousRun> FetchHorseHistoryForRace(int raceId)
        {
            var previousRuns = new List<HorsePreviousRun>();

            using (var ctx = _dbProvider.GetHorseRatingsDbContext())
            {
                previousRuns = ctx.RaceCardHorseHistory
                    .Where(x => x.SourceRaceId == raceId)
                    .Select(x => Mapper.Map<HorsePreviousRun>(x))
                    .ToList();
            }

            return previousRuns;
        }
    }
}
