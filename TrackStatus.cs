namespace RaceDirector
{
    public static class TrackStatus
    {
        static TrackStatus()
        {
            LaneCount = 1;
            LanesSet = 0;
            MinTimeSet = false;
        }

        public static int LaneCount { get; set; }
        public static int LanesSet { get; set; }

        public static bool IsConnected => LaneCount == LanesSet && MinTimeSet;

        public static bool MinTimeSet { get; set; }
    }
}