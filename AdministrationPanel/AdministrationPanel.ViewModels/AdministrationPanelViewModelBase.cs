using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
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