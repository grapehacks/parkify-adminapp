using System.Windows;
using GalaSoft.MvvmLight.Command;

namespace AdministrationPanel.ViewModels.HistoryTab
{
    public class HistoryItemViewModel : AdministrationPanelViewModelBase
    {
        private string _drawDate;

        public string DrawDate
        {
            get { return _drawDate; }
            set
            {
                if (value == _drawDate) return;
                _drawDate = value;
                OnPropertyChanged(() => DrawDate);
            }
        }

        #region DetailsCommand command
        private RelayCommand _detailsCommand;

        public RelayCommand DetailsCommandCommand
        {
            get
            {
                return _detailsCommand ?? (_detailsCommand = new RelayCommand(DetailsCommand));
            }
        }

        private void DetailsCommand()
        {
            MessageBox.Show("DetailsCommand");
        }
        #endregion
    }
}
