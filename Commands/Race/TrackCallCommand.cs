using System;
using System.Windows.Input;
using RaceDirector.ViewModels;

namespace RaceDirector.Commands.Race
{
    public class TrackCallCommand : ICommand
    {
        private RaceViewModel _viewModel;

        public TrackCallCommand(RaceViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _viewModel.TrackCall();
        }

        public event EventHandler CanExecuteChanged;
    }
}