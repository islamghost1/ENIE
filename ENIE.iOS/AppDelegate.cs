using Syncfusion.XForms.iOS.Core;
using Syncfusion.XForms.iOS.Buttons;
using Syncfusion.XForms.iOS.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms.GoogleMaps.iOS;
using Foundation;
using UIKit;

namespace ENIE.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {

        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            Xamarin.FormsGoogleMaps.Init("AIzaSyBmpHj_kS8Q3UXgpB1Hi-5pzKznIeQtHTM");
            global::Xamarin.Forms.Forms.Init();
            Core.Init();
            SfButtonRenderer.Init();
            SfGradientViewRenderer.Init();
            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }
    }
}
