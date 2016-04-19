namespace RaceDirector.Services
{
    public class UpdateTimesEventArgs
    {
        public UpdateTimesEventArgs(int lane, int time)
        {
            Lane = lane;
            Time = time;
        }

        public int Lane { get; set; }
        public int Time { get; set; }
    }
}