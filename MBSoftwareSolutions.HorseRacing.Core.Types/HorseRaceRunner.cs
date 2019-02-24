using System.Linq;

namespace MBSoftwareSolutions.HorseRacing.Core.Types
{
    public class HorseRaceRunner
    {
        private const int MaxRedWinPercent = 15;
        private const int MinAmberWinPercent = 16;
        private const int MaxAmberWinPercent = 32;
        private const int MinGreenWinPercent = 33;

        public string HorseName { get; set; }
        public int FineFormWithClassAdj { get; set; }

        private string _distanceForm = "";
        public string DistanceForm
        {
            get { return _distanceForm; }
            set
            {
                _distanceForm = value;

                string[] parts = value.Split('-');
                if (parts.Count() == 2)
                {
                    int iWins;
                    int.TryParse(parts[1], out iWins);

                    int iRuns;
                    int.TryParse(parts[0], out iRuns);
                    DistanceRuns = iRuns;

                    DistanceWinPercent = iWins > 0 && iRuns > 0 ? (decimal)((decimal)iWins / (decimal)iRuns) * 100 : 0;
                }
            }
        }

        public int DistanceRuns { get; private set; }

        private string _classForm = "";
        public string ClassForm
        {
            get { return _classForm; }
            set
            {
                _classForm = value;

                string[] parts = ClassForm.Split('-');
                if (parts.Count() == 2)
                {
                    int iWins;
                    int.TryParse(parts[1], out iWins);

                    int iRuns;
                    int.TryParse(parts[0], out iRuns);
                    ClassRuns = iRuns;

                    ClassWinPercent = iWins > 0 && iRuns > 0 ? (decimal)((decimal)iWins / (decimal)iRuns) * 100 : 0;
                }
            }
        }

        public int ClassRuns { get; private set; }

        private string _courseForm = "";
        public string CourseForm
        {
            get { return _courseForm; }
            set
            {
                _courseForm = value;

                string[] parts = value.Split('-');
                if (parts.Count() == 2)
                {
                    int iWins;
                    int.TryParse(parts[1], out iWins);

                    int iRuns;
                    int.TryParse(parts[0], out iRuns);
                    CourseRuns = iRuns;

                    CourseWinPercent = iWins > 0 && iRuns > 0 ? (decimal)((decimal)iWins / (decimal)iRuns) * 100 : 0;
                }
            }
        }

        public int CourseRuns { get; private set; }

        private string _directionForm = "";
        public string DirectionForm
        {
            get { return _directionForm; }
            set
            {
                _directionForm = value;

                //string[] parts = value.Split('-');
                //if (parts.Count() == 2)
                //{
                //    int iWins;
                //    int.TryParse(parts[1], out iWins);

                //    int iRuns;
                //    int.TryParse(parts[0], out iRuns);
                //    DirectionRuns = iRuns;

                //    DirectionWinPercent = iWins > 0 && iRuns > 0 ? (decimal)((decimal)iWins / (decimal)iRuns) * 100 : 0;
                //}
            }
        }

        public int DirectionRuns { get; private set; }

        public decimal DirectionWinPercent { get; private set; }

        private string _goingForm = "";
        public string GoingForm
        {
            get { return _goingForm; }
            set
            {
                _goingForm = value;

                string[] parts = value.Split('-');
                if (parts.Count() == 2)
                {
                    int iWins;
                    int.TryParse(parts[1], out iWins);

                    int iRuns;
                    int.TryParse(parts[0], out iRuns);
                    GoingRuns = iRuns;

                    GoingWinPercent = iWins > 0 && iRuns > 0 ? (decimal)((decimal)iWins / (decimal)iRuns) * 100 : 0;
                }
            }
        }

        public int GoingRuns { get; private set; }

        private string _jockeyHorseSummary = "";
        public string JockeyHorseSummary
        {
            get { return _jockeyHorseSummary; }
            set
            {
                _jockeyHorseSummary = value;

                string[] parts = value.Split('-');
                if (parts.Count() >= 2)
                {
                    int iWins;
                    int.TryParse(parts[1], out iWins);

                    int iRuns;
                    int.TryParse(parts[0], out iRuns);
                    JockeyHorseRuns = iRuns;

                    JockeyHorseWinPercent = iWins > 0 && iRuns > 0 ? (decimal)((decimal)iWins / (decimal)iRuns) * 100 : 0;
                }
            }
        }
        public decimal JockeyHorseWinPercent { get; private set; }
        public int JockeyHorseRuns { get; private set; }

        public int TS { get; set; }
        public int RPR { get; set; }

        public decimal TissueTotal { get; set; }

        public decimal TissueOdds { get; set; }
        public decimal ClassWinPercent { get; set; }
        public decimal CourseWinPercent { get; set; }
        public decimal GoingWinPercent { get; set; }
        public decimal DistanceWinPercent { get; set; }

        public string PosLto { get; set; }

        public string ORMove { get; set; }

        public string ClassMove { get; set; }

        public int OfficialRating { get; set; }

        public string Weight { get; set; }
    }
}
