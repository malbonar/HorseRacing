using System;
using System.Collections.Generic;
using System.Text;

namespace MBSoftwareSolutions.HorseRacing.Core.Types
{
    public class HorseRace
    {
        public HorseRace()
        {
            Runners = new List<HorseRaceRunner>();
            Course = "";
        }

        public int RaceId { get; set; }

        public DateTime RaceDate { get; set; }
        public string Course { get; set; }
        public string Going { get; set; }
        public string RaceTime { get; set; }

        private string _raceName = "";
        public string RaceName
        {
            get { return _raceName; }
            set
            {
                _raceName = value;
                if (!string.IsNullOrEmpty(value))
                {
                    var sb = new StringBuilder();
                    var uppercaseName = value.ToUpper();

                    if (uppercaseName.Contains("MAIDEN"))
                        sb.Append("Maiden ");

                    if (uppercaseName.Contains("SELLER"))
                        sb.Append("Seller");

                    if (uppercaseName.Contains("NOVICE"))
                        sb.Append("Novice ");

                    if (uppercaseName.Contains("HANDICAP"))
                        sb.Append("Hcp ");

                    if (uppercaseName.Contains("HURDLE"))
                        sb.Append("Hurdle ");

                    if (uppercaseName.Contains("CHASE"))
                        sb.Append("Chase");

                    if (uppercaseName.Contains("National Hunt Flat"))
                        sb.Append("NHF");
                    else
                    {
                        if (uppercaseName.Contains("NHF"))
                            sb.Append("NHF");
                    }

                    if (sb.Length == 0)
                        sb.Append("Flat");

                    ShortRaceName = sb.ToString();
                }
            }
        }

        public int RaceClass { get; set; }
        public int PrizeMoney { get; set; }
        public int NoRunners { get; set; }

        public string RaceDistance { get; set; }

        public string ShortRaceName { get; private set; }

        public bool Irish { get { return Course.ToUpper().Contains("(IRE)"); } }

        public bool Maiden { get { return Course.ToUpper().Trim().Contains("MAIDEN"); } }

        public bool AW
        {
            get
            {
                return Course.ToUpper().Contains("(AW)");
            }
        }

        public bool Handicap { get { return Course.ToUpper().Trim().Contains("HANDICAP"); } }

        public bool Novice { get { return Course.ToUpper().Trim().Contains("NOVICES"); } }

        public bool IsBestPerformingRace { get; set; }

        public List<HorseRaceRunner> Runners { get; set; }
    }
}
