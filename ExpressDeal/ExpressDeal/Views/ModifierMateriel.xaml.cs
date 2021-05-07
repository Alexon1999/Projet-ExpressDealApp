using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ExpressDeal.ClasseMetier;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExpressDeal.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ModifierMateriel : ContentPage
    {
        HttpClient ws;
        Materiel selectedMateriel;
        public ModifierMateriel(Materiel unMateriel)
        {
            InitializeComponent();
            selectedMateriel = unMateriel;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            entryNom.Text = selectedMateriel.nom;
            entryMarque.Text = selectedMateriel.marque;
            entryCoutLocation.Text = selectedMateriel.coutLocation.ToString();
            entryCoutRemplacement.Text = selectedMateriel.coutRemplacement.ToString();
            entryDureeLocation.Text = selectedMateriel.dureeLocation.ToString();
            editorDescription.Text = selectedMateriel.description;


            List<Categorie> lesCategories = new List<Categorie>();

            ws = new HttpClient();
            var response = await ws.GetAsync(App.api_url + "/get_categories");
            var content = await response.Content.ReadAsStringAsync();

            lesCategories = JsonConvert.DeserializeObject<List<Categorie>>(content);

            pickerCategories.ItemsSource = lesCategories;

            int nb = 0;
            foreach(Categorie c in pickerCategories.ItemsSource)
            {
                if(c.Nom == selectedMateriel.categorie.Nom)
                {
                    pickerCategories.SelectedIndex = nb;
                    break;
                }
                nb++;
            }
            BindingContext = selectedMateriel;
            
        }

        // modifier btn
        private async  void Button_Clicked_1(object sender, EventArgs e)
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
            int categorieId = (pickerCategories.SelectedItem as Categorie).Id;

            JObject jsec = new JObject
                        {
                            {"idMateriel", selectedMateriel.materielId },
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
            await ws.PostAsync(App.api_url + "/update_materiel" , content);
            await Navigation.PopModalAsync();
        }

        // annuler btn
        private async void Button_Clicked_2(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}