using System;
using System.Collections.Generic;
using System.Linq;
using RaceDirector.Models;

namespace RaceDirector.ViewModels
{
    public class RaceResultsViewModel
    {
        private Race _race;
        public Race Race => _race;
        public List<RacerData> Results { get; set; }

        public RaceResultsViewModel()
        {
            _race = Container.Resolve<Race>();
            Results = _race.Racers.OrderByDescending(x => x.LapCount).ToList();
        }
    }
}