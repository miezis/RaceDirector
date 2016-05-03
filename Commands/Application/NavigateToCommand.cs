using System;
using System.Windows.Input;
using RaceDirector.ViewModels;

namespace RaceDirector.Commands.Application
{
    public class NavigateToCommand<T> : ICommand
    {
        private ApplicationViewModel _viewModel;

        public NavigateToCommand(ApplicationViewModel viewModel)
        {
            _viewModel = viewModel;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _viewModel.NavigateTo<T>();
        }

        public event EventHandler CanExecuteChanged;
    }
}