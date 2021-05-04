using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Microsoft.CSharp;
using System.Windows;
using Android.Widget;
using Newtonsoft.Json.Linq;

namespace ExpressDeal.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NouveauMaterielDansInventaire : ContentPage
    {
        List<string> lesMateriels;
        HttpClient ws;
        public NouveauMaterielDansInventaire()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            lesMateriels = new List<string>();



            //ws = new HttpClient(); // ws : webservice
            //var response = await ws.GetAsync(App.api_url + "/get_nom_materiels");
            //var content = await response.Content.ReadAsStringAsync();
            //// quand je retoune un json avec la propriete materiels
            //var json = JsonConvert.DeserializeObject<dynamic>(content);
            //foreach (string s in json.materiels)
            //{
            //    lesMateriels.Add(s);
            //};

            ws = new HttpClient();
            var response = await ws.GetAsync(App.api_url + "/get_nom_materiels");
            var content = await response.Content.ReadAsStringAsync();
            lesMateriels = JsonConvert.DeserializeObject<List<string>>(content);
            pickerMateriels.ItemsSource = lesMateriels;
        }

        // button enregistrer
        private async void Button_Clicked(object sender, EventArgs e)
        {
            if(pickerMateriels.SelectedItem != null && quantite.Text != "" && quantite.Text != null)
            {

                JObject jsec = new JObject
                        {
                            {"materiel", pickerMateriels.SelectedItem as string },
                            {"quantite", int.Parse(quantite.Text)},
                            {"magasin_id" , App.user.magasinId },
                        };

                string json = JsonConvert.SerializeObject(jsec);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                ws = new HttpClient();
                await ws.PostAsync(App.api_url + "/create_materiels_inventaire" , content);

                await Navigation.PopModalAsync();
            }
        }

        // button annuler
        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}