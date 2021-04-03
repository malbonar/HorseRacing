using System;
using System.Collections.Generic;

namespace MBSoftwareSolutions.HorseRacing.Core.Types
{
    public class RaceMeetingResult
    {
        public RaceMeetingResult()
        {
            Races = new List<RaceResult>();
        }

        public DateTime RaceMeetingDate { get; set; }
        public string Course { get; set; }
        public string Going { get; set; }
        public List<RaceResult> Races { get; set; }
    }
}
