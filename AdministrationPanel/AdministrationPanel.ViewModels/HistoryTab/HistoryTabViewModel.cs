using System.Collections.ObjectModel;

namespace AdministrationPanel.ViewModels.HistoryTab
{
    public class HistoryTabViewModel : AdministrationPanelViewModelBase
    {
        public HistoryTabViewModel()
        {
            HistoryCollection = new ObservableCollection<HistoryItemViewModel>();
            HistoryCollection.Add(new HistoryItemViewModel() { DrawDate = "123213" });
            HistoryCollection.Add(new HistoryItemViewModel() { DrawDate = "98797" });
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
