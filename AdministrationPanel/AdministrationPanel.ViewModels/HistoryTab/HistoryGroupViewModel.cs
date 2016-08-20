using System.Collections.Generic;
using System.Linq;
using Model.DataTypes;

namespace AdministrationPanel.ViewModels.HistoryTab
{
    public class HistoryGroupViewModel : AdministrationPanelViewModelBase
    {
        private readonly List<HistoryItemViewModel> _items;
        private readonly string _drawDate;

        public HistoryGroupViewModel(IEnumerable<Draw> draws)
        {
            _drawDate = draws.First().Date;
            _items = draws.Select(d => new HistoryItemViewModel(d.card.name, d.winner.name)).ToList();
        }

        public List<HistoryItemViewModel> Items
        {
            get { return _items; }
        }

        public string DrawDate
        {
            get { return _drawDate; }
        }
    }
}