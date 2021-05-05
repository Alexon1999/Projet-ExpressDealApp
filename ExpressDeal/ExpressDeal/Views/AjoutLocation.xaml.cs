using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;
using System.Net.Http;
using ExpressDeal.ClasseMetier;
using Newtonsoft.Json.Linq;
using Android.Widget;

namespace ExpressDeal.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AjoutLocation : ContentPage
    {
        HttpClient ws;
        public AjoutLocation()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            List<InventaireDispo> lesMaterielsDispoInventaire = new List<InventaireDispo>();
            List<Client> lesClientsDuMagasin = new List<Client>();

            ws = new HttpClient();
            var response_1 = await ws.GetAsync(App.api_url + "/get_materiels_dispo/" + App.user.magasinId);
            var content_1 = await response_1.Content.ReadAsStringAsync();
            lesMaterielsDispoInventaire = JsonConvert.DeserializeObject<List<InventaireDispo>>(content_1);
            pickerInventaire.ItemsSource = lesMaterielsDispoInventaire;

            ws = new HttpClient();
            var response_2 = await ws.GetAsync(App.api_url + "/get_clients/" + App.user.magasinId);
            var content_2 = await response_2.Content.ReadAsStringAsync();
            lesClientsDuMagasin = JsonConvert.DeserializeObject<List<Client>>(content_2);
            pickerClient.ItemsSource = lesClientsDuMagasin;

            
        }

        // ajouter btn
        private async void Button_Clicked(object sender, EventArgs e)
        {
            if(pickerClient.SelectedItem != null && pickerInventaire.SelectedItem != null)
            {
                JObject jsec = new JObject
                        {
                            {"inventaireId", (pickerInventaire.SelectedItem as InventaireDispo).IdInventaire },
                            {"clientId", (pickerClient.SelectedItem as Client).IdClient},
                            {"employeId" , App.user.id },

                        };
                string json = JsonConvert.SerializeObject(jsec);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                ws = new HttpClient();
                await ws.PostAsync(App.api_url + "/create_location", content);


                await Navigation.PopModalAsync();
            }
            else
            {
                Toast.MakeText(Android.App.Application.Context, "selectionnez les informations", ToastLength.Short).Show();
            }
        }

        // annuler btn
        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}