using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MBSoftwareSolutions.HorseRacing.Core.Types
{
    public interface IRaceCardProvider
    {
        Task<List<HorseRaceRunner>> FetchHorsesForRace(int raceId);
        RaceCard FetchRaceCard(string course, string raceTime);
        List<HorsePreviousRun> FetchHorseHistoryForRace(int raceId);
    }
}
