using LeSheApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LeSheApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
            this.BackgroundImageSource = ImageSource.FromFile("back.png");
        }

        private void toLogin(object sender, EventArgs e)
        {
            if (cDic.member == null)
            {
                Navigation.PushAsync(new LoginPage());
            }
            else
            {
                Navigation.PushAsync(new MemberPage());
            }
        }
    }
}