using System;
using Model.DataTypes;

namespace AdministrationPanel.ViewModels.UsersTab
{
    public class UserViewModel : AdministrationPanelViewModelBase
    {
        private readonly User _user;
        private readonly string _card;
        private readonly string _name;
        private readonly ActionsViewModel _actionsViewModel;

        public delegate UserViewModel Factory(User user, string card, string name);

        public UserViewModel(User user, string card, string name, Func<User, ActionsViewModel> actionsFactory)
        {
            _user = user;
            _card = card;
            _name = name;
            _actionsViewModel = actionsFactory(user);
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