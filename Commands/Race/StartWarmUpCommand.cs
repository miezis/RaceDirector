using System;
using System.Windows.Input;
using RaceDirector.ViewModels;

namespace RaceDirector.Commands.Race
{
    public class StartWarmUpCommand : ICommand
    {
        private RaceViewModel _viewModel;

        public StartWarmUpCommand(RaceViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _viewModel.StartWarmUp();
        }

        public event EventHandler CanExecuteChanged;
    }
}