using System;

namespace MBSoftwareSolutions.HorseRacing.Core.Types
{
    public class HorsePreviousRun
    {
        public int RaceCardHorseHistoryId { get; set; }
        public int SourceRaceId { get; set; }
        public DateTime RaceDate { get; set; }
        public string RaceTime { get; set; }
        public string RaceName { get; set; }
        public int RaceClass { get; set; }
        public string Going { get; set; }
        public string Distance { get; set; }
        public bool Novice { get; set; }
        public bool Maiden { get; set; }
        public bool Handicap { get; set; }
        public bool Hurdle { get; set; }
        public bool Chase { get; set; }
        public bool NHF { get; set; }
        public string RaceType { get; set; }
        public bool AW { get; set; }
        public int Grade { get; set; }
        public bool Irish { get; set; }
        public string IrishGrade { get; set; }
        public decimal? PrizeMoney { get; set; }
        public string HorseName { get; set; }
        public string Odds { get; set; }
        public int Position { get; set; }
        public bool? Placed { get; set; }
        public string FailedToFinishReason { get; set; }
        public string DistanceBeaten { get; set; }
        public int Age { get; set; }
        public string Comment { get; set; }
        public string Trainer { get; set; }
        public string Jockey { get; set; }
        public int JockeyClaim { get; set; }
        public string HeadGear { get; set; }
        public int OfficialRating { get; set; }
        public int? TS { get; set; }
        public int? RPR { get; set; }
        public string Weight { get; set; }
        public int? PaceValue { get; set; }
        public decimal? DecimalOdds { get; set; }
        public decimal? ProfitLoss { get; set; }
        public string Course { get; set; }
    }
}
