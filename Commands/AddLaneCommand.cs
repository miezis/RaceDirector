using System;
using System.Windows.Input;
using RaceDirector.ViewModels;

namespace RaceDirector.Commands
{
    public class AddLaneCommand : ICommand
    {
        private TrackConnectionViewModel _viewModel;
        public AddLaneCommand(TrackConnectionViewModel viewModel)
        {
            _viewModel = viewModel;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _viewModel.AddLane();
        }

        public event EventHandler CanExecuteChanged;
    }
}