using ExpressDeal.ViewModels;
using ExpressDeal.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace ExpressDeal
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            // enregistrer les routes qu'on veut utiliser
            Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            Routing.RegisterRoute(nameof(MaterielDetailPage), typeof(MaterielDetailPage));
            //Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            App.user = null;
            // replace the navigation stack
            await Shell.Current.GoToAsync("//login");
        }
    }
}
