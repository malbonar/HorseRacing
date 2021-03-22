using System;
using System.Collections.Generic;
using System.Text;

namespace MBSoftwareSolutions.HorseRacing.Core.Types
{
    public interface IRaceResultsProvider
    {
        List<RaceMeetingResult> FetchRaceMeetingResults(DateTime meetingsDate);
        List<RaceResultHorse> GetHorsesForRaceResult(int raceId);
    }
}
