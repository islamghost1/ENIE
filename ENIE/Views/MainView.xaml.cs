using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace ENIE.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainView : ContentPage
    {
        public MainView()
        {
            InitializeComponent();
            SetValue(NavigationPage.HasNavigationBarProperty,false);
            Login();

        }
        private async void Login()
        {
            await Task.Delay(4000);
            await Navigation.PushAsync(new MainPage());
        }
    }
}