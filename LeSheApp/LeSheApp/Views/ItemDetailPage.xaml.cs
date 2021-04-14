using LeSheApp.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace LeSheApp.Views
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