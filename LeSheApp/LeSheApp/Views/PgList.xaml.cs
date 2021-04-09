using prjCustomerSysMobile.ViewModel;
using prjLayoutDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace prjCustomerSysMobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PgList : ContentPage
    {
        CBindingViewModel bModel;
        public PgList(CBindingViewModel model)
        {
            InitializeComponent();
            bModel = model;
            cvCustomer.ItemsSource = model.all;
        }

        private void cvCustomer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CCustomer x = e.CurrentSelection.FirstOrDefault() as CCustomer;
            bModel.moveTo(x);
            Navigation.PopAsync();
        }
    }
}