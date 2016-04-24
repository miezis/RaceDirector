﻿using RaceDirector.Models;
using RaceDirector.ServiceContracts;
using RaceDirector.Services;

namespace RaceDirector.ViewModels
{
    public class FreePracticeViewModel
    {
        private FreePractice _freePractice;
        private IArduinoService _arduinoService;

        public FreePractice FreePractice => _freePractice;

        public FreePracticeViewModel()
        {
            _freePractice = new FreePractice();
            _arduinoService = Container.Resolve<IArduinoService>();

            _arduinoService.UpdateTimes += OnUpdateTimes;
        }

        private void OnUpdateTimes(object sender, UpdateTimesEventArgs args)
        {
            var index = args.Lane - 1;
            var time = args.Time;

            _freePractice.LanesData[index].LapTimes.Add(time);

            if (_freePractice.LanesData[index].BestLapTime > time)
            {
                _freePractice.LanesData[index].BestLapTime = time;
            }

            _freePractice.LanesData[index].LapCount++;
        }
    }
}