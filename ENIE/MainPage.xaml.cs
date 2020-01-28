using System;

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
            Task.Delay(2000);
            Map map = new Map();
            Content = map;
        }

       
    }
}

