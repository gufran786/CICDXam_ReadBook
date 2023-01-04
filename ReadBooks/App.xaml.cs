using System;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ReadBooks
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        protected override async void OnStart()
        {
            // Handle when your app starts
            AppCenter.Start("ios=14c9c873-e50b-4313-8aaa-c7922364d610;" +
                            "android=4cbe7d61-c674-400c-9c6e-c0a65f68cc28",
                            typeof(Analytics), typeof(Crashes));

            bool didAppCrash = await Crashes.HasCrashedInLastSessionAsync();
            if (didAppCrash)
                await MainPage.DisplayAlert("I'm Sorry", "It appears we had some issue there, Sorry about that", "Dont Worry");
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
