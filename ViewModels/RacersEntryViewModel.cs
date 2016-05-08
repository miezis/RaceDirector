using System.Diagnostics;
using System.Windows.Input;
using RaceDirector.Commands.Application;
using RaceDirector.Commands.RacersEntry;
using RaceDirector.Models;
using RaceDirector.Views;

namespace RaceDirector.ViewModels
{
    public class RacersEntryViewModel : IViewModelWithNavigation
    {
        private Race _race;
        private Application _application;
        public Race Race => _race;

        public ICommand StartRaceCommand { get; private set; }
        public ICommand AddRacerCommand { get; private set; }
        public ICommand RemoveRacerCommand { get; private set; }

        public RacersEntryViewModel()
        {
            _race = Container.Resolve<Race>();
            _application = Container.Resolve<Application>();

            //TODO: Change to actual nex step view
            StartRaceCommand = new NavigateToCommand<RacersEntryViewModel, TrackConnectionView>(this); 
            AddRacerCommand = new AddRacerCommand(this);
            RemoveRacerCommand = new RemoveRacerCommand(this);
        }

        public void AddRacer()
        {
            _race.Racers.Add(new RacerData());
        }

        public void RemoveRacer()
        {
            var index = _race.Racers.Count - 1;
            _race.Racers.RemoveAt(index);
        }

        public void NavigateTo<T>()
        {
            _application.CurrentPageView = Container.Resolve<T>();
        }
    }
}