using System;

using Xamarin.Forms;

namespace SimpleVMS
{
    public partial class App : Application
    {
        public static bool UseMockDataStore = true;
        public static bool IsUserLoggedIn { get; set; }

        public static string BackendUrl = "https://localhost:5000";

        public App()
        {
            InitializeComponent();

            if (UseMockDataStore)
                DependencyService.Register<MockDataStore>();
            else
                DependencyService.Register<CloudDataStore>();

            if (Device.RuntimePlatform == Device.iOS)
                MainPage = new LoginPage();
            else
                MainPage = new NavigationPage(new LoginPage());
        }
    }

    public static class Constants
    {
        public static string Username = "Xamarin";
        public static string Password = "password";
    }

    public class User
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }
    }
}
