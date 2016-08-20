
namespace AdministrationPanel.ViewModels.HistoryTab
{
    public class HistoryItemCardsViewModel : AdministrationPanelViewModelBase
    {
        private string _card;

        public string Card
        {
            get { return _card; }
            set
            {
                if (value == _card) return;
                _card = value;
                OnPropertyChanged(() => Card);
            }
        }

        public string Username
        {
            get { return _username; }
            set
            {
                if (value == _username) return;
                _username = value;
                OnPropertyChanged(() => Username);
            }
        }

        private string _username;

    }
}
