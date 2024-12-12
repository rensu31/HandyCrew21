using static HandyCrew.Includes.GlobalVariables;
using HandyCrew.Models;
using HandyCrew.Models.ViewModels;
using HandyCrew.Services;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using System.Threading;
using System.Collections.ObjectModel;
using System.Net.Mime;
using CommunityToolkit.Maui.Views;

using Microsoft.Maui.Graphics;
using Color = Microsoft.Maui.Graphics.Color;
using Font = Microsoft.Maui.Font;
using static HandyCrew.App;
using Image = Microsoft.Maui.IImage;

namespace HandyCrew.Views;

public partial class AddProfileLocation : ContentPage
{
    Users _users = new();
    CancellationTokenSource _cancellationTokenSource = new();


    public AddProfileLocation()
	{
		InitializeComponent();

        HttpClient httpClient = new HttpClient();

        // Create an instance of LocationHQService with the HttpClient
        LocationHQService locationHQService = new LocationHQService(httpClient);
        MainpageViewModel viewModel = new MainpageViewModel(locationHQService);
        BindingContext = viewModel; // Set the BindingContext to the ViewModel

    }






    private async void Submit_OnClicked(object? sender, EventArgs e)
    {
        var result = await FilePicker.PickAsync(new PickOptions
        {
            PickerTitle = "Select main image",
            FileTypes = FilePickerFileType.Images
        });
        if (result == null) return;

        FileInfo fi = new(result.FullPath);
        var size = fi.Length;

        if (size > 524288)
        {
            await DisplayAlert("Message", "The image you have selected is more than 0.50MB please ensure that the size of the image is less than the maximum size. Thank you!", "Got It.");
            return;
        }
        var stream = await result.OpenReadAsync();
        _mainimgResult = result;
        mainimage.Source = ImageSource.FromStream(() => stream);
    }

    private async void ListenButton_OnClicked(object? sender, EventArgs e)
    {


        await Task.Delay(3000);
        if (PanaboCityBoundary.IsWithinBounds(Lated, Loted))
        {
            await DisplayAlert("You are Within Panabo", "You can use the app", "okay");
            btnnext.IsEnabled = true;

        }
        else
        {
            await DisplayAlert("You are not Within Panabo", "You cant use the app", "okay");
            Application.Current.Quit();
        }
       

    }

    private async void Btnnext_OnClicked(object? sender, EventArgs e)
    {
        var flename = "Fullname";

        await _users._AddProf(txtaddress.Text,
            _mainimgResult,
            flename);

        var toastMessage = "Post has been successfully added!";
        var toastDuration = TimeSpan.FromSeconds(4); // Duration for the toast display

        // Create and show the toast
        var toast = Toast.Make(toastMessage, ToastDuration.Short);
        await toast.Show();

      
        

    }

  
}