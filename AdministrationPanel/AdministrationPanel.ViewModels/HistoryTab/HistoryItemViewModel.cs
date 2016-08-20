using System.Collections.ObjectModel;
using System.Windows;
using GalaSoft.MvvmLight.Command;

namespace AdministrationPanel.ViewModels.HistoryTab
{
    public class HistoryItemViewModel : AdministrationPanelViewModelBase
    {
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
