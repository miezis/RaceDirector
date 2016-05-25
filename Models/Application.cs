using System.Diagnostics;
using RaceDirector.Views;

namespace RaceDirector.Models
{
    public class Application : BaseModel
    {
        private object _currentPageView;
        private int _lanesSet;
        private bool _minTimeSet;
        private bool _relaySet;

        public Application()
        {
            _lanesSet = 0;
            _minTimeSet = false;
            _currentPageView = new TrackConnectionView();
        }

        public object CurrentPageView
        {
            get
            {
                return _currentPageView;
            }
            set
            {
                _currentPageView = value;
                OnPropertyChanged(nameof(CurrentPageView));
            }
        }

        public int LanesSet
        {
            get { return _lanesSet; }
            set
            {
                _lanesSet = value;
                OnPropertyChanged(nameof(IsConnected));
            }
        }

        public bool MinTimeSet
        {
            get {return _minTimeSet; }
            set
            {
                _minTimeSet = value;
                OnPropertyChanged(nameof(IsConnected));
            }
        }

        public bool RelaySet
        {
            get { return _relaySet; }
            set
            {
                _relaySet = value;
                OnPropertyChanged(nameof(IsConnected));
            }
        }

        public int LaneCount { get; set; }

        public bool IsConnected => LaneCount == _lanesSet && _minTimeSet && _relaySet;
    }
}