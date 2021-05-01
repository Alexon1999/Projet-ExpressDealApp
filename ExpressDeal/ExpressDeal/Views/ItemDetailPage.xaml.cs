using ExpressDeal.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

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