using Xamarin.Essentials;
namespace HandyCrew.Views;

public partial class chooseLogin : ContentPage
{
	public chooseLogin()
	{
		InitializeComponent();
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        if (IsConnected())
        {
            // Optionally, you can perform actions when connected
        }
        else
        {
            await DisplayAlert("Connection Error", "Please check your internet connection and try again.", "OK");
        }

    }

    private bool IsConnected()
    {
        var current = Microsoft.Maui.Networking.Connectivity.NetworkAccess;
        return current == Microsoft.Maui.Networking.NetworkAccess.Internet;
    }

    private async void Button_OnClicked(object? sender, EventArgs e)
    {
       

         Application.Current!.MainPage = new Login();
    }

    private async void Button_OnClicked1(object? sender, EventArgs e)
    {

        Application.Current!.MainPage = new ProvLogin();
    }
}