using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.GoogleMaps;

namespace ENIE.Models
{
   public class BusInfo
    {
       

        public  string BusReferrence
        {
            get;
            set;
        } 
        public  double BusAltitude 
        {
            get ;
            set ;
        } 
        public  double BusLongitude 
        {
            get;
            set;
        }
        public Position Position { get;  set; }
        public string Label { get;  set; }
        public string Address { get;  set; }
    }
}
