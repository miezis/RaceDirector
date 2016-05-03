using System;
using System.Windows.Input;
using RaceDirector.ViewModels;

namespace RaceDirector.Commands.TrackConnection
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
            return _viewModel.TrackConnection.LanePins.Count < 8;
        }

        public void Execute(object parameter)
        {
            _viewModel.AddLane();
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}