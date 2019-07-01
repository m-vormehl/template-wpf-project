using Caliburn.Micro;
using UI.WpfClient.Interfaces;
using UI.WpfClient.Models;
using UI.WpfClient.Models.Events;
using UI.WpfClient.Modules.Home;

namespace UI.WpfClient.Modules.Shell
{
    public class ShellViewModel : Conductor<IScreen>.Collection.OneActive, 
                                    IHandle<LoginAttemptEvent>,
                                    IHandle<VisibilityChangedEvent<IProgressBar>>,
                                    IHandle<VisibilityChangedEvent<IAppBar>>,
                                    IShell
    {
        private readonly IEventAggregator _eventAggregator;

        public bool IsAppBusy { get; set; }
        public bool IsAppBarVisible { get; set; }
        public string ProgressMessage { get; set; }

        public ShellViewModel(IEventAggregator eventAggregator,ILogin loginVM)
        {
            _eventAggregator = eventAggregator;
            _eventAggregator.Subscribe(this);

            ActiveItem = loginVM;
        }
        #region Event Handlers

        public void Handle(LoginAttemptEvent message)
        {
            if (message.IsLoginSuccessful)
            {
                // Login is successfull, do next steps.
                var homeViewModel = new HomeViewModel();
                IoC.BuildUp(homeViewModel);
                ActiveItem = homeViewModel;
            }
        }

        public void Handle(VisibilityChangedEvent<IProgressBar> message) => IsAppBusy = message.IsVisible;

        public void Handle(VisibilityChangedEvent<IAppBar> message) => IsAppBarVisible = message.IsVisible;
        #endregion
    }
}