using LeSheApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LeSheApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class buySearchPage : ContentPage
    {
        cMember member;
        public buySearchPage()
        {
            InitializeComponent();
            member = cDic.member;
            if (member.DistrictId < 13)
            {
                City.SelectedIndex = 0;
                Dis.SelectedIndex = member.DistrictId;
            }
            else
            {
                City.SelectedIndex = 1;
                Dis.SelectedIndex = member.DistrictId - 13;
            }
            Address.Text = member.Address;
            length.SelectedIndex = 0;
            this.BackgroundImageSource = ImageSource.FromFile("trash.jpg");

        }

        private void sendBuy(object sender, EventArgs e)
        {
            if (City.SelectedIndex < 0 || Dis.SelectedIndex < 0 || length.SelectedIndex < 0)
            {
                Error.Text = "請選擇";
                return;
            }
            string totalAddress = City.SelectedItem.ToString() + Dis.SelectedItem.ToString() + Address.Text;
            int maxLength;
            if(length.SelectedIndex >= 1)
            {
                maxLength = Convert.ToInt32(length.SelectedItem.ToString().Substring(0, 4));
            }
            else
            {
                maxLength = Convert.ToInt32(length.SelectedItem.ToString().Substring(0, 3));
            }
            cDic cDic = new cDic();
            var json = cDic.cWeb(totalAddress, maxLength,1);
            var back = JsonConvert.DeserializeObject(json);
            List<cOrder> list = JsonConvert.DeserializeObject<List<cOrder>>(json);
            if (list.Count>0)
            {
                this.BackgroundImageSource = "";
                listBuy.Children.Clear();
                Label laC = new Label();
                laC.Text = "總共" + list.Count + "筆";
                laC.TextColor = Color.BlueViolet;
                laC.FontSize = 18;
                Error.Text = "";
                listBuy.Children.Add(laC);
                int count = 0;
                foreach (var item in list)
                {
                    count++;
                    Label laCount = new Label();
                    Label la = new Label();
                    Label la2 = new Label();
                    #region hyperlink
                    Label hyper = new Label();
                    string link = "http://maps.google.com/?q=" + item.Address;
                    var tapGestureRecognizer = new TapGestureRecognizer();
                    tapGestureRecognizer.Tapped += async (s, even) => {
                        // Depreciated - Device.OpenUri( new Uri((Label)s).Text); 
                        // await Launcher.OpenAsync(new Uri(((Label)s).Text));
                        await Launcher.OpenAsync(new Uri(link));
                    };
                    la.GestureRecognizers.Add(tapGestureRecognizer);
                    #endregion
                    laCount.FontSize = 18;
                    laCount.TextColor = Color.BlueViolet;
                    la.FontSize = 20;
                    la2.FontSize = 15;
                    laCount.Text = "第" + count + "筆";
                    la.Text = "地點:" + item.Address;
                    la2.Text += "終止時間: " + item.EndTime + "\n商品描述:" + item.OrderDescription + "\n價錢:" + item.UnitPrice;
                    listBuy.Children.Add(laCount);
                    listBuy.Children.Add(la);
                    listBuy.Children.Add(la2);
                }
            }
            else
                Error.Text = "查無結果";

        }

        private void selectedCity(object sender, EventArgs e)
        {
            Dis.Items.Clear();
            if (City.SelectedIndex == 0)
            {
                Dis.Items.Add("中正區");
                Dis.Items.Add("大同區");
                Dis.Items.Add("中山區");
                Dis.Items.Add("松山區");
                Dis.Items.Add("大安區");
                Dis.Items.Add("萬華區");
                Dis.Items.Add("信義區");
                Dis.Items.Add("士林區");
                Dis.Items.Add("北投區");
                Dis.Items.Add("內湖區");
                Dis.Items.Add("南港區");
                Dis.Items.Add("文山區");
            }
            else if (City.SelectedIndex == 1)
            {
                Dis.Items.Add("板橋區");
                Dis.Items.Add("三重區");
                Dis.Items.Add("中和區");
                Dis.Items.Add("永和區");
                Dis.Items.Add("新莊區");
                Dis.Items.Add("新店區");
                Dis.Items.Add("土城區");
                Dis.Items.Add("蘆洲區");
                Dis.Items.Add("樹林區");
                Dis.Items.Add("汐止區");
                Dis.Items.Add("鶯歌區");
                Dis.Items.Add("三峽區");
                Dis.Items.Add("淡水區");
                Dis.Items.Add("瑞芳區");
                Dis.Items.Add("五股區");
                Dis.Items.Add("泰山區");
                Dis.Items.Add("林口區");
                Dis.Items.Add("深坑區");
                Dis.Items.Add("石碇區");
                Dis.Items.Add("坪林區");
                Dis.Items.Add("三芝區");
                Dis.Items.Add("石門區");
                Dis.Items.Add("八里區");
                Dis.Items.Add("平溪區");
                Dis.Items.Add("雙溪區");
                Dis.Items.Add("貢寮區");
                Dis.Items.Add("金山區");
                Dis.Items.Add("萬里區");
                Dis.Items.Add("烏來區");
            }


        }
    }
}