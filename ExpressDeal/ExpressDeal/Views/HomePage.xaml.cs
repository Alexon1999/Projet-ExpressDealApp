using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExpressDeal.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
        }

        // Inventaire
        private async void Button_Clicked(object sender, EventArgs e)
        {
            //Toast.MakeText(Android.App.Application.Context, App.user.nom, ToastLength.Short).Show();
            InventairePage page = new InventairePage();
            await Navigation.PushModalAsync(new NavigationPage(page));
        }

        // Locations
        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            LocationsPage page = new LocationsPage();
            await Navigation.PushModalAsync(new NavigationPage(page));
        }

        // Informations

        private void Button_Clicked_2(object sender, EventArgs e)
        {

        }
    }
}