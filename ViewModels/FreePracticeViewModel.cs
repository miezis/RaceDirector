using System;
using System.Windows.Input;
using RaceDirector.Commands.FreePractice;
using RaceDirector.Models;
using RaceDirector.ServiceContracts;
using RaceDirector.Services;

namespace RaceDirector.ViewModels
{
    public class FreePracticeViewModel
    {
        private FreePractice _freePractice;
        private IArduinoService _arduinoService;

        public FreePractice FreePractice => _freePractice;

        public ICommand EndFreePracticeCommand { get; private set; }

        public FreePracticeViewModel()
        {
            _freePractice = new FreePractice();
            _arduinoService = Container.Resolve<IArduinoService>();

            EndFreePracticeCommand = new EndFreePracticeCommand(this);

            _arduinoService.UpdateTimes += OnUpdateTimes;

            _arduinoService.StartSession();
        }

        public void EndFreePractice()
        {
            _arduinoService.StopSession();
        }

        private void OnUpdateTimes(object sender, UpdateTimesEventArgs args)
        {
            var index = args.Lane - 1;
            var time = TimeSpan.FromMilliseconds(args.Time);

            _freePractice.LanesData[index].LapTimes.Insert(0, time);

            if (_freePractice.LanesData[index].BestLapTime > time)
            {
                _freePractice.LanesData[index].BestLapTime = time;
            }

            _freePractice.LanesData[index].LapCount++;
        }
    }
}