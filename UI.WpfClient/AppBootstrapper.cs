namespace UI.WpfClient {
    using System;
    using System.Collections.Generic;
    using Caliburn.Micro;
    using UI.WpfClient.Interfaces;
    using UI.WpfClient.Modules.Home;
    using UI.WpfClient.Modules.Login;
    using UI.WpfClient.Modules.Shell;

    public class AppBootstrapper : BootstrapperBase {
        SimpleContainer container;

        public AppBootstrapper() {
            Initialize();
        }

        protected override void Configure() {
            container = new SimpleContainer();

            container.Singleton<IWindowManager, WindowManager>();
            container.Singleton<IEventAggregator, EventAggregator>();
            container.Singleton<IShell,ShellViewModel>();
            container.Singleton<ILogin,LoginViewModel>();
            container.Singleton<IDashBoard,HomeViewModel>();
        }
        protected override void OnStartup(object sender, System.Windows.StartupEventArgs e)
        {
            DisplayRootViewFor<IShell>();
        }

        protected override object GetInstance(Type service, string key) {
            return container.GetInstance(service, key);
        }

        protected override IEnumerable<object> GetAllInstances(Type service) {
            return container.GetAllInstances(service);
        }

        protected override void BuildUp(object instance) {
            container.BuildUp(instance);
        }
    }
}