using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ENIE.Views.ErrorAndEmpty;
using ENIE.Views;

namespace ENIE
{
    public partial class App : Application
    {
        public static string BaseImageUrl { get; } = "https://cdn.syncfusion.com/essential-ui-kit-for-xamarin.forms/common/uikitimages/";
        public App()
        { 
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MTk2OTUwQDMxMzcyZTM0MmUzMENVT1lVMTlZUGFhZk9PUlR0a2ZPY0V4KzlRVW1TRlAvWndDalREWDFyVmc9");
            InitializeComponent();
           
            MainPage = new MainView();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
