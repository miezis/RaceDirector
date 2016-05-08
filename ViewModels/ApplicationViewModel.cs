using System.Windows.Input;
using RaceDirector.Commands;
using RaceDirector.Commands.Application;
using RaceDirector.Models;
using RaceDirector.ServiceContracts;
using RaceDirector.Views;

namespace RaceDirector.ViewModels
{
    public class ApplicationViewModel : IViewModelWithNavigation
    {
        private Application _application;

        public Application Application => _application;

        public ICommand NavigateToFreePracticeCommand { get; private set; }
        public ICommand NavigateToTrackConnectionCommand { get; private set; }
        public ICommand DisconnectCommand { get; private set; }

        public ApplicationViewModel()
        {
            _application = Container.Resolve<Application>();

            NavigateToFreePracticeCommand = new NavigateToCommand<ApplicationViewModel, FreePracticeView>(this);
            NavigateToTrackConnectionCommand = new NavigateToCommand<ApplicationViewModel, TrackConnectionView>(this);
            DisconnectCommand = new DisconnectCommand(this);
        }

        public void Disconnect()
        {
            var arduinoService = Container.Resolve<IArduinoService>();

            arduinoService.Disconnect();

            _application.LanesSet = 0;
            _application.MinTimeSet = false;
        }

        public void NavigateTo<T>()
        {
            _application.CurrentPageView = Container.Resolve<T>();
        }
    }
}