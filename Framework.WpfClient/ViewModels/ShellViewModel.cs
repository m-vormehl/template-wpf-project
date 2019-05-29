using Caliburn.Micro;
using Framework.WpfClient.Models.Events;

namespace Framework.WpfClient.ViewModels
{
    public class ShellViewModel : Conductor<IScreen>.Collection.OneActive, 
                                    IHandle<LoginAttemptEvent>,
                                    IShell
    {
        private readonly IEventAggregator _eventAggregator;
        //private readonly ILogin _loginVM;

        public ShellViewModel(IEventAggregator eventAggregator, ILogin loginVM)
        {
            _eventAggregator = eventAggregator;
            //_loginVM = loginVM;

            _eventAggregator.Subscribe(this);

            ActiveItem = loginVM;
        }

        public void Handle(LoginAttemptEvent message)
        {
            if (message.IsLoginSuccessful)
            {
                // Login is successfull, do next steps.
            }
        }
    }
}