using Model.DataTypes;

namespace AdministrationPanel.ViewModels.HomeTab
{
    public class HomeTabUserViewModel : AdministrationPanelViewModelBase
    {
        public HomeTabUserViewModel(User user)
        {
            _name = user.name;
            _userParticipate = user.participate;
        }

        private string _name;

        public string Name
        {
            get { return _name; }
            set
            {
                if (value == _name) return;
                _name = value;
                OnPropertyChanged(() => Name);
            }
        }

        public UserParticipate UserParticipate
        {
            get { return _userParticipate; }
            set
            {
                if (value == _userParticipate) return;
                _userParticipate = value;
                OnPropertyChanged(() => UserParticipate);
            }
        }

        private UserParticipate _userParticipate;
    }
}
