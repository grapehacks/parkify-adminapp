namespace AdministrationPanel.ViewModels.CardsTab
{
    public class CardViewModel : AdministrationPanelViewModelBase
    {
        private readonly string _name;
        private readonly string _type;
        private readonly bool _removed;
		private readonly bool _active;
		private readonly User _user;
        private readonly ActionsViewModel _actionsViewModel;

        public UserViewModel(string name, string type, bool removed, bool active, User user)
        {
            _name = name;
            _type = type;
			_removed = removed;
			_active = active;
            _user = user;
            _actionsViewModel = new ActionsViewModel(id);
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
		
		public string Active
        {
            get { return _active; }
        }
		
		public User User
        {
            get { return _user; }
        }

        public ActionsViewModel ActionsViewModel
        {
            get { return _actionsViewModel; }
        }
    }
}