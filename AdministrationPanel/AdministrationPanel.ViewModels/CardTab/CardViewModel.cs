using System;


namespace AdministrationPanel.ViewModels.CardsTab
{
    public class CardViewModel : AdministrationPanelViewModelBase
    {
        private string _name;
        private string _type;
        private bool _removed;
		private bool _active;
		private string _userName;
        private readonly ActionsViewModel _actionsViewModel;

		public delegate CardViewModel Factory(string name, string type, bool removed, bool active, string userName);

		public CardViewModel(string name, string type, bool removed, bool active, string userName, Func<string, ActionsViewModel> actionsFactory)
        {
            _name = name;
            _type = type;
			_removed = removed;
			_active = active;
            _userName = userName;
			_actionsViewModel = actionsFactory(name);
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
			set { _active = value; }
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