using ReactiveUI;
using Routing.Navigation;
using Routing.UI.Login;
using Splat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Concurrency;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Routing.UI
{
    public abstract class CompositionRoot
    {
        private Lazy<IScheduler> BackgroundScheduler;
        private Lazy<IViewLocator> CurrentViewLocator;
        private Lazy<IScheduler> MainScheduler;
        private Lazy<NavigationView> NavigationView;
        public Lazy<App> App { get; set; }
        public Func<NavigationView> ResolveNavigationView => () => NavigationView.Value;
        public Lazy<IViewStackService> ViewStackService { get; set; }

        // private IViewFor<T> CreateStartPage<T>(viewModel) = viewmodel => CurrentViewLocator.Value.ResolveView<T>(viewModel);
        private Func<LoginViewModel> LoginViewModelFactory => () => new LoginViewModel(ViewStackService.Value);

        private Func<NavigationView> NavigationViewFactory => () => new NavigationView(BackgroundScheduler.Value, MainScheduler.Value, CurrentViewLocator.Value);

        public CompositionRoot()
        {
            App = new Lazy<App>(CreateApp);
            MainScheduler = new Lazy<IScheduler>(CreateMainScheduler);
            BackgroundScheduler = new Lazy<IScheduler>(CreateBackgroundScheduler);
            NavigationView = new Lazy<NavigationView>(NavigationViewFactory);
            CurrentViewLocator = new Lazy<IViewLocator>(CreateViewLocator);
            ViewStackService = new Lazy<IViewStackService>(CreateViewServiceStack);
        }

        public App ResolveApp() => App.Value;

        private App CreateApp() => new App(NavigationViewFactory, ViewStackService.Value);

        private IScheduler CreateBackgroundScheduler() => new EventLoopScheduler();

        private IScheduler CreateMainScheduler() => new SynchronizationContextScheduler(SynchronizationContext.Current);

        private IViewLocator CreateViewLocator() => Locator.Current.GetService<IViewLocator>();

        private IViewStackService CreateViewServiceStack() => new ViewStackService(NavigationView.Value);
    }
}