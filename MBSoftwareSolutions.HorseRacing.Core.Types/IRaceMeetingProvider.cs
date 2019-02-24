using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MBSoftwareSolutions.HorseRacing.Core.Types
{
    public interface IRaceMeetingProvider
    {
        Task<List<HorseRaceMeeting>> FetchMeetings();
    }
}
