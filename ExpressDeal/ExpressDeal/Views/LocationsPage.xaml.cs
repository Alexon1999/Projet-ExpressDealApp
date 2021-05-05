using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ExpressDeal.ClasseMetier;
using Newtonsoft.Json;

namespace ExpressDeal.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LocationsPage : ContentPage
    {
        HttpClient ws;
        public LocationsPage()
        {
            InitializeComponent();
        }


        protected override async void OnAppearing()
        {
            base.OnAppearing();

            List<Location> lesLocations = new List<Location>();

            ws = new HttpClient();
            var response = await ws.GetAsync(App.api_url + "/get_locations/" + App.user.magasinId);
            var content = await response.Content.ReadAsStringAsync();

            lesLocations = JsonConvert.DeserializeObject<List<Location>>(content);

            lvLocations.ItemsSource = lesLocations;
        }

        // les location non rendus
        private async void Button_Clicked(object sender, EventArgs e)
        {
            LocationNonRendus page = new LocationNonRendus();
            await Navigation.PushModalAsync(new NavigationPage(page));
        }

        // ajouter une location
        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            AjoutLocation page = new AjoutLocation();
            await Navigation.PushModalAsync(new NavigationPage(page));
        }
    }
}