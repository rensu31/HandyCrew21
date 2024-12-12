using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using static HandyCrew.Includes.GlobalVariables;
using HandyCrew.Services;
using Essentials = Xamarin.Essentials;
using Microsoft.Maui.Devices.Sensors;
using MauiSensors = Microsoft.Maui.Devices.Sensors;
using HandyCrew.Includes;

namespace HandyCrew.Models.ViewModels
{
    public partial class MainpageViewModel : ObservableObject
    {
        private readonly LocationHQService _locationHQService;

        [ObservableProperty]
        private double latitude;

        [ObservableProperty]
        private double longitude;

        [ObservableProperty]
        private bool isListening;

        [ObservableProperty]
        private string? listeningButtonText;

        [ObservableProperty]
        private string? address;

        public MainpageViewModel(LocationHQService locationHQService)
        {
            _locationHQService = locationHQService;
            ListeningButtonText = "Start";
        }

        [RelayCommand]
        private async Task ChangeListeningMode()
        {
            if (!isListening)
            {
                // Get current location using LocationHQService
                await GetCurrentLocation();
                isListening = true;
                ListeningButtonText = "Stop";
            }
            else
            {
                isListening = false;
                ListeningButtonText = "Start";
            }
        }

        private async Task GetCurrentLocation()
        {
            try
            {
                var status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();
                if (status != PermissionStatus.Granted)
                {
                    status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
                }

                if (status == PermissionStatus.Granted)
                {
                    var request = new MauiSensors.GeolocationRequest(MauiSensors.GeolocationAccuracy.Best);
                    var location = await MauiSensors.Geolocation.GetLocationAsync(request);

                    if (location != null)
                    {
                        Latitude = location.Latitude;
                        Longitude = location.Longitude;

                        GlobalVariables.Lated = Latitude;
                        GlobalVariables.Loted = Longitude;

                        Console.WriteLine($"Latitude: {Latitude}, Longitude: {Longitude}"); // Debugging line
                    }
                    else
                    {
                        Address = "Location not available.";
                    }
                }
                else
                {
                    Address = "Location permission denied.";
                }
            }
            catch (Exception ex)
            {
                Address = $"Error retrieving location: {ex.Message}";
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}