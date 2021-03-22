using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MBSoftware.HorseRacing.Core.DAL
{
    [Table("RaceResultImportDelayed")]
    public class RaceResult
    {
        [Key]
        [Column("RaceResultImportDelayedId")]
        public int RaceId { get; set; }
        public DateTime RaceDate { get; set; }
        public string Course { get; set; }
        public string RaceTime { get; set; }
        public string RaceName { get; set; }
        public int RaceClass { get; set; }
        public string RaceType { get; set; }
        public string Distance { get; set; }
        public string Going { get; set; }
        public decimal? PrizeMoney { get; set; }
        public bool Maiden { get; set; }
        public bool Handicap { get; set; }

        [Column("AW")]
        public bool AllWeather { get; set; }
        public bool Irish { get; set; }
        public int Grade { get; set; }
    }
}
