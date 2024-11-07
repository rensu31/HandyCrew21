using System.Collections.ObjectModel;
using System.Net.Mime;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Views;
using HandyCrew.Models;
using static HandyCrew.Includes.GlobalVariables;
using Microsoft.Maui.Graphics;
using Color = Microsoft.Maui.Graphics.Color;
using Font = Microsoft.Maui.Font;
using static HandyCrew.App;
using Image = Microsoft.Maui.IImage;


namespace HandyCrew.Views;

public partial class Addpopup : Popup
{

    Posts _posts = new();

    CancellationTokenSource _cancellationTokenSource = new();
    public ObservableCollection<string> Items { get; set; } = new ObservableCollection<string>();
public Addpopup()
	{
		InitializeComponent();


        Items.Add("Computer");
        Items.Add("Aircon Cleaning");
        Items.Add("Plumbing");
        Items.Add("Landscape");
        Items.Add("Cleaning");
        Items.Add("Technician");
      
        Categories.ItemsSource = Items;
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
        var snackbarOptions = new SnackbarOptions
        {
            BackgroundColor = Color.FromRgb(32, 32, 40),
            TextColor = Colors.WhiteSmoke,
            ActionButtonTextColor = Colors.White,
            CornerRadius = new CornerRadius(10),
            Font = Font.SystemFontOfSize(10),
            ActionButtonFont = Font.SystemFontOfSize(10)
        };
        const string text = "The image you have selected is more than 0.50MB please ensure that the size of the image is less than the maximum size. Thank you!";
        const string actionButtonText = "Got it!";
        var duration = TimeSpan.FromSeconds(10);
        var snackbar = Snackbar.Make(text, null, actionButtonText, duration, snackbarOptions);

        await snackbar.Show(_cancellationTokenSource.Token);
        return;
    }
    var stream = await result.OpenReadAsync();
    _mainimgResult = result;
    mainimage.Source = ImageSource.FromStream(() => stream);
}


    private async void BtnAdd_OnClicked(object? sender, EventArgs e)
    {   

        var flename = "test";
       var selecteditem = Categories.SelectedItem as string;

    
     await _posts._AddPost(txtpost.Text, txtdesc.Text, selecteditem, _mainimgResult, flename);

    }

    private void BtnClose_OnClicked(object? sender, EventArgs e)
    {
        Close();
    }

  
}