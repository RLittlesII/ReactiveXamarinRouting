using ReactiveUI;
using ReactiveUI.XamForms;
using Routing.Navigation;

namespace Routing.UI.Login
{
    public class BaseContentPage<T> : ReactiveContentPage<T>
        where T : class
    {
    }

    public class BaseViewModel : ReactiveObject
    {
        protected readonly IViewStackService ViewStackService;

        public BaseViewModel(IViewStackService viewStackService)
        {
            ViewStackService = viewStackService;
        }
    }
}