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

namespace ExpressDeal.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StatistiquesPage : ContentPage
    {
        HttpClient ws;
        
        public StatistiquesPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            ws = new HttpClient();
            var response = await ws.GetAsync(App.api_url + "/get_magasin_plus_CA");
            var content = await response.Content.ReadAsStringAsync();
            var json = JsonConvert.DeserializeObject<dynamic>(content);
            txtMagasinPlusCaId.Text = json.magasinId;
            txtMagasinPlusCa.Text = json.CA.ToString() + " €";

            ws = new HttpClient();
            response = await ws.GetAsync(App.api_url + "/get_materiel_plus_moins_empruntes");
            content = await response.Content.ReadAsStringAsync();
            json = JsonConvert.DeserializeObject<dynamic>(content);

            txtMaterielPlusEmpruntes.Text = json.materielPlusEmpruntes.nomMateriel;
            txtMaterielMoinsEmpruntes.Text = json.materielMoinsEmpruntes.nomMateriel;

            ws = new HttpClient();
            response = await ws.GetAsync(App.api_url + "/get_client_fidele");
            content = await response.Content.ReadAsStringAsync();
            Client clientFidele = JsonConvert.DeserializeObject<Client>(content);

            txtClient.Text = clientFidele.NomPrenom;
        }
    }
}