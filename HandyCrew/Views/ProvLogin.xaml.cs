using HandyCrew.Models;
using static HandyCrew.Includes.GlobalVariables;
namespace HandyCrew.Views;

public partial class ProvLogin : ContentPage
{
     Users _users = new();
	public ProvLogin()
	{
		InitializeComponent();
	}

    private async void Button_OnClicked1(object sender, EventArgs e)
    {

        if (string.IsNullOrEmpty(Username.Text))
        {
            await DisplayAlert("Data Validation", "Please enter Username", "Got It");
            return;
        }
        if (string.IsNullOrEmpty(Password.Text))
        {
            await DisplayAlert("Data Validation", "Please enter the Password", "Got It");
            return;
        }

        bool a;
        a = await _users._GetUserprov(Username.Text, Password.Text);


        if (a)
        {

            await DisplayAlert("Access Granted", "Logging in",
                "Okay");
            
            Application.Current!.MainPage = new ProvDashboard();


        }

        if (!a)
        {

            await DisplayAlert("Access Denied", "please try again!",
                "Okay");


            return;
        }
    }

    private void Button_OnClicked(object? sender, EventArgs e)
    {
        Application.Current!.MainPage = new SignUp();
    }


}