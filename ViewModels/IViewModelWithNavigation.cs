namespace RaceDirector.ViewModels
{
    public interface IViewModelWithNavigation
    {
        void NavigateTo<T>();
    }
}