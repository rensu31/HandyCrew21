using HandyCrew.Views;

namespace HandyCrew
{
    public partial class App : Application
    {
        public static FileResult _mainimgResult;
        public App()
        {
            InitializeComponent();

            MainPage = new chooseLogin();
        }
    }
}
