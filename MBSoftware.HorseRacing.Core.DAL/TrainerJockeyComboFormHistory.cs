using System;
using System.Collections.Generic;

namespace MBSoftware.HorseRacing.Core.DAL
{
    public partial class TrainerJockeyComboFormHistory
    {
        public int TrainerJockeyComboFormHistoryId { get; set; }
        public int TrainerJockeyComboFormEntityId { get; set; }
        public DateTimeOffset RaceDate { get; set; }
        public string RaceTime { get; set; }
        public string Course { get; set; }
        public int? RaceClass { get; set; }
        public bool Handicap { get; set; }
        public string RaceType { get; set; }
        public bool Aw { get; set; }
        public string HorseName { get; set; }
        public string Trainer { get; set; }
        public string Jockey { get; set; }
        public string Odds { get; set; }
        public int? OddsRank { get; set; }
        public int? PositionVersusOddsRank { get; set; }
        public int Position { get; set; }

        public virtual TrainerJockeyComboFormWebEntities TrainerJockeyComboFormEntity { get; set; }
    }
}