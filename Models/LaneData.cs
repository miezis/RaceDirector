using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Globalization;
using System.Linq;

namespace RaceDirector.Models
{
    public class LaneData : BaseModel
    {
        private int _lapCount;
        private TimeSpan _bestLapTime;
        private ObservableCollection<TimeSpan> _lapTimes;

        public LaneData()
        {
            _lapCount = 0;
            _bestLapTime = TimeSpan.FromMilliseconds(60000);
            _lapTimes = new ObservableCollection<TimeSpan>();

            _lapTimes.CollectionChanged += OnLapTimesChanged;
        }

        public int LapCount
        {
            get
            {
                return _lapCount;
            }
            set
            {
                _lapCount = value;
                OnPropertyChanged(nameof(LapCount));
            }
        }

        public TimeSpan BestLapTime
        {
            get { return _bestLapTime; }
            set
            {
                _bestLapTime = value;
                OnPropertyChanged(nameof(BestLapTime));
            }
        }

        public ObservableCollection<TimeSpan> LapTimes
        {
            get { return _lapTimes; }
        }

        public string LapTimesStringRepresentation
        {
            get
            {
                var times = _lapTimes.Select(x => x.TotalSeconds.ToString(CultureInfo.InvariantCulture));
                return String.Join("; ", times);
            }
        }

        private void OnLapTimesChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged(nameof(LapTimes));
            OnPropertyChanged(nameof(LapTimesStringRepresentation));
        }
    }
}