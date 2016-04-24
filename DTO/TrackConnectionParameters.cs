using System.Collections.Generic;

namespace RaceDirector.DTO
{
    public class TrackConnectionParameters
    {
        public string Port { get; set; }
        public int BaudRate { get; set; }
        public int MinTime { get; set; }
        public List<LanePin> LanePins { get; set; }
    }
}