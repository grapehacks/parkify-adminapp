namespace AdministrationPanel.ViewModels.HistoryTab
{
    public class HistoryItemViewModel : AdministrationPanelViewModelBase
    {
        private readonly string _card;
        private readonly string _username;

        public HistoryItemViewModel(string card, string username)
        {
            _card = card;
            _username = username;
        }

        public string Card
        {
            get { return _card; }
        }

        public string Username
        {
            get { return _username; }
        }
    }
}