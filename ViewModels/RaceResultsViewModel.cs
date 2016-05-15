using System;
using System.Collections.Generic;
using RaceDirector.Models;

namespace RaceDirector.ViewModels
{
    public class RaceResultsViewModel
    {
        public List<RacerData> Results { get; set; }

        public RaceResultsViewModel()
        {
            Results = new List<RacerData>
        {
            new RacerData
            {
                BestLapTime = TimeSpan.FromMilliseconds(3487),
                Club = "Kaunas",
                CurrentLane = 1,
                LapCount = 78,
                LapTimes = { TimeSpan.FromMilliseconds(3487)},
                Name = "Mantas M."
            },
            new RacerData
            {
                BestLapTime = TimeSpan.FromMilliseconds(3572),
                Club = "Kaunas",
                CurrentLane = 2,
                LapCount = 76,
                LapTimes = { TimeSpan.FromMilliseconds(3572)},
                Name = "Mykolas R."
            },
            new RacerData
            {
                BestLapTime = TimeSpan.FromMilliseconds(3391),
                Club = "Kaunas",
                CurrentLane = 3,
                LapCount = 75,
                LapTimes = { TimeSpan.FromMilliseconds(3391)},
                Name = "Evaldas D."
            }
        };
        }
    }
}