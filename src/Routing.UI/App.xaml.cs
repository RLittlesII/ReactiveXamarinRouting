using System;
using Routing.Navigation;
using Routing.UI;
using Xamarin.Forms;

namespace Routing
{
    public partial class App : Application
    {
        private static App instance;
        private readonly Func<NavigationView> _navigationView;

        public App(Func<NavigationView> navigationView)
        {
            instance = this;
            InitializeComponent();
            _navigationView = navigationView;
        }

        public void Initialize()
        {
            MainPage = _navigationView();
        }
    }
}