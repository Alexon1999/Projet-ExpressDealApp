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
    public partial class InventairePage : ContentPage
    {
        HttpClient ws;

        public InventairePage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // BinddingContext : au lieu de prendre à chaque fois le controleur et mettre le texte ou itemsource
            //BindingContext = un objet ( interface va utiliser les proprietes de cet objet)
            BindingContext = this; // le contexte sera cet objet elle meme 

            List<Inventaire> lesInventaires = new List<Inventaire>();

            ws = new HttpClient();
            var reponse = await ws.GetAsync(App.api_url + "/inventaire_magasin/" + App.user.magasinId);
            var content = await reponse.Content.ReadAsStringAsync();
            lesInventaires = JsonConvert.DeserializeObject<List<Inventaire>>(content);
            lvInventaire.ItemsSource = lesInventaires;
        }

        // detail de materiel selectionné
        private async void lvInventaire_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if(lvInventaire.SelectedItem != null)
            {
                Inventaire inv = (lvInventaire.SelectedItem as Inventaire);
                // This will push the MaterielDetailPage onto the navigation stack
                // await Shell.Current.GoToAsync($"{nameof(MaterielDetailPage)}?id={inv.id}");

                MaterielDetailPage page = new MaterielDetailPage(inv.idMateriel);
                await Navigation.PushModalAsync(new NavigationPage(page));
            }
        }

        // créer un nouveau materiel existant dans inventaire
        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            NouveauMaterielDansInventaire page = new NouveauMaterielDansInventaire();
            await Navigation.PushModalAsync(new NavigationPage(page)); // ajoute page sous forme modal, on peut revenir avec PopModalAsync
            // Navigation.PushAsync  ajoute une page mais pour revenir PopAsync ne marche pas
        }

        // créer un nouveau matériel
        private async void Button_Clicked(object sender, EventArgs e)
        {
            AjoutMateriel am = new AjoutMateriel();
            await Navigation.PushModalAsync(new NavigationPage(am));

        }
    }
}