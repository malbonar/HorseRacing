using System;
using System.Collections.Generic;

namespace MBSoftware.HorseRacing.Core.DAL
{
    public partial class HorseRace
    {
        public HorseRace()
        {
            HorseRaceRunner = new HashSet<HorseRaceRunner>();
        }

        public int HorseRaceId { get; set; }
        public DateTime RaceDate { get; set; }
        public string Course { get; set; }
        public string RaceTime { get; set; }
        public string RaceName { get; set; }
        public int RaceClass { get; set; }
        public int? PrizeMoney { get; set; }
        public int NoRunners { get; set; }
        public string Going { get; set; }
        public bool IsTissueBestPerformingRace { get; set; }
        public string RaceDistance { get; set; }

        public virtual ICollection<HorseRaceRunner> HorseRaceRunner { get; set; }
    }
}
