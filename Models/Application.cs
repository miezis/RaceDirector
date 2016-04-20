using RaceDirector.Views;

namespace RaceDirector.Models
{
    public class Application : BaseModel
    {
        private object _currentPageView;

        public Application()
        {
            _currentPageView = new TrackConnectionView();
        }

        public object CurrentPageView
        {
            get
            {
                return _currentPageView;
            }
            set
            {
                _currentPageView = value;
                OnPropertyChanged(nameof(CurrentPageView));
            }
        }
    }
}