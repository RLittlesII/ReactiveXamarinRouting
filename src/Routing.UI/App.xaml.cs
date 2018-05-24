using System;
using Routing.Navigation;
using Routing.UI;
using Routing.UI.Login;
using Xamarin.Forms;

namespace Routing
{
    public partial class App : Application
    {
        private static App instance;
        private readonly Func<NavigationView> _navigationView;
        private readonly IViewStackService _viewStackService;

        public App(Func<NavigationView> navigationView, IViewStackService viewStackService)
        {
            instance = this;
            InitializeComponent();
            _navigationView = navigationView;
            this._viewStackService = viewStackService;
        }

        public void Initialize()
        {
            var view = _navigationView();
            MainPage = view;
            view.PushPage(new LoginViewModel(_viewStackService), null, true, false).Subscribe();
        }
    }
}