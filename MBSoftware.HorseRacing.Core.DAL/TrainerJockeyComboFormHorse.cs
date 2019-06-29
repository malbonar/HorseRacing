using System;
using System.Collections.Generic;

namespace MBSoftware.HorseRacing.Core.DAL
{
    public partial class TrainerJockeyComboFormHorse
    {
        public int TrainerJockeyComboFormHorseId { get; set; }
        public int TrainerJockeyComboFormEntityId { get; set; }
        public DateTimeOffset RaceDate { get; set; }
        public string Course { get; set; }
        public string RaceTime { get; set; }
        public string HorseName { get; set; }
        public int? RaceNo { get; set; }
        public int? Age { get; set; }
        public string Weight { get; set; }
        public string Form { get; set; }
        public string Odds { get; set; }

        public virtual TrainerJockeyComboFormWebEntities TrainerJockeyComboFormEntity { get; set; }
    }
}