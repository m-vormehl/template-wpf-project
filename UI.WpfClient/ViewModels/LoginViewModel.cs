using Caliburn.Micro;
using Framework.WpfClient.Models.Events;
using System.ComponentModel.Composition;

namespace Framework.WpfClient.ViewModels
{
    public class LoginViewModel : Screen, ILogin
    {
        private IEventAggregator _eventAggregator;
        public LoginViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
        }

        public void Login()
        {
            bool check = true;
            if (check) //if login is OK, check == true
            {
                _eventAggregator.PublishOnUIThread(new LoginAttemptEvent()
                {
                    UserName = "michal",
                    IsLoginSuccessful = check
                });
                //TryClose();
            }
        }
    }
}