using Android.Widget;
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
    [QueryProperty(nameof(id), nameof(id))]
    public partial class MaterielDetailPage : ContentPage
    {
        HttpClient ws;
        public string id { get; set; }
        public MaterielDetailPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing() {
            // Toast.MakeText(Android.App.Application.Context, id, ToastLength.Short).Show();

            // requete http 
            ws = new HttpClient();
            var reponse = await ws.GetAsync(App.api_url + "/materiel/" + id);
            var content = await reponse.Content.ReadAsStringAsync();
            Materiel selected_materiel = JsonConvert.DeserializeObject<Materiel>(content);

            // BinddingContext : au lieu de prendre à chaque fois le controleur et mettre le texte ou itemsource
            //BindingContext = un objet ( interface va utiliser les proprietes de cet objet)

            BindingContext = selected_materiel;
        }

       
    }
}