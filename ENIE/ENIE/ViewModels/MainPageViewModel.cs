using System;
using System.Collections.Generic;
using System.Text;

using System.ComponentModel;

using System.Threading.Tasks;
using Xamarin.Forms;
using ENIE.Models;
using Xamarin.Forms.GoogleMaps;

namespace ENIE.ViewModels
{
    class MainPageViewModel
    {
        public BusInfo BusInfo { get; set; }
    
        public  MainPageViewModel ()
        {
      
            BusInfo = new BusInfo
            {
                

             };

          
        }

       
        

    }
}


