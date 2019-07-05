using Caliburn.Micro;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using UI.WpfClient.Interfaces;
using UI.WpfClient.Models.Events;
using UI.WpfClient.UserControls;

namespace UI.WpfClient.Modules.Home
{
    public class HomeViewModel : Screen, IDashBoard
    {
        private readonly IEventAggregator _eventAggregator;
        private readonly ISnackbarMessageQueue _snackbarMessageQueue;

        public HomeViewModel(IEventAggregator eventAggregator, ISnackbarMessageQueue snackbarMessageQueue)
        {
            _eventAggregator = eventAggregator;
            _snackbarMessageQueue = snackbarMessageQueue;
            DisplayName = "Dashboard page";
        }    
        
        public void SearchClick()
        {
            _snackbarMessageQueue.Enqueue("Hey, you have just clicked search tile!",false);
        }
        protected override void OnActivate()
        {
            _eventAggregator.PublishOnUIThread(new VisibilityChangedEvent<IAppBar> { IsVisible = true });
        }
    }
}
