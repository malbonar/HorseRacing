using AutoMapper;
using MBSoftwareSolutions.HorseRacing.Core.Types;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBSoftware.HorseRacing.Core.DataServices
{
    public class RaceMeetingResultDataService: IRaceResultsProvider
    {
        private IDbContextFactory _dbProvider;

        public RaceMeetingResultDataService(IDbContextFactory dbProvider) => _dbProvider = dbProvider;

        public List<RaceMeetingResult> FetchRaceMeetingResults(DateTime meetingsDate)
        {
            using (var ctx = _dbProvider.GetHorseRatingsDbContext())
            {
                var races = ctx.RaceResults.Where(r => r.RaceDate == meetingsDate).OrderBy(r => r.Course).ThenBy(r => r.RaceTime)
                    .ToList();

                var dalMeetings = (from r in races
                                group r by new { r.RaceDate, r.Course } into grp
                                select new DAL.RaceMeetingResult
                                {
                                    RaceMeetingDate = grp.Key.RaceDate,
                                    Course = grp.Key.Course,
                                    Races = grp.Select(r => r).ToList()
                                })
                            .ToList();

                dalMeetings.ForEach(m => m.Going = m.Races.FirstOrDefault()?.Going);

                var meetings = Mapper.Map<List<RaceMeetingResult>>(dalMeetings);

                return meetings;
            }
        }

        public List<RaceResultHorse> GetHorsesForRaceResult(int raceId)
        {
            using (var ctx = _dbProvider.GetHorseRatingsDbContext())
            {
                if (!ctx.RaceResultHorses.Any(r => r.RaceId == raceId))
                    return new List<RaceResultHorse>();

                List<DAL.RaceResultHorse> horses = ctx.RaceResultHorses.Where(r => r.RaceId == raceId).ToList();

                return Mapper.Map<List<RaceResultHorse>>(horses); // map DAL model to app model
            }
        }
    }
}
