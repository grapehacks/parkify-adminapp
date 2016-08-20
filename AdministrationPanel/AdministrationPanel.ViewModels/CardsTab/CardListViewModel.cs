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
                new CardViewModel("1-A", "", false, true, new User("Tom1")),
                new CardViewModel("1-B", "", false, true, new User("Tom2")),
                new CardViewModel("1-C", "", false, true, new User("Tom3")),
                new CardViewModel("1-D", "", false, true, new User("Tom4")),
                new CardViewModel("1-E", "", false, true, new User("Tom5")),
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