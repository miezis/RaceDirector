using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;

namespace RaceDirector.Models
{
    public class LanePin : BaseModel
    {
        private int _lane;
        private int _pin;

        public LanePin(int lane, int pin)
        {
            _lane = lane;
            _pin = pin;
        }

        public int Lane
        {
            get { return _lane; }
            set
            {
                _lane = value;
                OnPropertyChanged(nameof(Lane));
            }
        }

        public int Pin
        {
            get { return _pin; }
            set
            {
                _pin = value;
                OnPropertyChanged(nameof(Pin));
            }
        }
    }
    public class TrackConnection : BaseModel
    {
        private string _port;
        private int _baudRate;
        private int _minTime;
        private ObservableCollection<LanePin> _lanePins;

        public TrackConnection()
        {
            //Setting defaults
            _port = "COM3";
            _baudRate = 9600;
            _minTime = 3000;
            _lanePins = new ObservableCollection<LanePin> {new LanePin(1, 0)};

            //Add event handler when lane pins are changed
            _lanePins.CollectionChanged += LanePinsChanged;
        }

        public string Port
        {
            get { return _port; }
            set
            {
                _port = value;
                OnPropertyChanged(nameof(Port));
            }
        }

        public int BaudRate
        {
            get { return _baudRate; }
            set
            {
                _baudRate = value;
                OnPropertyChanged(nameof(BaudRate));
            }
        }

        public int MinTime
        {
            get { return _minTime; }
            set
            {
                _minTime = value;
                OnPropertyChanged(nameof(MinTime));
            }
        }

        public ObservableCollection<LanePin> LanePins
        {
            get { return _lanePins; }
        }

        private void LanePinsChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged(nameof(LanePins));
        }
    }
}