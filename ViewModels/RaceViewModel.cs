using System;
using System.Collections.Generic;
using System.Windows.Input;
using RaceDirector.Commands.Race;
using RaceDirector.Models;

namespace RaceDirector.ViewModels
{
    public class RaceViewModel
    {
        private static readonly Dictionary<int, List<int>>  laneSequences = new Dictionary<int, List<int>>
        {
            { 8, new List<int> { 1, 3, 5, 7, 8, 6, 4, 2 } },
            { 7, new List<int> { 1, 3, 5, 7, 6, 4, 2 } },
            { 6, new List<int> { 1, 3, 5, 6, 4, 2 } },
            { 5, new List<int> { 1, 3, 5, 4, 2 } },
            { 4, new List<int> { 1, 3, 4, 2 } },
            { 3, new List<int> { 1, 3, 2 } },
            { 2, new List<int> { 1, 2 } },
            { 1, new List<int> { 1 } }
        };

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

            changeSequence = laneSequences[_application.LanesSet];
        }
    }
}