using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace RaceDirector.Models
{
    public class LaneData : BaseModel
    {
        private int _lapCount;
        private int _bestLapTime;
        private ObservableCollection<int> _lapTimes;

        public LaneData()
        {
            _lapCount = 0;
            _bestLapTime = int.MaxValue;
            _lapTimes = new ObservableCollection<int>();

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

        public int BestLapTime
        {
            get { return _bestLapTime; }
            set
            {
                _bestLapTime = value;
                OnPropertyChanged(nameof(BestLapTime));
            }
        }

        public ObservableCollection<int> LapTimes
        {
            get { return _lapTimes; }
        }

        private void OnLapTimesChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged(nameof(LapTimes));
        }
    }
}