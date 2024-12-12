
using HandyCrew.Models;

namespace HandyCrew.Views;

public partial class UserDashboard : ContentPage
{
    private posts _posts = new();
	public UserDashboard()
	{
		InitializeComponent();
        FillList();
}

    public UserDashboard(string userkey, string userFullname) : this()
    {
        InitializeComponent();
        App.UserkeyUser = userkey;
        App.fullNameuSER = userFullname;
    }

    protected override async void OnAppearing()

    {
        base.OnAppearing();
        await FillList();
    }

    private async Task FillList()
    {
       // Get the list of service providers with their posts
    var serviceProviders = await _posts.GetServiceProvidersWithPosts();

    // Create a list to hold all posts
    var Postss = new List<posts.Post>();

    // Loop through each service provider
    foreach (var provider in serviceProviders)
    {
        // Check if the provider has posts
        if (provider.Posts != null)
        {
            // Add each post to the posts list
            foreach (var post in provider.Posts.Values) // Assuming Posts is a Dictionary<string, Post>
            {
                Postss.Add(post);
}
        }
    }

    // Set the flattened list of posts as the ItemsSource for the CollectionView
    ListPosts.ItemsSource = Postss;
    }



    private async void OnPostSelected(object sender, SelectionChangedEventArgs e)
    {
        // Check if an item is selected
        if (e.CurrentSelection.FirstOrDefault() is posts.Post selectedPost)
        {
            // Create a new instance of the detail page
            var detailPage = new ViewPost();

            // Set the BindingContext to the selected post
            detailPage.BindingContext = new posts()
            {
                TitlePost = selectedPost.TitlePost,
                Description = selectedPost.Description,
                Image = selectedPost.Image
            };

            // Navigate to the detail page
            await Navigation.PushAsync(detailPage);

            // Optionally, deselect the item
            ListPosts.SelectedItem = null;
        }
    }

   
}