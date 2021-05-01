using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExpressDeal.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NouveauMaterielDansInventaire : ContentPage
    {
        List<string> lesMateriels;
        public NouveauMaterielDansInventaire()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            lesMateriels = new List<string>();
            lesMateriels.Add("test");


            pickerMateriels.ItemsSource = lesMateriels;
        }
    
    }
}