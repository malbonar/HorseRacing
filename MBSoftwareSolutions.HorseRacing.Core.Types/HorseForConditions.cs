using System;

namespace MBSoftwareSolutions.HorseRacing.Core.Types
{
    public class HorseForConditions
    {
        public DateTime RaceDate { get; set; }
        public string RaceTime { get; set; }
        public string Course { get; set; }
        public string HorseName { get; set; }
        public string Odds { get; set; }
        public int GoingRuns { get; set; }
        public int GoingWins { get; set; }
        public int GoingScore { get; set; }
        public decimal GoingWinPercent { get; set; }
        public int ClassRuns { get; set; }
        public int ClassWins { get; set; }
        public int ClassScore { get; set; }
        public decimal ClassWinPercent { get; set; }
        public int DistRuns { get; set; }
        public int DistWins { get; set; }
        public int DistScore { get; set; }
        public decimal DistWinPercent { get; set; }
        public int CourseRuns { get; set; }
        public int CourseWins { get; set; }
        public int CourseScore { get; set; }
        public decimal CourseWinPercent { get; set; }
        public int Score { get; set; }
        public int TotalWins { get; set; }
        public string ResultOdds { get; set; }
        public int? Position { get; set; }
        public bool? Placed { get; set; }
        public decimal? ProfitLoss { get; set; }
    }
}
