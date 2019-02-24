using System;
using System.Collections.Generic;
using System.Linq;

namespace MBSoftwareSolutions.HorseRacing.Core.Types
{
    public class HorseRaceMeeting
    {
        public HorseRaceMeeting()
        {
            Races = new List<HorseRace>();
            Course = "";
        }

        public int RaceMeetingId { get; set; }

        public string Course { get; set; }

        public DateTime RaceDate { get; set; }

        public string Going { get; set; }

        public List<HorseRace> Races { get; set; }

        public static IEnumerable<HorseRaceMeeting> ExtractRaceMeetings(List<HorseRace> races)
        {
            var meetings = new List<HorseRaceMeeting>();

            if (races.Count > 0)
            {
                var courses = races.GroupBy(x => x.Course);
                foreach (var meetingRaces in courses)
                {
                    var meeting = new HorseRaceMeeting
                    {
                        Course = meetingRaces.Key,
                        RaceDate = meetingRaces.First().RaceDate,
                        Going = meetingRaces.First().Going,
                        Races = meetingRaces.ToList()
                    };

                    meetings.Add(meeting);
                }
            }

            return meetings;
        }
    }
}
