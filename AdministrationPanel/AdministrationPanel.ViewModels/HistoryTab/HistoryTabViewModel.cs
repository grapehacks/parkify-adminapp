using System.Collections.ObjectModel;
using System.Linq;
using Model;

namespace AdministrationPanel.ViewModels.HistoryTab
{
    public class HistoryTabViewModel : AdministrationPanelViewModelBase
    {
        private readonly IDataProvider _dataProvider;
        public HistoryTabViewModel(IDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
            Init();
        }

        private async void Init()
        {
            var draws = await _dataProvider.GetDraws();
            var drawsList = draws.ToList();
            _historyCollection = new ObservableCollection<HistoryItemViewModel>();
            foreach (var draw in drawsList)
            {
                _historyCollection.Add(new HistoryItemViewModel(draw));
            }
        }


        private ObservableCollection<HistoryItemViewModel> _historyCollection;

        public ObservableCollection<HistoryItemViewModel> HistoryCollection
        {
            get { return _historyCollection; }
            set
            {
                if (Equals(value, _historyCollection)) return;
                _historyCollection = value;
                OnPropertyChanged(() => HistoryCollection);
            }
        }
    }
}
