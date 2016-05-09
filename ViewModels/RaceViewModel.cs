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
using RaceDirector.Models;

namespace RaceDirector.ViewModels
{
    public class RaceViewModel : INotifyPropertyChanged
    {
        private static readonly string[] groupLabels = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L" };
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

        public List<int> changeSequence { get; private set; }
        public Race Race => _race;
        public string CurrentGroup { get; private set; }
        public int CurrentHeat { get; private set; }
        public TimeSpan TimeLeft { get; private set; }
        public ICommand StartWarmUpCommand { get; private set; }
        public ICommand StartResumeRaceCommand { get; private set; }
        public ICommand TrackCallCommand { get; private set; }

        public RaceViewModel()
        {
            _application = Container.Resolve<Application>();
            _race = Container.Resolve<Race>();

            StartWarmUpCommand = new StartWarmUpCommand(this);
            StartResumeRaceCommand = new StartResumeRaceCommand(this);
            TrackCallCommand = new TrackCallCommand(this);

            CurrentGroup = "A";
            CurrentHeat = 1;
            TimeLeft = _race.WarmUpTime;

            _raceTimer = new DispatcherTimer();
            _raceTimer.Tick += RaceTimerTick;
            _raceTimer.Interval = TimeSpan.FromSeconds(1);

            var racerGroups = _race.Racers
                .Select((x, i) => new {Index = i, Value = x})
                .GroupBy(x => x.Index/_application.LanesSet)
                .Select((x, i) => new {Index = i, Value = x.Select(v => v.Value).ToList()})
                .ToDictionary(x => groupLabels[x.Index], x => x.Value);

            changeSequence = laneSequences[_application.LanesSet];
        }

        public void StartWarmUp()
        {
            _raceTimer.Start();
        }

        public void StartResumeRace()
        {
            _raceTimer.Start();
        }

        public void TrackCall()
        {
            _raceTimer.Stop();
        }

        private void RaceTimerTick(object sender, EventArgs e)
        {
            TimeLeft = TimeLeft.Subtract(TimeSpan.FromSeconds(1));
            OnPropertyChanged(nameof(TimeLeft));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}