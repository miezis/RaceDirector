using System;
using System.Windows.Input;
using RaceDirector.ViewModels;

namespace RaceDirector.Commands.RacersEntry
{
    public class RemoveRacerCommand : ICommand
    {
        private RacersEntryViewModel _viewModel;

        public RemoveRacerCommand(RacersEntryViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _viewModel.RemoveRacer();
        }

        public event EventHandler CanExecuteChanged;
    }
}