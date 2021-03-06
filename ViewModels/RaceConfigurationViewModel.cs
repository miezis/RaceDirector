﻿using System.Windows.Input;
using RaceDirector.Commands.Application;
using RaceDirector.Models;
using RaceDirector.Views;

namespace RaceDirector.ViewModels
{
    public class RaceConfigurationViewModel : IViewModelWithNavigation
    {
        private Race _race;
        private Application _application;
        public Race Race => _race;

        public ICommand NavigateToNextStepCommand { get; private set; }

        public RaceConfigurationViewModel()
        {
            _race = Container.Resolve<Race>();
            _application = Container.Resolve<Application>();

            NavigateToNextStepCommand = new NavigateToCommand<RaceConfigurationViewModel, RacersEntryView>(this); 
        }

        public void NavigateTo<T>()
        {
            _application.CurrentPageView = Container.Resolve<T>();
        }
    }
}