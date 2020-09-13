using System.ComponentModel;
using Xamarin.Forms;
using FSO.App.ViewModels;

namespace FSO.App.Views
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