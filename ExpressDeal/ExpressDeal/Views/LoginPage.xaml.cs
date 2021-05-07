using Android.Widget;
using ExpressDeal.ViewModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ExpressDeal.ClasseMetier;
using System.Diagnostics;

namespace ExpressDeal.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        HttpClient ws;

        public LoginPage()
        {
            InitializeComponent();
            // this.BindingContext = new LoginViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            mdp.Text = "";
            login.Text = "";

        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if ((login.Text == null &&  mdp.Text == null) || (login.Text == "" && mdp.Text == ""))
            {
                Toast.MakeText(Android.App.Application.Context, "Veuillez saisir un login et un mot de passe", ToastLength.Short).Show();
            }
            else
            {
                if ((login.Text == null || mdp.Text == null) || (login.Text == "" || mdp.Text == ""))
                {
                    if (login.Text == null || login.Text == "")
                    {
                        Toast.MakeText(Android.App.Application.Context, "Veuillez saisir un login", ToastLength.Short).Show();
                    }
                    if (mdp.Text == null || mdp.Text == "")
                    {
                        Toast.MakeText(Android.App.Application.Context, "Veuillez saisir un mot de passe", ToastLength.Short).Show();
                    }
                }
                else
                {
                    //requete http POST
                    ws = new HttpClient();
                    
                    JObject jsec = new JObject
                    {
                        {"login",login.Text},
                        {"mdp",mdp.Text}
                    };
                    string json = JsonConvert.SerializeObject(jsec);
                    StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                    HttpResponseMessage reponse = await ws.PostAsync(App.api_url + "/login", content);
                    var flux = await reponse.Content.ReadAsStringAsync();
                    UserConnexion data = JsonConvert.DeserializeObject<UserConnexion>(flux);
                    
                    if (reponse.IsSuccessStatusCode)
                    {
                        App.user = data;
                        // Debug.WriteLine(App.user.autoriser);
                        // Toast.MakeText(Android.App.Application.Context, "autoriser : " + data.autoriser.ToString(), ToastLength.Short).Show();
                        // $" {} " : template litteral
                        // replaces the navigation stack : // 

                        mdp.Text = "";
                        login.Text = "";

                        await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
                    }
                    else
                    {
                        Toast.MakeText(Android.App.Application.Context,  data.error, ToastLength.Short).Show();
                    }
                    
                    
                }
            }

        }
    }
}