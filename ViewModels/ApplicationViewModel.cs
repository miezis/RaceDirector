using System.Windows.Input;
using RaceDirector.Commands;
using RaceDirector.Models;
using RaceDirector.Views;

namespace RaceDirector.ViewModels
{
    public class ApplicationViewModel
    {
        private Application _application;

        public Application Application => _application;

        public ICommand NavigateToFreePracticeCommand { get; private set; }
        public ICommand NavigateToTrackConnectionCommand { get; private set; }

        public ApplicationViewModel()
        {
            _application = new Application();

            NavigateToFreePracticeCommand = new NavigateToCommand<FreePracticeView>(this);
            NavigateToTrackConnectionCommand = new NavigateToCommand<TrackConnectionView>(this);
        }

        public void NavigateTo<T>()
        {
            _application.CurrentPageView = Container.Resolve<T>();
        }
    }
}