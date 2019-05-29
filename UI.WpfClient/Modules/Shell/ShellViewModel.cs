using Caliburn.Micro;
using UI.WpfClient.Interfaces;
using UI.WpfClient.Models.Events;

namespace UI.WpfClient.Modules.Shell
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