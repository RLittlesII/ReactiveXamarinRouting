using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using ReactiveUI;
using Splat;
using UIKit;

namespace Routing.iOS
{
	[Register("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching(UIApplication application, NSDictionary options)
		{
			//RxApp.DefaultExceptionHandler = null;

			global::Xamarin.Forms.Forms.Init();
			var compositionRoot = new iOSCompositionRoot();
			var registrar = new iOSDependencyRegistrar();
			registrar.Register(Locator.CurrentMutable, compositionRoot);
			var app = compositionRoot.ResolveApp();
			app.Initialize();

			LoadApplication(app);
			return base.FinishedLaunching(application, options);
		}
	}
}