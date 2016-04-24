using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace RaceDirector.Models
{
    public class FreePractice : BaseModel
    {
        private ObservableCollection<LaneData> _lanesData;

        public FreePractice()
        {
            _lanesData = new ObservableCollection<LaneData> { new LaneData(), new LaneData() };

            _lanesData.CollectionChanged += LanesDataChanged;
        }

        public ObservableCollection<LaneData> LanesData
        {
            get { return _lanesData; }
        }

        private void LanesDataChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged(nameof(LanesData));
        }
    }
}