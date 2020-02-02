using System;
using System.Collections.Generic;
using System.Text;

using System.ComponentModel;

using System.Threading.Tasks;
using Xamarin.Forms;
using ENIE.Models;
using Xamarin.Forms.Maps;

namespace ENIE.ViewModels
{
    class MainPageViewModel
    {
        public BusInfo BusInfo { get; set; }
        //public double busAltitude = 35.191452;
        //public double busLongitude = -0.602484;
        public  MainPageViewModel ()
        {
      
            BusInfo = new BusInfo
            {
                Position = new Position(35.19,-0.60),
                BusAltitude = 35.191452,
                BusLongitude= -0.602484,
                Label = "Xamarin San Francisco Office",
                Address = "394 Pacific Ave, San Francisco CA",
                BusReferrence="BUS N° 1"

             };

          
        }

       
        

    }
}


