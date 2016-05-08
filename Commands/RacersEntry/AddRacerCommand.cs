using System;
using System.Windows.Input;
using RaceDirector.ViewModels;

namespace RaceDirector.Commands.RacersEntry
{
    public class AddRacerCommand : ICommand
    {
        private RacersEntryViewModel _viewModel;
        public AddRacerCommand(RacersEntryViewModel viewModel)
        {
            _viewModel = viewModel;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _viewModel.AddRacer();
        }

        public event EventHandler CanExecuteChanged;
    }
}