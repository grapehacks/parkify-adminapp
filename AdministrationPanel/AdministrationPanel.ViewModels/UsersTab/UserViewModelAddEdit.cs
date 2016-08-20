using AdministrationPanel.ViewModels.Messages;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;

namespace AdministrationPanel.ViewModels.UsersTab
{
    public class UserViewModelAddEdit : AdministrationPanelViewModelBase
    {
        private readonly IMessenger _messenger;
        private bool _isAddMode;
        public UserViewModelAddEdit()
        {
            
        }

        public string SaveButtonLabel {get { return _isAddMode ? "Dodaj" : "Edytuj"; }}

            #region Save command
        private RelayCommand _save;

        public RelayCommand SaveCommand
        {
            get
            {
                return _save ?? (_save = new RelayCommand(Save));
            }
        }

        private void Save()
        {
            _messenger.Send(new LoggedOutMessage());

        }
        #endregion

        #region Cancel command
        private RelayCommand _cancel;

        public RelayCommand CancelCommand
        {
            get
            {
                return _cancel ?? (_cancel = new RelayCommand(Cancel));
            }
        }

        private void Cancel()
        {
            _messenger.Send(new LoggedOutMessage());

        }
        #endregion
    }
}
