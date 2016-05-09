using System;
using System.Windows.Input;
using RaceDirector.ViewModels;

namespace RaceDirector.Commands.Race
{
    public class StartResumeRaceCommand : ICommand
    {
        private RaceViewModel _viewModel;

        public StartResumeRaceCommand(RaceViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _viewModel.StartResumeRace();
        }

        public event EventHandler CanExecuteChanged;
    }
}