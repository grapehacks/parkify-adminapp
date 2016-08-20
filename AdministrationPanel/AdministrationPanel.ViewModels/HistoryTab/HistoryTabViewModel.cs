using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Model;
using Model.DataTypes;

namespace AdministrationPanel.ViewModels.HistoryTab
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class HistoryTabViewModel : AdministrationPanelViewModelBase
    {
        private readonly IDataProvider _dataProvider;
        public HistoryTabViewModel(IDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        public async void Load()
        {
            var draws = await _dataProvider.GetDraws();
            var drawList = draws == null ? new List<Draw>() : draws.ToList();

            var groups1 = drawList.GroupBy(d => d.Date).ToList();
            var groups2 =groups1.Select(g => new HistoryGroupViewModel(g)).ToList();

            HistoryCollection = new ObservableCollection<HistoryGroupViewModel>(groups2);
        }


        private ObservableCollection<HistoryGroupViewModel> _historyCollection;

        public ObservableCollection<HistoryGroupViewModel> HistoryCollection
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
