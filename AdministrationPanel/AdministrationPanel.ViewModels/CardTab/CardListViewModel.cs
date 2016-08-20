using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Model;
using Model.DataTypes;

namespace AdministrationPanel.ViewModels.CardsTab
{
    public class CardListViewModel : AdministrationPanelViewModelBase
    {
		private readonly IDataProvider _dataProvider;
		private readonly CardViewModel.Factory _cardViewModelFactory;
        private ObservableCollection<CardViewModel> _cardList;

		public CardListViewModel(IDataProvider dataProvider, CardViewModel.Factory factory)
        {
			_dataProvider = dataProvider;
			_cardViewModelFactory = factory;
			_cardList = new ObservableCollection<CardViewModel>();
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

		public async void Load()
		{
			var cards = await _dataProvider.GetCards();
			var users = await _dataProvider.GetUsers();
			var cardList = cards == null ? new List<Card>() : cards.ToList();

			var cardViewModels = cardList
				.Select(card => _cardViewModelFactory(
					card.name,
					card.type,
					card.removed,
					card.active,
					GetUserForCard(users, card.user)));

			CardList = new ObservableCollection<CardViewModel>(cardViewModels);
		}

		private static string GetUserForCard(IEnumerable<User> users, string userId)
		{
			var user = users.FirstOrDefault(c => c._id == userId);
			return user == null
				? string.Empty
				: user.name;
		}
    }
}