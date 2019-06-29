using System;
using System.Collections.Generic;

namespace MBSoftware.HorseRacing.Core.DAL
{
    public partial class HorseRaceRunner
    {
        public int HorseRaceRunnerId { get; set; }
        public string HorseName { get; set; }
        public int FineFormWithClassAdj { get; set; }
        public string DistanceForm { get; set; }
        public string ClassForm { get; set; }
        public string CourseForm { get; set; }
        public string DirectionForm { get; set; }
        public string GoingForm { get; set; }
        public string JockeyHorseSummary { get; set; }
        public int? Ts { get; set; }
        public int? Rpr { get; set; }
        public decimal TissueTotal { get; set; }
        public decimal TissueOdds { get; set; }
        public int? HorseRaceWebEntityHorseRaceWebEntityId { get; set; }
        public int? PosLto { get; set; }
        public int? Ormove { get; set; }
        public int? ClassMove { get; set; }
        public int OfficialRating { get; set; }
        public string Weight { get; set; }
        public string Trainer { get; set; }
        public string Jockey { get; set; }
        public int? Age { get; set; }
        public string Form { get; set; }
        public string Odds { get; set; }

        public virtual HorseRace HorseRaceWebEntityHorseRaceWebEntity { get; set; }
    }
}