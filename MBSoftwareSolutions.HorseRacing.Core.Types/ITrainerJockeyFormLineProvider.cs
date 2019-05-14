using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MBSoftwareSolutions.HorseRacing.Core.Types
{
    /// <summary>
    /// abstraction for providing the trainer jockey form statistics
    /// </summary>
    public interface ITrainerJockeyFormLineProvider
    {
        Task<List<TrainerJockeyFormLine>> FetchTrainerJockeyCombo14DayFormAsync(DateTime raceDate);
    }
}
