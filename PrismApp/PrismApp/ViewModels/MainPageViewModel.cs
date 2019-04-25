using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using PrismApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrismApp.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public MainPageViewModel(INavigationService navigationService, IEventAggregator eventAggregator, IPageDialogService pageDialogService)
            : base(navigationService, eventAggregator, pageDialogService)
        {
            Title = "Main Page";
        }
    }
}
