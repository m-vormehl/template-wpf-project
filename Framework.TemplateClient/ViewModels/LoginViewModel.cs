using Caliburn.Micro;
using Framework.TemplateClient.Models.Events;
using System.ComponentModel.Composition;

namespace Framework.TemplateClient.ViewModels
{
    [Export(typeof(LoginViewModel))]
    public class LoginViewModel : Screen
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
                TryClose();
            }
        }
}
}