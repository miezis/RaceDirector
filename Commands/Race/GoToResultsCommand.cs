using System;
using System.Windows.Input;
using RaceDirector.ViewModels;

namespace RaceDirector.Commands.Race
{
    public class GoToResultsCommand : ICommand
    {
        private RaceViewModel _viewModel;

        public GoToResultsCommand(RaceViewModel viewModel)
        {
            _viewModel = viewModel;
        }
        public bool CanExecute(object parameter)
        {
            return _viewModel.Race.Finished;
        }

        public void Execute(object parameter)
        {
            _viewModel.GoToResults();
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}