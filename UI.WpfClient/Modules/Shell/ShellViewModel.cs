using Caliburn.Micro;
using MaterialDesignThemes.Wpf;
using UI.WpfClient.Interfaces;
using UI.WpfClient.Models;
using UI.WpfClient.Models.Events;
using UI.WpfClient.Modules.Home;
using UI.WpfClient.Modules.Search;

namespace UI.WpfClient.Modules.Shell
{
    public class ShellViewModel : Conductor<IScreen>.Collection.OneActive, 
                                    IHandle<VisibilityChangedEvent<IProgressBar>>,
                                    IHandle<VisibilityChangedEvent<IAppBar>>,
                                    IHandle<ChangeScreenEvent>,
                                    IShell
    {
        private readonly IEventAggregator _eventAggregator;

        public bool IsAppBusy { get; set; }
        public bool IsAppBarVisible { get; set; }
        public string ProgressMessage { get; set; }
        public ISnackbarMessageQueue SnackbarMessageQueue { get; set; }

        public ShellViewModel(IEventAggregator eventAggregator,
                                ISnackbarMessageQueue snackbarMessageQueue,
                                ILogin loginVM)
        {
            _eventAggregator = eventAggregator;
            SnackbarMessageQueue = snackbarMessageQueue;
            _eventAggregator.Subscribe(this);

            ActiveItem = loginVM;
        }
        #region Event Handlers

        public void Handle(VisibilityChangedEvent<IProgressBar> message) => IsAppBusy = message.IsVisible;

        public void Handle(VisibilityChangedEvent<IAppBar> message) => IsAppBarVisible = message.IsVisible;

        public void Handle(ChangeScreenEvent message)
        {
            if (message.ViewModel != null)
            {
                if (!Items.Contains(message.ViewModel))
                {
                    IoC.BuildUp(message.ViewModel);
                    Items.Add(message.ViewModel);
                }
                ChangeActiveItem(message.ViewModel, message.ClosePrevious);
            }
        }
        #endregion
    }
}