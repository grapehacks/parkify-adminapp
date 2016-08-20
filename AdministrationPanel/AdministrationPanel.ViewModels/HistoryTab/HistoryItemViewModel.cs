using System.Collections.ObjectModel;
using Model.DataTypes;

namespace AdministrationPanel.ViewModels.HistoryTab
{
    public class HistoryItemViewModel : AdministrationPanelViewModelBase
    {
        public HistoryItemViewModel(Draw draw)
        {
            _drawDate = draw.Date;
            _cardsCollection = new ObservableCollection<HistoryItemCardsViewModel>
            {
                new HistoryItemCardsViewModel {Card = "asd", Username = "zzx"},
                new HistoryItemCardsViewModel {Card = "qwe", Username = "qwe"},
            };
        }

        private ObservableCollection<HistoryItemCardsViewModel> _cardsCollection;

        public ObservableCollection<HistoryItemCardsViewModel> CardsCollection
        {
            get { return _cardsCollection; }
            set
            {
                if (Equals(value, _cardsCollection)) return;
                _cardsCollection = value;
                OnPropertyChanged(() => CardsCollection);
            }
        }

        private string _drawDate;

        public string DrawDate
        {
            get { return _drawDate; }
            set
            {
                if (value == _drawDate) return;
                _drawDate = value;
                OnPropertyChanged(() => DrawDate);
            }
        }
    }
}
