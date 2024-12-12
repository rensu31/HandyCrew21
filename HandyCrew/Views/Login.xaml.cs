using Firebase.Database;
using HandyCrew.Models;
using static HandyCrew.Includes.GlobalVariables;
using Firebase.Database.Query;
using HandyCrew.Includes;

namespace HandyCrew.Views;

public partial class Login : ContentPage
{

    Users _users= new();
	public Login()
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

        try
        {
            bool a;
            a = await _users._GetUser(Username.Text, Password.Text);
            if (!a)
            {
                await DisplayAlert("Access Denied", "Please try again!", "Okay");
                return;
            }

            string iD = await GetUserByFirstNameAndLastName(Username.Text);
            if (string.IsNullOrEmpty(iD))
            {
                await DisplayAlert("Error", "User  not found 1", "Okay");
                return;
            }

            var user = await client.Child("Users").Child(iD).OnceSingleAsync<Users>();
            if (user == null)
            {
                await DisplayAlert("Error", "User  not found 2", "Okay");
                return;
            }

            string userFullName = $"{user.FirstName} {user.LastName}";

            GlobalVariables.email = iD;
            GlobalVariables.Fullname = userFullName;
            await DisplayAlert("Access Granted", "Logging in", "Okay");
            await DisplayAlert("Access Granted", iD, "Okay");
            Application.Current.MainPage = new UserDashboard(iD, userFullName);
        }
        catch (FirebaseException ex)
        {
            await DisplayAlert("Firebase Error", $"An error occurred: {ex.Message}", "Okay");
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"An unexpected error occurred: {ex.Message}", "Okay");
        }
    }


    private void Button_OnClicked(object? sender, EventArgs e)
    {
        Application.Current!.MainPage = new SignUp();
    }


    private async Task<string> GetUserByFirstNameAndLastName(string Username)
    {
        var users = await client.Child("Users").OnceAsync<Users>();

        var userWithKey = users.FirstOrDefault(u => u.Object.Username.Equals(Username, StringComparison.OrdinalIgnoreCase));

        return userWithKey?.Key;
    }

    //private void Button_Clicked(object sender, EventArgs e)
    //{
    //    Application.Current!.MainPage = new UserRegistration();

    //}


    private void Buttonback_OnClicked(object? sender, EventArgs e)
    {
        Application.Current!.MainPage = new chooseLogin();
    }
}