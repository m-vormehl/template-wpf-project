using Caliburn.Micro;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using UI.WpfClient.Interfaces;
using UI.WpfClient.Models.Events;
using UI.WpfClient.Modules.Search;
using UI.WpfClient.UserControls;

namespace UI.WpfClient.Modules.Home
{
    public class HomeViewModel : Screen, IHome
    {
        public DateTime LastUpdateDateTime { get; set; }
        public byte UsersOnline { get; set; }
        public TimeSpan LastUpdateAgo { get => LastUpdateDateTime - DateTime.UtcNow; }
        private readonly IEventAggregator _eventAggregator;
        private readonly ISnackbarMessageQueue _snackbarMessageQueue;

        public HomeViewModel(IEventAggregator eventAggregator, ISnackbarMessageQueue snackbarMessageQueue)
        {
            _eventAggregator = eventAggregator;
            _snackbarMessageQueue = snackbarMessageQueue;
            DisplayName = "Dashboard page";
            LastUpdateDateTime = DateTime.UtcNow;
            CheckLastDownloadTime();
            CheckUsersOnline();
        }

        #region COMMANDS
        public void OpenNewCasesCommand()
        {
            _eventAggregator.PublishOnUIThread(new ChangeScreenEvent { ViewModel = IoC.Get<ISearch>(),ClosePrevious=false});
        }

        public void SearchClickCommand()
        {
            _snackbarMessageQueue.Enqueue("Hey, you have just clicked search tile!", false);
        }
        #endregion

        private void CheckLastDownloadTime()
        {
            Task.Run(()=>
                {
                    while (this !=null) // lol
                    {
                        Thread.Sleep(1000);
                        NotifyOfPropertyChange(() => LastUpdateAgo);
                    }
            });
        }

        private void CheckUsersOnline()
        {
            Task.Run(() =>
            {
                while (this != null) // lol
                {
                    Random random = new Random();
                    UsersOnline = (byte)random.Next(0, 12);
                    Thread.Sleep(5000);
                }
            });
        }

        protected override void OnActivate()
        {
            _eventAggregator.PublishOnUIThread(new VisibilityChangedEvent<IAppBar> { IsVisible = true });
        }
    }
}
