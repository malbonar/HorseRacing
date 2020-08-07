using System;
using System.Collections.Generic;
using System.Linq;

namespace MBSoftwareSolutions.HorseRacing.Core.Types
{
    public class HorseRaceMeeting
    {
        public HorseRaceMeeting()
        {
            Races = new List<RaceCard>();
            Course = "";
        }

        public int RaceId { get; set; }

        public string Course { get; set; }

        public DateTime RaceMeetingDate { get; set; }

        public string Going { get; set; }

        public List<RaceCard> Races { get; set; }

        public static IEnumerable<HorseRaceMeeting> ExtractRaceMeetings(List<RaceCard> races)
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
                        RaceMeetingDate = meetingRaces.First().RaceDate,
                        Going = meetingRaces.First().Going,
                        Races = meetingRaces.OrderBy(x => DateTime.Parse(x.RaceTime + " PM").TimeOfDay).ToList()
                    };

                    meetings.Add(meeting);
                }
            }

            return meetings;
        }
    }
}
