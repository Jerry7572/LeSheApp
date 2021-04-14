using LeSheApp.Models;
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
    public partial class SearchPage : ContentPage
    {
        public SearchPage()
        {
            InitializeComponent();
        }

        private void selectedCity(object sender, EventArgs e)
        {
            Dis.Items.Clear();
            if(City.SelectedIndex == 0)
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
            }else if(City.SelectedIndex == 1)
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

        private void sendAddress(object sender, EventArgs e)
        {
            string totalAddress = City.SelectedItem.ToString() + Dis.SelectedItem.ToString() + Address.Text;
            string maxLength = length.SelectedItem.ToString().Substring(0,3);
            WebRequest request = WebRequest.Create($"http://192.168.36.103:80/Xamarin/GetLength?address={totalAddress}&length={maxLength}");
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
                List<cSpot> list = JsonConvert.DeserializeObject<List<cSpot>>(json);
                for(int i = 0; i < list.Count; i++)
                {
                }

            }
            else
                Error.Text = "查無結果";


        }
    }
}