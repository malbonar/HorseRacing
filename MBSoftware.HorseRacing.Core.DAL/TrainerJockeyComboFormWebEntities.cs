using System;
using System.Collections.Generic;

namespace MBSoftware.HorseRacing.Core.DAL
{
    /// <summary>
    /// EF class representing row from the table of the same name
    /// </summary>
    public partial class TrainerJockeyComboFormWebEntities
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
        public decimal Ae { get; set; }
        public decimal Iv { get; set; }
        public int Days { get; set; }
        public DateTime RaceDate { get; set; }
    }
}
