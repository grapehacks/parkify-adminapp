namespace AdministrationPanel.ViewModels.CardsTab
{
    public class CardViewModel : AdministrationPanelViewModelBase
    {
        private readonly string _name;
        private readonly string _type;
        private readonly bool _removed;
		private readonly bool _active;
		private readonly string _userName;
        private readonly ActionsViewModel _actionsViewModel;

        public CardViewModel(string name, string type, bool removed, bool active, string userName)
        {
            _name = name;
            _type = type;
			_removed = removed;
			_active = active;
            _userName = userName;
            _actionsViewModel = new ActionsViewModel(name);
        }

        public string Name
        {
            get { return _name; }
        }		

        public string Type
        {
            get { return _type; }
        }
		
		public bool Removed
        {
            get { return _removed; }
        }
		
		public bool Active
        {
            get { return _active; }
        }
		
		public string UserName
        {
            get { return _userName; }
        }

        public ActionsViewModel ActionsViewModel
        {
            get { return _actionsViewModel; }
        }
    }
}