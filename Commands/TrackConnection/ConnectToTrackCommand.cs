using System;
using System.Windows.Input;
using RaceDirector.ViewModels;

namespace RaceDirector.Commands.TrackConnection
{
    public class ConnectToTrackCommand : ICommand
    {
        public TrackConnectionViewModel _viewModel;

        public ConnectToTrackCommand(TrackConnectionViewModel viewModel)
        {
            _viewModel = viewModel;
        }
        public bool CanExecute(object parameter)
        {
            return _viewModel.CanConnect;
        }

        public void Execute(object parameter)
        {
            _viewModel.ConnectToTrack();
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}