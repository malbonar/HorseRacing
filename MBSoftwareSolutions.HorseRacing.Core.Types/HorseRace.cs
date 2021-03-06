﻿using System;
using System.Collections.Generic;

namespace MBSoftwareSolutions.HorseRacing.Core.Types
{
    public class RaceCard
    {
        public RaceCard()
        {
            Horses = new List<HorseRaceRunner>();
            Course = "";
        }

        public int RaceCardId { get; set; }

        public DateTime RaceDate { get; set; }

        public string RaceTime { get; set; }

        public string RaceName { get; set; }

        public string Going { get; set; }

        public string Distance { get; set; }

        public string Course { get; set; }

        public int RaceClass { get; set; }

        public int PrizeMoney { get; set; }
        public bool Maiden { get; set; }
        public bool Handicap { get; set; }
        public bool Hurdle { get; set; }
        public bool Chase { get; set; }
        public bool NHF { get; set; }
        public bool Novice { get; set; }
        public bool Beginners { get; set; }
        public string RaceType { get; set; }
        public bool AW { get; set; }
        public bool Irish { get; set; }
        public string IrishGrade { get; set; }
        public string Grade { get; set; }

        public List<HorseRaceRunner> Horses { get; set; }
    }
}
