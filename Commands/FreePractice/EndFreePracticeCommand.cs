using System;
using System.Windows.Input;
using RaceDirector.ViewModels;

namespace RaceDirector.Commands.FreePractice
{
    public class EndFreePracticeCommand : ICommand
    {
        private FreePracticeViewModel _viewModel;
        public EndFreePracticeCommand(FreePracticeViewModel viewModel)
        {
            _viewModel = viewModel;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _viewModel.EndFreePractice();
        }

        public event EventHandler CanExecuteChanged;
    }
}