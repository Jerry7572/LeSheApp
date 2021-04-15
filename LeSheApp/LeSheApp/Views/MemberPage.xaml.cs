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
    public partial class MemberPage : ContentPage
    {
        cMember member;
        public MemberPage()
        {
            InitializeComponent();
            this.BackgroundImageSource = ImageSource.FromFile("back.png");
            member = cDic.member;
            labName.Text = member.FirstName + member.LastName;
            labAddress.Text = member.Address;
            labEmail.Text = member.Email;
            labBirth.Text = member.DateOfBirth.Year + "年" + member.DateOfBirth.Month + "月" + member.DateOfBirth.Day + "日";
            labBalance.Text = member.Balance.ToString();

        }

        private void toSearch(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SearchPage());
        }

        private void toBuy(object sender, EventArgs e)
        {
            Navigation.PushAsync(new buySearchPage());
        }
    }
}