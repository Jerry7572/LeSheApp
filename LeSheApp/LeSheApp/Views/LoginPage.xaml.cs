using LeSheApp.Models;
using LeSheApp.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace LeSheApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            var vm = new LoginViewModel();
            this.BindingContext = vm;
            vm.DisplayFail += () => DisplayAlert("Error", "Invalid Login, try again", "OK");
            vm.DisplaySuccess += () => DisplayAlert("Success", "Success", "OK");
            InitializeComponent();

            Email.Completed += (object sender, EventArgs e) =>
            {
                Password.Focus();
            };

            Password.Completed += (object sender, EventArgs e) =>
            {
                vm.SubmitCommand.Execute(null);
            };
        }
        public Action DisplayFail;
        public Action DisplaySuccess;
        private void btnDetail_click(object sender, EventArgs e)
        {
            string email= Email.Text;
            string password = Password.Text;
            var json = new cDic().cWeb(email, password);
            var back = JsonConvert.DeserializeObject(json);
            if (!back.ToString().Contains("Fail"))
            {
                cMember member = JsonConvert.DeserializeObject<cMember>(json);
                cDic.member = member;
                Navigation.PushAsync(new SearchPage());
            }
            else
                Error.Text = "查無此帳";

        }
    }
}