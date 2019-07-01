using Caliburn.Micro;
using System.Threading.Tasks;
using UI.WpfClient.Interfaces;
using UI.WpfClient.Models.Events;

namespace UI.WpfClient.Modules.Login
{
    public class LoginViewModel : Screen, ILogin
    {
        public bool IsBusy { get; set; }
        private IEventAggregator _eventAggregator;
        public LoginViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
        }

        public async Task Login()
        {
            bool check = true;
            IsBusy = true;
            await Task.Delay(3500);
            if (true) //if login is OK, check == true
            {
                _eventAggregator.PublishOnUIThread(new LoginAttemptEvent()
                {
                    UserName = "michal",
                    IsLoginSuccessful = check
                });
                TryClose();
            }
            IsBusy = false;
        }

        ~LoginViewModel()
        {

        }
    }
}