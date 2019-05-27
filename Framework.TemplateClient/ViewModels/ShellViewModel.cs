using Caliburn.Micro;
using Framework.TemplateClient.Models.Events;

namespace Framework.TemplateClient.ViewModels
{
    public class ShellViewModel : Conductor<IScreen>.Collection.OneActive, 
                                    IHandle<LoginAttemptEvent>
    {
        private readonly IEventAggregator _eventAggregator;
        private readonly IWindowManager _windowManager;
        private readonly LoginViewModel _loginVM;

        public ShellViewModel(IEventAggregator eventAggregator, IWindowManager windowManager, LoginViewModel loginVM)
        {
            _eventAggregator = eventAggregator;
            _windowManager = windowManager;
            _loginVM = loginVM;

            _eventAggregator.Subscribe(this);
        }

        public void PromptForLogin() => _windowManager.ShowDialog(_loginVM);

        public void Handle(LoginAttemptEvent message)
        {
            if (message.IsLoginSuccessful)
            {
                // Login is successfull, do next steps.
            }
        }

        protected override void OnActivate()
        {
            
            base.OnActivate();
            PromptForLogin();
        }

        protected override void OnInitialize()
        {
            base.OnInitialize();
        }
    }
}