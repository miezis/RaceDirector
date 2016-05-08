using System;
using System.Windows.Input;
using RaceDirector.ViewModels;

namespace RaceDirector.Commands.Application
{
    public class NavigateToCommand<TViewModel, TViewToNavigate> : ICommand where TViewModel : IViewModelWithNavigation
    {
        private TViewModel _viewModel;

        public NavigateToCommand(TViewModel viewModel)
        {
            _viewModel = viewModel;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _viewModel.NavigateTo<TViewToNavigate>();
        }

        public event EventHandler CanExecuteChanged;
    }
}