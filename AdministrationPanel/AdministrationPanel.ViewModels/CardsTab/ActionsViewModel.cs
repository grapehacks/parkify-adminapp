using System.Windows;
using GalaSoft.MvvmLight.CommandWpf;

namespace AdministrationPanel.ViewModels.CardsTab
{
    public class ActionsViewModel
    {
        private readonly string _name;
        private readonly RelayCommand _editCommand;
        private readonly RelayCommand _removeCommand;

        public ActionsViewModel(string name)
        {
            _name = name;
            _editCommand = new RelayCommand(EditCard);
            _removeCommand = new RelayCommand(RemoveCard);
        }

        public RelayCommand EditCommand
        {
            get { return _editCommand; }
        }

        public RelayCommand RemoveCommand
        {
            get { return _removeCommand; }
        }

        private void EditCard()
        {
            MessageBox.Show(string.Format("Call EditCard({0})", _name));
        }

        private void RemoveCard()
        {
            MessageBox.Show(string.Format("Call RemoveCard({0})", _name));
        }
    }
}