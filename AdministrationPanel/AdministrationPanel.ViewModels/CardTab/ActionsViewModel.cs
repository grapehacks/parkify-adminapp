using System.Windows;
using GalaSoft.MvvmLight.CommandWpf;
using Model;

namespace AdministrationPanel.ViewModels.CardsTab
{
    public class ActionsViewModel
    {
        private readonly string _name;
        private readonly RelayCommand _editCommand;
        private readonly RelayCommand _removeCommand;
		private readonly IDataProvider _dataProvider;

		public ActionsViewModel(string name, IDataProvider dataProvider)
        {
            _name = name;
			_dataProvider = dataProvider;
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
			var result = _dataProvider.RemoveCard(_name);
        }
    }
}