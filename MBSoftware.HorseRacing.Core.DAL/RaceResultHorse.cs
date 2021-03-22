
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MBSoftware.HorseRacing.Core.DAL
{
    [Table("RaceResultImportDelayedHorse")]
    public class RaceResultHorse
    {
        [Key]
        [Column("RaceResultImportDelayedHorseId")]
        public int HorseId { get; set; }

        [Column("RaceResultImportDelayedId")]
        public int RaceId { get; set; }

        public string HorseName { get; set; }
        public string Odds { get; set; }
        public int Position { get; set; }
        public string Trainer { get; set; }
        public string Jockey { get; set; }
        public int JockeyClaim { get; set; }
        public int OfficialRating { get; set; }
        public string Weight { get; set; }
        public int TS { get; set; }
        public int RPR { get; set; }
        public string FailedToFinishReason { get; set; }
        public string DistanceBeaten { get; set; }
        public int Age { get; set; }
        public string Comment { get; set; }
        public string HeadGear { get; set; }
    }
}
