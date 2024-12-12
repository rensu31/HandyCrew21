﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Messaging;
using HandyCrew.Models;

namespace HandyCrew.Services
{
   public class LocationSyncService
   {
       private bool _isListening;

        public async Task Start()
        {
            Geolocation.LocationChanged += Geolocation_LocationChanged;
            var request = new GeolocationListeningRequest(GeolocationAccuracy.Best, TimeSpan.FromSeconds(1));
            if (request is not null)
            {
              _isListening = await Geolocation.StartListeningForegroundAsync(request); 
            }

        }


        public async Task Stop()
        {
            Geolocation.LocationChanged += Geolocation_LocationChanged;
            Geolocation.StopListeningForeground();
            _isListening = false;
        }



        private void Geolocation_LocationChanged(Object? sender, GeolocationLocationChangedEventArgs e)
        {

            var deviceLocation = new DeviceLocation(e.Location.Latitude, e.Location.Longitude);
            WeakReferenceMessenger.Default.Send(deviceLocation);
        }


    }
}