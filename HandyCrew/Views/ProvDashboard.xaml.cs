using CommunityToolkit.Maui.Views;

namespace HandyCrew.Views;

public partial class ProvDashboard : ContentPage
{
	public ProvDashboard()
	{
		InitializeComponent();
	}

    public ProvDashboard(string userkey, string userFullname) : this()
    {
        InitializeComponent();
        App.UserkeyUser = userkey;
        App.fullNameuSER = userFullname;
    }
    private async void ImageButton_OnClicked(object? sender, EventArgs e)
    {
        var popup = new Addpopup();
        this.ShowPopup(popup);


    }
}