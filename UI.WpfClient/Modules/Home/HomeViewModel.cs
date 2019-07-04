using Caliburn.Micro;
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
        private IEventAggregator _eventAggregator;

        public HomeViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            DisplayName = "Dashboard page";
        }    
        
        public void DashboardClick()
        {

        }
        protected override void OnActivate()
        {
            _eventAggregator.PublishOnUIThread(new VisibilityChangedEvent<IAppBar> { IsVisible = true });
        }
    }
}
