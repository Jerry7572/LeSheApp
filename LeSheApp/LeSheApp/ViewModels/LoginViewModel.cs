using LeSheApp.Models;
using LeSheApp.Views;
using Newtonsoft.Json;
using prjCustomerSysMobile;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace LeSheApp.ViewModels
{
    public class LoginViewModel : ContentPage, INotifyPropertyChanged
    {
        public Command LoginCommand { get; }

        public LoginViewModel()
        {
            //LoginCommand = new Command(OnLoginClicked);
            //    SubmitCommand = new Command(OnSubmit);
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        //private async void OnLoginClicked(object obj)
        //{
        //    // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
        //    await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
        //    string btn = obj.ToString();
        //}
        public Action DisplayFail;
        public Action DisplaySuccess;
        private string email;
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Email"));
            }
        }
        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Password"));
            }
        }
        public ICommand SubmitCommand { protected set; get; }
        private async void OnSubmit(object sender, EventArgs e)
        {
            //WebRequest request = WebRequest.Create($"http://192.168.36.187:81/Xamarin/Login?email={Email}&password={Password}");
            //request.Credentials = CredentialCache.DefaultCredentials;
            //HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            //Console.WriteLine(response.StatusDescription);
            //Stream dataStream = response.GetResponseStream();
            //StreamReader reader = new StreamReader(dataStream);
            //string json = reader.ReadToEnd();
            //reader.Close();
            //dataStream.Close();
            //response.Close();

            //var back = JsonConvert.DeserializeObject(json);
            //if (!back.ToString().Contains("Fail"))
            //{
            //    cMember member = JsonConvert.DeserializeObject<cMember>(json);
            //    Application.Current.Properties[new cDic().memberId] = member.MemberId;
            //    //DisplaySuccess();
            //   // await Navigation.PopAsync();
            //    await Navigation.PushAsync(new ItemsPage());
            //}
            //else
            //    DisplayFail();
            await Navigation.PushAsync(new ItemsPage());
        }
        //private async void btnDetail_click(object sender, EventArgs e)
        //{
        //    await Navigation.PushAsync(new ItemsPage());
        //}
    }
}
