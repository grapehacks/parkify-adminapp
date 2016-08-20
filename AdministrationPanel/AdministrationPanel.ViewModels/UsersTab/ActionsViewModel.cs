using AdministrationPanel.ViewModels.Messages;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using Model;
using Model.DataTypes;

namespace AdministrationPanel.ViewModels.UsersTab
{
    public class ActionsViewModel
    {
        private readonly User _user;
        private readonly RelayCommand _editCommand;
        private readonly RelayCommand _removeCommand;
        private readonly IDataProvider _dataProvider;
        private readonly IMessenger _messenger;

        public ActionsViewModel(User user, IDataProvider dataProvider, IMessenger messenger)
        {
            _user = user;
            _dataProvider = dataProvider;
            _editCommand = new RelayCommand(EditUser);
            _removeCommand = new RelayCommand(RemoveUser);
            _messenger = messenger;
        }

        public RelayCommand EditCommand
        {
            get { return _editCommand; }
        }

        public RelayCommand RemoveCommand
        {
            get { return _removeCommand; }
        }

        private void EditUser()
        {
            _messenger.Send(new ShowUserAddEditMessage() {User = _user });
        }

        private async void RemoveUser()
        {
            var result = await _dataProvider.RemoveUser(_user._id);
        }
    }
}