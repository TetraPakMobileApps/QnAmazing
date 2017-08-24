using Xamarin.Forms;

namespace QnAmazing
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var navigationPage = new NavigationPage(new QnAmazingPage());
            navigationPage.BarBackgroundColor = new Color(0xEF / 255.0, 0x98 / 255.0, 0x84 / 255.0);
            navigationPage.BarTextColor = Color.Black;
            MainPage = navigationPage;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
