using AutoMapper;
using MBSoftwareSolutions.HorseRacing.Core.Types;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MBSoftware.HorseRacing.Core.DataServices
{
    public class RaceMeetingDataService : IRaceMeetingProvider
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
                var races = await ctx.HorseRace.Select(x => Mapper.Map<HorseRace>(x)).ToListAsync();
                meetings = HorseRaceMeeting.ExtractRaceMeetings(races).ToList();
            }

            return meetings;
        }
    }
}
