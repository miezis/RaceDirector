using System.Collections.Generic;
using System.Windows.Documents;

namespace RaceDirector.DTO
{
    public class TrackConnectionParameters
    {
        public string Port { get; set; }
        public int BaudRate { get; set; }
        public int MinTime { get; set; }
        public List<int> LanePins { get; set; }
    }
}