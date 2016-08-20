using System.Collections.ObjectModel;

namespace AdministrationPanel.ViewModels.CardsTab
{
    public class CardListViewModel : AdministrationPanelViewModelBase
    {
        private ObservableCollection<CardViewModel> _cardList;

        public CardListViewModel()
        {
            _cardList = new ObservableCollection<CardViewModel>()
            {
                new CardViewModel("1-A", "", false, true, "Tom1"),
                new CardViewModel("1-B", "", false, true, "Tom2"),
                new CardViewModel("1-C", "", false, true, "Tom3"),
                new CardViewModel("1-D", "", false, true, "Tom4"),
                new CardViewModel("1-E", "", false, true, "Tom5"),
            };
        }

        public ObservableCollection<CardViewModel> CardList
        {
            get { return _cardList; }
            set
            {
                if (Equals(value, _cardList)) return;
                _cardList = value;
                OnPropertyChanged(() => CardList);
            }
        }
    }
}