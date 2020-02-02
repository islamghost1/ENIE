using ENIE.ViewModels;
using System;
using ENIE.Models;
using System.ComponentModel;

using System.Threading.Tasks;
using Xamarin.Forms;

using Xamarin.Forms.Maps;


namespace ENIE
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            SetValue(NavigationPage.HasNavigationBarProperty, false);

            //var map = new Map(MapSpan.FromCenterAndRadius(new Position(35.191452, -0.602484), Distance.FromMiles(1)));

            //var pin = new Pin()
            //{
            //    Position = new Position(35.191452, -0.602484),
            //    Label = "Some Pin!"
            //};
            //map.Pins.Add(pin);


           // Content = map;

            BindingContext = new MainPageViewModel();
        
            

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            MainMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(35.191452, -0.602484), Distance.FromKilometers(5)));
            var pin = new Pin

            {
                Position = new Position(35.191452, -0.602484),
                Label = "Xamarin San Francisco Office",
                Address = "394 Pacific Ave, San Francisco CA"
            };
            MainMap.Pins.Add(pin);
        }


        private async void SettingButtonVisibility()
        {
            SettingButton.IsVisible=false;
            SettingIcon.IsVisible = false;
            await Task.Delay(2000);
            SettingButton.IsVisible = true;
            SettingIcon.IsVisible = true;
        }
        void OnClickedSettingButton(object sender, EventArgs args)
        {
            SettingButtonVisibility();
        }  void OnIconSettingTapped(object sender, EventArgs args)
        {
            SettingButtonVisibility();
        }

    }
}

