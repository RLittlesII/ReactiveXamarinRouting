using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Splat;

namespace Routing.Droid
{
    [Activity(Label = "Routing.Droid", Icon = "@drawable/icon", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);

            var compositionRoot = new AndroidCompositionRoot();
            var registrar = new AndroidDependencyRegistrar();
            registrar.Register(Locator.CurrentMutable, compositionRoot);
            var app = compositionRoot.ResolveApp();
            app.Initialize();

            LoadApplication(app);
        }
    }
}