using System.Windows;
using GalaSoft.MvvmLight.CommandWpf;

namespace AdministrationPanel.ViewModels.UsersTab
{
    public class ActionsViewModel
    {
        private readonly string _id;
        private readonly RelayCommand _editCommand;
        private readonly RelayCommand _removeCommand;

        public ActionsViewModel(string id)
        {
            _id = id;
            _editCommand = new RelayCommand(EditUser);
            _removeCommand = new RelayCommand(RemoveUser);
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
            MessageBox.Show(string.Format("Call EditUser({0})", _id));
        }

        private void RemoveUser()
        {
            MessageBox.Show(string.Format("Call RemoveUser({0})", _id));
        }
    }
}