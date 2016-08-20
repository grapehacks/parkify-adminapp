using System.Windows;
using GalaSoft.MvvmLight.CommandWpf;
using Model;

namespace AdministrationPanel.ViewModels.UsersTab
{
    public class ActionsViewModel
    {
        private readonly string _id;
        private readonly RelayCommand _editCommand;
        private readonly RelayCommand _removeCommand;
        private readonly IDataProvider _dataProvider;

        public ActionsViewModel(string id, IDataProvider dataProvider)
        {
            _id = id;
            _dataProvider = dataProvider;
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

        private async void RemoveUser()
        {
            var result = await _dataProvider.RemoveUser(_id);
        }
    }
}