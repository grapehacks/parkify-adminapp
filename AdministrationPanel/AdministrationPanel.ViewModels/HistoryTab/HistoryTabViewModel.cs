using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Model;
using Model.DataTypes;

namespace AdministrationPanel.ViewModels.HistoryTab
{
    public class HistoryTabViewModel : AdministrationPanelViewModelBase
    {
        private readonly IDataProvider _dataProvider;
        public HistoryTabViewModel(/*IDataProvider dataProvider*/)
        {
            //_dataProvider = dataProvider;
            //Init();

            var drawList = new List<Draw>
            {
                new Draw
                {
                    card = new Card {name = "1-A"},
                    Date = "666",
                    winner = new User {name = "Jan Kowalksi"}
                },
                new Draw
                {
                    card = new Card {name = "1-A"},
                    Date = "777",
                    winner = new User {name = "Jan Kowalksi"}
                },
                new Draw
                {
                    card = new Card {name = "1-A"},
                    Date = "666",
                    winner = new User {name = "Jan Kowalksi"}
                },
                new Draw
                {
                    card = new Card {name = "1-A"},
                    Date = "777",
                    winner = new User {name = "Jan Kowalksi"}
                },
            };

            var groups = drawList
                .GroupBy(d => d.Date)
                .Select(g => new HistoryGroupViewModel(g));

            HistoryCollection = new ObservableCollection<HistoryGroupViewModel>(groups);
        }

        private async void Init()
        {
            //var draws = await _dataProvider.GetDraws();
            //var drawsList = draws.ToList();
            //_historyCollection = new ObservableCollection<HistoryGroupViewModel>();
            //foreach (var draw in drawsList)
            //{
            //    _historyCollection.Add(new HistoryGroupViewModel(draw));
            //}
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
