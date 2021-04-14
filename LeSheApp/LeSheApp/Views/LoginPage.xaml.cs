﻿using LeSheApp.Models;
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
        private async void btnDetail_click(object sender, EventArgs e)
        {
           string email= Email.Text;
            string password = Password.Text;
            WebRequest request = WebRequest.Create($"http://192.168.36.187:81/Xamarin/Login?email={email}&password={password}");
            request.Credentials = CredentialCache.DefaultCredentials;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Console.WriteLine(response.StatusDescription);
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string json = reader.ReadToEnd();
            reader.Close();
            dataStream.Close();
            response.Close();

            var back = JsonConvert.DeserializeObject(json);
            if (!back.ToString().Contains("Fail"))
            {
                cMember member = JsonConvert.DeserializeObject<cMember>(json);
                Application.Current.Properties[new cDic().memberId] = member.MemberId;
                await Navigation.PushAsync(new ItemsPage());
            }
            else
                Error.Text = "查無此帳";

        }
    }
}