using ReactiveUI;
using Routing.Navigation;
using Routing.UI.Login;
using Splat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Routing.UI
{
    public abstract class DependencyRegistrar
    {
        public void Register(IMutableDependencyResolver dependencyResolver, CompositionRoot compositionRoot)
        {
            RegisterServices(dependencyResolver, compositionRoot);
            RegisterViews(dependencyResolver);
            RegisterScreen(dependencyResolver, compositionRoot);
            RegisterPlatformComponents(dependencyResolver, compositionRoot);
        }

        protected T CreateView<T>()
            where T : new()
        {
            return new T();
        }

        protected abstract void RegisterPlatformComponents(IMutableDependencyResolver splatLocator, CompositionRoot compositionRoot);

        private void RegisterScreen(IMutableDependencyResolver dependencyResolver, CompositionRoot compositionRoot)
        {
            dependencyResolver.RegisterLazySingleton(compositionRoot.ResolveNavigationView, typeof(IView));
        }

        private void RegisterServices(IMutableDependencyResolver dependencyResolver, CompositionRoot compositionRoot)
        {
            dependencyResolver.RegisterLazySingleton(() => compositionRoot.ViewStackService, typeof(IViewStackService));
        }

        private void RegisterViews(IMutableDependencyResolver dependencyResolver)
        {
            dependencyResolver.InitializeSplat();
            dependencyResolver.InitializeReactiveUI();
            dependencyResolver.Register(CreateView<LoginPage>, typeof(IViewFor<LoginViewModel>));
        }
    }
}