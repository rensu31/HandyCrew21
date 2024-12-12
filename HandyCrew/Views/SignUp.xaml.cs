using System.Collections.ObjectModel;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.PlatformConfiguration.iOSSpecific;
using HandyCrew.Models;
using Firebase.Database;
using static HandyCrew.Includes.GlobalVariables;
using Firebase.Database.Query;
using HandyCrew.Includes;
using Application = Microsoft.Maui.Controls.Application;

namespace HandyCrew.Views;

public partial class SignUp : ContentPage
{
     Users _users = new();
    public ObservableCollection<string> Accs { get; set; } = new ObservableCollection<string>();

    public SignUp()
    {
		InitializeComponent();

        Accs.Add("Homeowner");
        Accs.Add("Service Provider");
        Acc.ItemsSource = Accs;
    }

    private void Button1_OnClicked(object? sender, EventArgs e)
    {
        throw new NotImplementedException();
        
    }

    private async void BtnAdd_OnClicked(object? sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(txtfname.Text))
        {
            await DisplayAlert("Data Validation", "Please enter First Name!", "Got It");
            return;
        }
        if (string.IsNullOrEmpty(txtlname.Text))
        {
            await DisplayAlert("Data Validation", "Please enter Last Name!", "Got It");
            return;
        }
        if (string.IsNullOrEmpty(Username.Text))
        {
            await DisplayAlert("Data Validation", "Please enter Username!", "Got It");
            return;
        }
        if (string.IsNullOrEmpty(pass.Text))
        {
            await DisplayAlert("Data Validation", "Please enter Password!", "Got It");
            return;
        }
        var selectedAcc = Acc.SelectedItem.ToString();


        string SignUID = string.Empty;



        bool b;
        b = await _users.GetUsername(Username.Text);
        if (b)
        {
            await _users._SignUp(txtfname.Text, txtlname.Text,$"{selectedAcc}", Username.Text, pass.Text);



            Application.Current!.MainPage = new AddProfileLocation();

            if (selectedAcc == "Homeowner")
            {
                SignUID = await _users.GetSignUserByFirstNameAndLastName1(Username.Text);
            }

            if (selectedAcc == "Service Provider")
            {
                SignUID = await _users.GetSignUserByFirstNameAndLastName(Username.Text);
            }


      

           
            GlobalVariables.email = SignUID;

            await DisplayAlert("Test", GlobalVariables.email, "Okay");


        }

        if (!b)
        {

            await DisplayAlert("Username Already Exist", "" +
                                                         "The Username you have entered is already in the records please try again!", "Okay");
            return;
        }

        txtfname.Text = string.Empty;
        txtlname.Text = string.Empty;
        Username.Text = string.Empty;
        pass.Text = string.Empty;

        return;

    }

  

}