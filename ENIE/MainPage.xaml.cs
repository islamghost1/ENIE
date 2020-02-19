using ENIE.ViewModels;
using System;
using System.Diagnostics;
using System.Linq;

using System.Collections.Generic;
using ENIE.Models;
using System.ComponentModel;
using Xamarin.Forms.GoogleMaps;
using System.Threading.Tasks;
using System.Threading;
using Xamarin.Forms;
using Plugin.Geolocator;
using System.Reactive.Disposables;
using System.Reactive;
using System.Reactive.Linq;

namespace ENIE
{


// Learn more about making custom code visible in the Xamarin.Forms previewer
// by visiting https://aka.ms/xamarinforms-previewer
  [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {

        public static double Latitude;
        public static double Longitude;
 

        public MainPage()
        {

            InitializeComponent();
            InitializeValues();
            GetPosition();
          
            SetValue(NavigationPage.HasNavigationBarProperty, false);
           // BindingContext = new MainPageViewModel();


             
        }
        public void InitializeValues()
        {
            //Latitude = 0;
            //Longitude=0;
            //making th hight and the width change dinamycly 
            Searsh.HeightRequest = (App.screenHeight * 20) / 250;
            Searsh.WidthRequest = (App.screenWidth * 70) / 75;
            XpandeViewForSettings.TranslationY =(App.screenHeight);
            XpandeViewForSettings.HeightRequest = (App.screenHeight);

         
        }
            public async void GetPosition() 
        {
            //Getting user location : 
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 50;

            TimeSpan ts = new TimeSpan(0,0,1000);
            var position = await locator.GetPositionAsync(ts);

             Latitude = position.Latitude;
             Longitude = position.Longitude;
            MainMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(Latitude, Longitude), Distance.FromKilometers(2)));
        }

        protected override void OnAppearing()
        {
            //drawing the user location as Pin
            base.OnAppearing();
        
            MainMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(Latitude, Longitude), Distance.FromKilometers(2)));
            LabelPostion.Text = Latitude.ToString();
            Label2Postion.Text = Longitude.ToString();

        }


        //Slide view Up 


        private async void SettingButtonVisibility()
        {
          //  MainMap.MapStyle = MapStyle.FromJson("[\r\n  {\r\n    \"elementType\": \"geometry\",\r\n    \"stylers\": [\r\n      {\r\n        \"color\": \"#212121\"\r\n      }\r\n    ]\r\n  },\r\n  {\r\n    \"elementType\": \"labels.icon\",\r\n    \"stylers\": [\r\n      {\r\n        \"visibility\": \"off\"\r\n      }\r\n    ]\r\n  },\r\n  {\r\n    \"elementType\": \"labels.text.fill\",\r\n    \"stylers\": [\r\n      {\r\n        \"color\": \"#757575\"\r\n      }\r\n    ]\r\n  },\r\n  {\r\n    \"elementType\": \"labels.text.stroke\",\r\n    \"stylers\": [\r\n      {\r\n        \"color\": \"#212121\"\r\n      }\r\n    ]\r\n  },\r\n  {\r\n    \"featureType\": \"administrative\",\r\n    \"elementType\": \"geometry\",\r\n    \"stylers\": [\r\n      {\r\n        \"color\": \"#757575\"\r\n      }\r\n    ]\r\n  },\r\n  {\r\n    \"featureType\": \"administrative.country\",\r\n    \"elementType\": \"labels.text.fill\",\r\n    \"stylers\": [\r\n      {\r\n        \"color\": \"#9e9e9e\"\r\n      }\r\n    ]\r\n  },\r\n  {\r\n    \"featureType\": \"administrative.locality\",\r\n    \"elementType\": \"labels.text.fill\",\r\n    \"stylers\": [\r\n      {\r\n        \"color\": \"#bdbdbd\"\r\n      }\r\n    ]\r\n  },\r\n  {\r\n    \"featureType\": \"poi\",\r\n    \"elementType\": \"labels.text.fill\",\r\n    \"stylers\": [\r\n      {\r\n        \"color\": \"#757575\"\r\n      }\r\n    ]\r\n  },\r\n  {\r\n    \"featureType\": \"poi.park\",\r\n    \"elementType\": \"geometry\",\r\n    \"stylers\": [\r\n      {\r\n        \"color\": \"#181818\"\r\n      }\r\n    ]\r\n  },\r\n  {\r\n    \"featureType\": \"poi.park\",\r\n    \"elementType\": \"labels.text.fill\",\r\n    \"stylers\": [\r\n      {\r\n        \"color\": \"#616161\"\r\n      }\r\n    ]\r\n  },\r\n  {\r\n    \"featureType\": \"poi.park\",\r\n    \"elementType\": \"labels.text.stroke\",\r\n    \"stylers\": [\r\n      {\r\n        \"color\": \"#1b1b1b\"\r\n      }\r\n    ]\r\n  },\r\n  {\r\n    \"featureType\": \"road\",\r\n    \"elementType\": \"geometry.fill\",\r\n    \"stylers\": [\r\n      {\r\n        \"color\": \"#2c2c2c\"\r\n      }\r\n    ]\r\n  },\r\n  {\r\n    \"featureType\": \"road\",\r\n    \"elementType\": \"labels.text.fill\",\r\n    \"stylers\": [\r\n      {\r\n        \"color\": \"#8a8a8a\"\r\n      }\r\n    ]\r\n  },\r\n  {\r\n    \"featureType\": \"road.arterial\",\r\n    \"elementType\": \"geometry\",\r\n    \"stylers\": [\r\n      {\r\n        \"color\": \"#373737\"\r\n      }\r\n    ]\r\n  },\r\n  {\r\n    \"featureType\": \"road.highway\",\r\n    \"elementType\": \"geometry\",\r\n    \"stylers\": [\r\n      {\r\n        \"color\": \"#3c3c3c\"\r\n      }\r\n    ]\r\n  },\r\n  {\r\n    \"featureType\": \"road.highway.controlled_access\",\r\n    \"elementType\": \"geometry\",\r\n    \"stylers\": [\r\n      {\r\n        \"color\": \"#4e4e4e\"\r\n      }\r\n    ]\r\n  },\r\n  {\r\n    \"featureType\": \"road.local\",\r\n    \"elementType\": \"labels.text.fill\",\r\n    \"stylers\": [\r\n      {\r\n        \"color\": \"#616161\"\r\n      }\r\n    ]\r\n  },\r\n  {\r\n    \"featureType\": \"transit\",\r\n    \"elementType\": \"labels.text.fill\",\r\n    \"stylers\": [\r\n      {\r\n        \"color\": \"#757575\"\r\n      }\r\n    ]\r\n  },\r\n  {\r\n    \"featureType\": \"water\",\r\n    \"elementType\": \"geometry\",\r\n    \"stylers\": [\r\n      {\r\n        \"color\": \"#000000\"\r\n      }\r\n    ]\r\n  },\r\n  {\r\n    \"featureType\": \"water\",\r\n    \"elementType\": \"labels.text.fill\",\r\n    \"stylers\": [\r\n      {\r\n        \"color\": \"#3d3d3d\"\r\n      }\r\n    ]\r\n  }\r\n]");
            OnAppearing();
           
          

            SettingButton.IsVisible = false;
            await Task.Delay(100);
            SettingButton.IsVisible = true;
            //var pin = new Pin
            //{
            //    Position = new Position(Latitude, Longitude),
            //    Label = $"islam",
            //    Address = $"islam"
            //};

            //MainMap.Pins.Add(pin);

          //  XpandeViewForSettings.HeightRequest = App.screenHeight;
           // await XpandeViewForSettings.TranslateTo(0, -(App.screenHeight), 50);

            //await Task.Delay(2000);
            await XpandeViewForSettings.TranslateTo(0, 0, 200);
           // XpandeViewForSettings.HeightRequest = 0;


        }

        //void PanGestureHandler(object sender, PanUpdatedEventArgs e)
        //{
        //    layoutHeight = layoutHeight ?? ((sender as StackLayout).Parent as AbsoluteLayout).Height;
        //    switch (e.StatusType)
        //    {
        //        case GestureStatus.Started:
        //            layoutBoundsHeight = AbsoluteLayout.GetLayoutBounds(sender as StackLayout).Height;
        //            break;
        //        case GestureStatus.Running:
        //            direction = e.TotalY < 0 ? 1 : -1;
        //            break;
        //        case GestureStatus.Completed:
        //            if (direction > 0) // snap to max/min, you could use an animation....
        //            {
        //                AbsoluteLayout.SetLayoutBounds(bottomDrawer, new Rectangle(0.5, 1.00, 0.9, layoutPropHeightMax));
        //                swipeLabel.Text = "Swipe me down";
        //            }
        //            else
        //            {
        //                AbsoluteLayout.SetLayoutBounds(bottomDrawer, new Rectangle(0.5, 1.00, 0.9, layoutPropHeightMin));
        //                swipeLabel.Text = "Swipe me up";
        //            }
        //            break;
        //    }
        //}


        void OnClickedSettingButton(object sender, EventArgs args)
        {
            SettingButtonVisibility();
        }  void OnIconSettingTapped(object sender, EventArgs args)
        {
            SettingButtonVisibility();
        }void OnClickedArrowBack(object sender, EventArgs args)
        {
            XpandeViewForSettings.TranslationY = (App.screenHeight);
            XpandeViewForSettings.HeightRequest = (App.screenHeight);
        }
    }
}

