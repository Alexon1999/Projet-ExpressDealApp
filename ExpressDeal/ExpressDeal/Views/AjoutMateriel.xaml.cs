using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ExpressDeal.ClasseMetier;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ExpressDeal.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AjoutMateriel : ContentPage
    {
        HttpClient ws;
        public AjoutMateriel()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            List<Categorie> lesCategories = new List<Categorie>();

            ws = new HttpClient();
            var response = await ws.GetAsync(App.api_url + "/get_categories");
            var content = await response.Content.ReadAsStringAsync();

            lesCategories = JsonConvert.DeserializeObject<List<Categorie>>(content);

            pickerCategories.ItemsSource = lesCategories;

        }

        // ajouter Btn
        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            // TODO: Ajouter la validation
            string nomMateriel = entryNom.Text;
            string description = editorDescription.Text;
            string marque = entryMarque.Text;
            int dureeLocation = int.Parse(entryDureeLocation.Text);
            // il faut mettre virgule lors de la saisie et pas point
            double coutLocation = Convert.ToDouble(entryCoutLocation.Text);
            double coutRemplacement = Convert.ToDouble(entryCoutRemplacement.Text);
            string taille = pickerTaille.SelectedItem as string;
            int categorieId =( pickerCategories.SelectedItem as Categorie).Id;

            JObject jsec = new JObject
                        {
                            {"nom", nomMateriel },
                            {"description", description},
                            {"marque" , marque },
                            {"dureeLocation" , dureeLocation },
                            {"coutLocation" , coutLocation},
                            {"coutRemplacement" , coutRemplacement },
                            {"taille" , taille },
                            {"categorie_id" , categorieId },
                        };
            string json = JsonConvert.SerializeObject(jsec);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            ws = new HttpClient();
            await ws.PostAsync(App.api_url + "/create_materiel", content);
            
            await Navigation.PopModalAsync();
        }

        // Annuler Btn
        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

    }
}