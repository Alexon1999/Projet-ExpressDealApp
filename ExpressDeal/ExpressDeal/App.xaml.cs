using ExpressDeal.Services;
using ExpressDeal.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ExpressDeal.ClasseMetier;
using Xamarin.Essentials;

namespace ExpressDeal
{
    public partial class App : Application
    {
        public static UserConnexion user;

        // 10.0.2.2 pour les emulateurs android http://10.0.2.2:3000 
        public static string api_url = "https://474aa4ec5785.ngrok.io";

        public App()
        {
            InitializeComponent();

            // DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
            // user = null;
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
