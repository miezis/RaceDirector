using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Windows.Threading;
using RaceDirector.Annotations;
using RaceDirector.Commands.Race;
using RaceDirector.DTO;
using RaceDirector.Models;
using RaceDirector.ServiceContracts;
using RaceDirector.Services;
using Race = RaceDirector.Models.Race;

namespace RaceDirector.ViewModels
{
    public class RaceViewModel : INotifyPropertyChanged
    {
        private static readonly List<string> groupLabels = new List<string> { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L" };
        private static readonly Dictionary<int, List<int>>  laneSequences = new Dictionary<int, List<int>>
        {
            { 8, new List<int> { 1, 3, 5, 7, 8, 6, 4, 2 } },
            { 7, new List<int> { 1, 3, 5, 7, 6, 4, 2 } },
            { 6, new List<int> { 1, 3, 5, 6, 4, 2 } },
            { 5, new List<int> { 1, 3, 5, 4, 2 } },
            { 4, new List<int> { 1, 3, 4, 2 } },
            { 3, new List<int> { 1, 3, 2 } },
            { 2, new List<int> { 1, 2 } },
            { 1, new List<int> { 1 } },
            { 0, new List<int> { 1 } }
        };

        private DispatcherTimer _raceTimer;

        private Application _application;
        private Race _race;

        private Dictionary<string, List<RacerData>> _groupedRacers;

        private IArduinoService _arduinoService;

        public bool WarmUpSession { get; private set; }

        public bool LaneChange { get; private set; }

        public bool HeatSession => !(WarmUpSession || LaneChange) && !_race.Finished;

        public List<int> changeSequence { get; private set; }
        public Race Race => _race;
        public string CurrentGroup { get; private set; }

        public List<RacerData> CurrentRacers => _groupedRacers[CurrentGroup];

        public int CurrentHeat { get; private set; }
        public TimeSpan TimeLeft { get; private set; }
        public ICommand StartResumeRaceCommand { get; private set; }
        public ICommand TrackCallCommand { get; private set; }

        public RaceViewModel()
        {
            _application = Container.Resolve<Application>();
            _race = Container.Resolve<Race>();
            _arduinoService = Container.Resolve<IArduinoService>();
            
            StartResumeRaceCommand = new StartResumeRaceCommand(this);
            TrackCallCommand = new TrackCallCommand(this);

            CurrentGroup = "A";
            CurrentHeat = 1;
            TimeLeft = _race.WarmUpTime;

            _raceTimer = new DispatcherTimer();
            _raceTimer.Tick += RaceTimerTick;
            _raceTimer.Interval = TimeSpan.FromSeconds(1);

            for (var i = 0; i < _race.Racers.Count; i++)
            {
                _race.Racers[i].Position = i + 1;
            }

            _groupedRacers = _race.Racers
                .Select((x, i) => new {Index = i, Value = x})
                .GroupBy(x => x.Index/_application.LanesSet)
                .Select((x, i) => new {Index = i, Value = x.Select(v => v.Value).ToList()})
                .ToDictionary(x => groupLabels[x.Index], x => x.Value);

            changeSequence = laneSequences[_application.LanesSet];

            for (var i = 0; i < CurrentRacers.Count; i++)
            {
                CurrentRacers[i].CurrentLane = changeSequence[i];
            }

            _arduinoService.UpdateTimes += OnUpdateTimes;

            WarmUpSession = true;
            LaneChange = false;
        }

        public bool CanStartResumeRace()
        {
            return !(_raceTimer.IsEnabled || _race.Finished);
        }

        public bool CanMakeTrackCall()
        {
            return _raceTimer.IsEnabled && !_race.Finished;
        }

        public void StartResumeRace()
        {
            _arduinoService.StartSession();
            _raceTimer.Start();
        }

        public void TrackCall()
        {
            _arduinoService.PauseSession();
            _raceTimer.Stop();
        }

        private void OnUpdateTimes(object sender, UpdateTimesEventArgs args)
        {
            if (HeatSession)
            {
                var lane = args.Lane;
                var time = TimeSpan.FromMilliseconds(args.Time);

                var racer = CurrentRacers.Find(i => i.CurrentLane == lane);

                if (racer != null)
                {
                    racer.LapTimes.Insert(0, time);

                    if (racer.BestLapTime > time)
                    {
                        racer.BestLapTime = time;
                    }
                
                    racer.LapCount++;

                    var sortedRacers = _race.Racers.OrderByDescending(i => i.LapCount).ToList();

                    for (var i = 0; i < sortedRacers.Count; i++)
                    {
                        _race.Racers.First(x => x.Name == sortedRacers[i].Name).Position = i + 1;
                    }

                    if (_race.RaceId > 0)
                    {
                        SendDataToWeb();
                    }
                }
            }
        }

        private void SendDataToWeb()
        {
            var racers = _race.Racers
                .Select(x => new Racer
                {
                    name = x.Name,
                    club = x.Club,
                    best_time = (int) x.BestLapTime.TotalMilliseconds,
                    lap_count = x.LapCount
                }).ToList();

            var race = new DTO.Race
            {
                apiKey = _race.ApiKey,
                id = _race.RaceId,
                racers = racers
            };

            RaceHubService.SendData(race);
        }

        private void RaceTimerTick(object sender, EventArgs e)
        {
            TimeLeft = TimeLeft.Subtract(TimeSpan.FromSeconds(1));

            if (TimeLeft == TimeSpan.Zero)
            {
                prepareNextStep();
                CommandManager.InvalidateRequerySuggested();
            }

            OnPropertyChanged(nameof(TimeLeft));
        }

        private void prepareNextStep()
        {
            _arduinoService.PauseSession();
            _raceTimer.Stop();

            TimeLeft = _race.LaneChangeTime;

            if (WarmUpSession || LaneChange)
            {
                prepareHeat();

                OnPropertyChanged(nameof(LaneChange));
                OnPropertyChanged(nameof(WarmUpSession));
                OnPropertyChanged(nameof(HeatSession));

                return;
            }

            if (!WarmUpSession && !LaneChange && CurrentHeat != _application.LanesSet)
            {
                prepareLaneChange();
            } else if (!LaneChange && CurrentHeat == _application.LanesSet)
            {
                prepareNextGroup();
            }

            OnPropertyChanged(nameof(LaneChange));
            OnPropertyChanged(nameof(WarmUpSession));
            OnPropertyChanged(nameof(HeatSession));
        }

        private void prepareHeat()
        {
            TimeLeft = _race.HeatTime;
            LaneChange = false;
            WarmUpSession = false;
        }

        private void prepareLaneChange()
        {
            TimeLeft = _race.LaneChangeTime;

            foreach (var racer in CurrentRacers)
            {
                var oldIndex = changeSequence.FindIndex(i => i == racer.CurrentLane);
                var newIndex = oldIndex + 1;
                newIndex = newIndex >= changeSequence.Count ? 0 : newIndex;
                racer.CurrentLane = changeSequence[newIndex];
            }

            LaneChange = true;
            WarmUpSession = false;

            CurrentHeat++;
            OnPropertyChanged(nameof(CurrentHeat));
        }

        private void prepareNextGroup()
        {
            var oldIndex = groupLabels.FindIndex(i => i == CurrentGroup);
            CurrentGroup = groupLabels[oldIndex + 1];
            if (_groupedRacers.ContainsKey(CurrentGroup))
            {
                for (var i = 0; i < CurrentRacers.Count; i++)
                {
                    CurrentRacers[i].CurrentLane = changeSequence[i];
                }
                CurrentHeat = 1;
                TimeLeft = _race.WarmUpTime;
                WarmUpSession = true;
                LaneChange = false;
                OnPropertyChanged(nameof(WarmUpSession));
                OnPropertyChanged(nameof(CurrentGroup));
                OnPropertyChanged(nameof(CurrentHeat));
                OnPropertyChanged(nameof(CurrentRacers));
            }
            else
            {
                TimeLeft = TimeSpan.Zero;
                _race.Finished = true;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}