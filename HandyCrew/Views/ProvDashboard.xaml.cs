using CommunityToolkit.Maui.Views;

namespace HandyCrew.Views;

public partial class ProvDashboard : ContentPage
{
	public ProvDashboard()
	{
		InitializeComponent();
	}

    private async void ImageButton_OnClicked(object? sender, EventArgs e)
    {
        var popup = new Addpopup();
        this.ShowPopup(popup);


    }
}