using ExpressDeal.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

// dans les autres views pas besoin de faire 
//using ExpressDeal.Views.example
//puis que on est dans le meme namespace

namespace ExpressDeal.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}