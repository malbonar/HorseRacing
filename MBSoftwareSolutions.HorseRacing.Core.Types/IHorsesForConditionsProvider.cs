using System;
using System.Collections.Generic;
using System.Text;

namespace MBSoftwareSolutions.HorseRacing.Core.Types
{
    public interface IHorsesForConditionsProvider
    {
        List<HorseForConditions> FetchHorsesForConditions(DateTime raceDate);
    }
}
