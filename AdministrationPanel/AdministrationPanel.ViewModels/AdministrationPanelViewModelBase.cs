using System;
using System.Linq.Expressions;
using AdministrationPanel.ViewModels.Annotations;
using GalaSoft.MvvmLight;

namespace AdministrationPanel.ViewModels
{
    public class AdministrationPanelViewModelBase : ViewModelBase
    {
        [NotifyPropertyChangedInvocator]
        protected void OnPropertyChanged<T>(Expression<Func<T>> propertyExpression)
        {
            RaisePropertyChanged(propertyExpression);
        }
    }
}