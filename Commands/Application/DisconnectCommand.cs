using System;
using System.Windows.Input;
using RaceDirector.ViewModels;

namespace RaceDirector.Commands.Application
{
    public class DisconnectCommand : ICommand
    {
        private ApplicationViewModel _viewModel;

        public DisconnectCommand(ApplicationViewModel viewModel)
        {
            _viewModel = viewModel;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _viewModel.Disconnect();
        }

        public event EventHandler CanExecuteChanged;
    }
}