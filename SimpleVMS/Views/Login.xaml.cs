using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace SimpleVMS
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            var user = new User
            {
                Username = usernameEntry.Text,
                Password = passwordEntry.Text
            };

            var isValid = AreCredentialsCorrect(user);
            if (isValid)
            {
                App.IsUserLoggedIn = true;
                if (Device.RuntimePlatform == Device.iOS)
                    Application.Current.MainPage = new MainPage();
                else
                    Application.Current.MainPage = new NavigationPage(new MainPage());
                //Application.Current.MainPage = new NavigationPage(new MainPage());
                //Navigation.InsertPageBefore(new MainPage(), this);
                //await Navigation.PopAsync();
                //await Navigation.PushAsync(new MainPage());
                //await App.
                //if (Device.RuntimePlatform == Device.iOS)
                //    App.MainPage = new LoginPage();
                //else
                //    MainPage = new NavigationPage(new LoginPage());
            }
            else
            {
                messageLabel.Text = "Login failed";
                passwordEntry.Text = string.Empty;
            }
        }

        bool AreCredentialsCorrect(User user)
        {
            return user.Username == Constants.Username && user.Password == Constants.Password;
        }
    }
}
