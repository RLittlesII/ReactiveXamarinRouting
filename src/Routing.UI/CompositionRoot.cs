using ReactiveUI;
using Routing.Navigation;
using Splat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Concurrency;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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

        private Func<NavigationView> NavigationViewFactory => () => new NavigationView(BackgroundScheduler.Value, MainScheduler.Value, CurrentViewLocator.Value);

        public CompositionRoot()
        {
            App = new Lazy<App>(CreateApp);
            MainScheduler = new Lazy<IScheduler>(CreateMainScheduler);
            BackgroundScheduler = new Lazy<IScheduler>(CreateBackgroundScheduler);
            NavigationView = new Lazy<NavigationView>(NavigationViewFactory);
            CurrentViewLocator = new Lazy<IViewLocator>(CreateViewLocator);
        }

        public App ResolveApp() => App.Value;

        private App CreateApp() => new App(NavigationViewFactory);

        private IScheduler CreateBackgroundScheduler() => new EventLoopScheduler();

        private IScheduler CreateMainScheduler() => new SynchronizationContextScheduler(SynchronizationContext.Current);

        private IViewLocator CreateViewLocator() => Locator.Current.GetService<IViewLocator>();
    }
}