using Caliburn.Micro;
using Framework.TemplateClient.Models.Events;

namespace Framework.TemplateClient
{
    public class ShellViewModel : Conductor<IScreen>.Collection.OneActive, 
                                    IHandle<LoginAttemptEvent>
    {
        private IEventAggregator _eventAggregator;
        public ShellViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _eventAggregator.Subscribe(this);
        }

        public void Handle(LoginAttemptEvent message)
        {
            if (message.IsLoginSuccessful)
            {
                // Login is successfull, do next steps.
            }
        }

        protected override void OnInitialize()
        {
            base.OnInitialize();
        }
    }
}