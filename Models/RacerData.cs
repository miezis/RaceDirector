namespace RaceDirector.Models
{
    public class RacerData : LaneData
    {
        private string _name;
        private string _club;
        private int _currentLane;
        private int _position;

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

        public int CurrentLane
        {
            get { return _currentLane; }
            set
            {
                _currentLane = value;
                OnPropertyChanged(nameof(CurrentLane));
            }
        }

        public int Position
        {
            get { return _position; }
            set
            {
                _position = value;
                OnPropertyChanged(nameof(Position));
            }
        }

    }
}