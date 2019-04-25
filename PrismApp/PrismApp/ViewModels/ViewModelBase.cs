using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using PrismApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PrismApp.ViewModels
{
    public class ViewModelBase : BindableBase, INavigationAware, IDestructible
    {
        #region Properties
        protected INavigationService NavigationService { get; private set; }
        protected IEventAggregator ea;
        protected IPageDialogService dialogService;

        protected IToastNotifier notifier;
        protected IRestClient restClient;

        public List<Task> TaskList = new List<Task>();
        public DelegateCommand<string> NavigateCommand { get; set; }


        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private bool showError = false;
        public bool ShowError
        {
            get { return showError; }
            set { SetProperty(ref showError, value); }
        }

        private bool updating;
        public bool Updating
        {
            get { return updating; }
            set { SetProperty(ref updating, value); }
        }

        private bool isLoading;
        public bool IsLoading
        {
            get { return isLoading; }
            set { SetProperty(ref isLoading, value); }
        }

        private bool isBusy;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }
        private bool isEnabled = true;
        public bool IsEnabled
        {
            get { return isEnabled; }
            set { SetProperty(ref isEnabled, value); }
        }
        private bool isVisible = true;
        public bool IsVisible
        {
            get { return isVisible; }
            set { SetProperty(ref isVisible, value); }
        }
        private bool isModal = false;
        public bool IsModal
        {
            get { return isModal; }
            set { SetProperty(ref isModal, value); }
        }

        string busyMessage = "";
        public string BusyMessage
        {
            get { return busyMessage; }
            set { SetProperty(ref busyMessage, value); }
        }

        string message;
        public string Message
        {
            get { return message; }
            set { SetProperty(ref message, value); }
        }


        bool isConnected = true;
        public bool IsConnected
        {
            get { return isConnected; }
            set { SetProperty(ref isConnected, value); }
        }
        public bool IsNotConnected
        {
            get { return !IsConnected; }
        }

        #endregion

        #region Constructor
        public ViewModelBase()
        {
            NavigateCommand = new DelegateCommand<string>(async (string page) => await NavigateTo(page));
        }
        public ViewModelBase(INavigationService navigationService, IEventAggregator eventAggregator, IPageDialogService pageDialogService)
        {
            NavigationService = navigationService;
            ea = eventAggregator;
            dialogService = pageDialogService;
            NavigateCommand = new DelegateCommand<string>(async (string page) => await NavigateTo(page));

        }
        public ViewModelBase(INavigationService navigationService, IEventAggregator eventAggregator, IToastNotifier toastNotifier, IRestClient client, IPageDialogService pageDialogService)
        {
            NavigationService = navigationService;
            ea = eventAggregator;
            notifier = toastNotifier;
            restClient = client;
            dialogService = pageDialogService;
            NavigateCommand = new DelegateCommand<string>(async (string page) => await NavigateTo(page));
        }
        #endregion

        #region Navigation Methods

        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {

        }

        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {

        }

        public virtual void OnNavigatingTo(INavigationParameters parameters)
        {

        }

        public virtual void Destroy()
        {

        }

        public virtual async Task NavigateTo(string pageName, NavigationParameters param = null)
        {
            await NavigationService.NavigateAsync(pageName, param, false);
        }

        #endregion

        protected virtual void ApplyLocaleStrings()
        {

        }
    }
}
