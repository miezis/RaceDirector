using System;
using System.Windows.Input;
using RaceDirector.ViewModels;

namespace RaceDirector.Commands.TrackConnection
{
    public class RemoveLaneCommand : ICommand
    {
        private TrackConnectionViewModel _viewModel;
        public RemoveLaneCommand(TrackConnectionViewModel viewModel)
        {
            _viewModel = viewModel;
        }
        public bool CanExecute(object parameter)
        {
            return _viewModel.TrackConnection.LanePins.Count > 1;
        }

        public void Execute(object parameter)
        {
            _viewModel.RemoveLane();
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}