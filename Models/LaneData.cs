using System.Collections.Generic;

namespace RaceDirector.Models
{
    public class LaneData
    {
        public int LaneCount { get; set; }
        public int BestLapTime { get; set; }
        public List<int> LapTimes { get; set; }
    }
}