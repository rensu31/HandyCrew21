using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandyCrew.Models
{
    public static class PanaboCityBoundary
    {

        public const double MinLatitude = 7.15;  // Minimum latitude for Panabo City
        public const double MaxLatitude = 7.45;  // Maximum latitude for Panabo City
        public const double MinLongitude = 125.45; // Minimum longitude for Panabo City
        public const double MaxLongitude = 125.75; // Maximum longitude for Panabo City

        public static bool IsWithinBounds(double latitude, double longitude)
        {
            return latitude >= MinLatitude && latitude <= MaxLatitude &&
                   longitude >= MinLongitude && longitude <= MaxLongitude;
        }
    }
}
