using HandyCrew.Models.ViewModels;

namespace HandyCrew
{
    public partial class MainPage : ContentPage
    {
        

        public MainPage(MainpageViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }

        private async void OnCounterClicked(object sender, EventArgs e)
        {
         
        }
    }

}
