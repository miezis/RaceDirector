﻿using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace RaceDirector.Models
{
    public class Race : BaseModel
    {
        private string _raceClass;
        private string _eventName;
        private TimeSpan _heatTime;
        private TimeSpan _laneChangeTime;
        private TimeSpan _warmUpTime;
        private ObservableCollection<RacerData> _racers;

        public Race()
        {
            _racers = new ObservableCollection<RacerData> { new RacerData() };
            _racers.CollectionChanged += RacersDataChanged;
        }

        public string RaceClass
        {
            get { return _raceClass; }
            set
            {
                _raceClass = value;
                OnPropertyChanged(nameof(RaceClass));
            }
        }

        public string EventName
        {
            get { return _eventName; }
            set
            {
                _eventName = value;
                OnPropertyChanged(nameof(EventName));
            }
        }

        public TimeSpan HeatTime
        {
            get { return _heatTime; }
            set
            {
                _heatTime = value;
                OnPropertyChanged(nameof(HeatTime));
            }
        }

        public TimeSpan LaneChangeTime
        {
            get { return _laneChangeTime; }
            set
            {
                _laneChangeTime = value;
                OnPropertyChanged(nameof(LaneChangeTime));
            }
        }

        public TimeSpan WarmUpTime
        {
            get { return _warmUpTime; }
            set
            {
                _warmUpTime = value;
                OnPropertyChanged(nameof(WarmUpTime));
            }
        }

        public ObservableCollection<RacerData> Racers
        {
            get { return _racers; }
        }

        private void RacersDataChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged(nameof(Racers));
        }
    }
}