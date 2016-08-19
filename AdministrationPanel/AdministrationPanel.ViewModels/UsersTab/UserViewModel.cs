﻿namespace AdministrationPanel.ViewModels.UsersTab
{
    public class UserViewModel : AdministrationPanelViewModelBase
    {
        private readonly string _id;
        private readonly string _card;
        private readonly string _name;
        private readonly ActionsViewModel _actionsViewModel;

        public UserViewModel(string id, string card, string name)
        {
            _id = id;
            _card = card;
            _name = name;
            _actionsViewModel = new ActionsViewModel(id);
        }

        public string Card
        {
            get { return _card; }
        }

        public string Name
        {
            get { return _name; }
        }

        public ActionsViewModel ActionsViewModel
        {
            get { return _actionsViewModel; }
        }
    }
}