using System;
using System.Collections.Generic;

namespace MBSoftwareSolutions.HorseRacing.Core.Types
{
    /// <summary>
    /// Trainer Jockey combination statistic
    /// Simple POCO class representation of the row data stored in the database
    /// </summary>
    public class TrainerJockeyFormLine
    {
        public int TrainerJockeyComboFormEntityId { get; set; }
        public string Trainer { get; set; }
        public string Jockey { get; set; }
        public int Runs { get; set; }
        public int Wins { get; set; }
        public int Placed { get; set; }
        public decimal WinPercent { get; set; }
        public decimal PlacedPercent { get; set; }
        public decimal WinProfitLoss { get; set; }
        public decimal PlacedProfitLoss { get; set; }
        public decimal AE { get; set; }
        public decimal IV { get; set; }
        public int Days { get; set; }
        public DateTime RaceDate { get; set; }
        public List<TrainerJockeyFormLineHorse> TrainerJockeyComboFormHorse { get; set; }

        public TrainerJockeyFormLine()
        {
            TrainerJockeyComboFormHorse = new List<TrainerJockeyFormLineHorse>();
        }
    }
}
