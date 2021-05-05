using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ExpressDeal.ClasseMetier;
using Newtonsoft.Json;
using System.Net.Http;

namespace ExpressDeal.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LocationNonRendus : ContentPage
    {

        HttpClient ws;
        public LocationNonRendus()
        {
            InitializeComponent();
        }


        protected override async void OnAppearing()
        {
            base.OnAppearing();

            List<Location> lesLocations = new List<Location>();

            ws = new HttpClient();
            var response = await ws.GetAsync(App.api_url + "/get_locations_non_rendus/" + App.user.magasinId);
            var content = await response.Content.ReadAsStringAsync();

            lesLocations = JsonConvert.DeserializeObject<List<Location>>(content);

            lvLocationsNonRendus.ItemsSource = lesLocations;
        }
    }
}