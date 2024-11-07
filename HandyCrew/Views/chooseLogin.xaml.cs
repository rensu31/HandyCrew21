namespace HandyCrew.Views;

public partial class chooseLogin : ContentPage
{
	public chooseLogin()
	{
		InitializeComponent();
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