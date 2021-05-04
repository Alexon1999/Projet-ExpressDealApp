﻿using ExpressDeal.Services;
using ExpressDeal.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ExpressDeal.ClasseMetier;
namespace ExpressDeal
{
    public partial class App : Application
    {
        public static UserConnexion user;
        public static string api_url = "https://3e44009155db.ngrok.io";
        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
            user = null;
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
