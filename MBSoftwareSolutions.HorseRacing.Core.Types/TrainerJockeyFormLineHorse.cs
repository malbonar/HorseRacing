using System;

namespace MBSoftwareSolutions.HorseRacing.Core.Types
{
    /// <summary>
    /// POCO class for a horse running in a race today where the trainer jockey combination is on the Trainer Jockey combo report.
    /// Maps to EF TrainerJockeyComboFormHorse class via AutoMapper
    /// </summary>
    public class TrainerJockeyFormLineHorse
    {
        public int TrainerJockeyComboFormHorseId { get; set; }
        public int TrainerJockeyComboFormId { get; set; }
        public DateTime RaceDate { get; set; }
        public string Course { get; set; }
        public string RaceTime { get; set; }
        public string HorseName { get; set; }
        public int? RaceNo { get; set; }
        public int? Age { get; set; }
        public string Weight { get; set; }
        public string Form { get; set; }
        public string Odds { get; set; }
    }
}
