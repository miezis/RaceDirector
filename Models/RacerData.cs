namespace RaceDirector.Models
{
    public class RacerData : LaneData
    {
        private string _name;
        private string _club;

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public string Club
        {
            get { return _club; }
            set
            {
                _club = value;
                OnPropertyChanged(nameof(Club));
            }
        }
    }
}