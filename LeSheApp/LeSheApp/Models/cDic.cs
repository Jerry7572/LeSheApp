using LeSheApp.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace LeSheApp.Models
{
    public class cDic
    {
        static public cMember member;
        IPHostEntry iphostentry = Dns.GetHostEntry(Dns.GetHostName());
        string memIP = "";
        public string cWeb(string email , string password)
        {
            string strHostName = Dns.GetHostName();
            IPHostEntry iphostentry = Dns.GetHostEntry(strHostName);
            //string ipaddress = iphostentry.AddressList[1].ToString() ;
            foreach (IPAddress ipaddress in iphostentry.AddressList)
            {
                // 只取得IP V4的Address
                if (ipaddress.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    memIP = ipaddress.ToString();
                }
            }
            string con = $"Login?email={ email}&password={ password}";
            string json = getJs(con);
            return json;
        }
        public string cWeb(string address, int length, int type)
        {
            string con = $"getLength?address={ address }&length={ length}&type={type}";
            string json = getJs(con);
            return json;
        }
        public string getJs(string con)
        {
           // WebRequest request = WebRequest.Create($"http://192.168.36.103:80/Xamarin/{con}");
              WebRequest request = WebRequest.Create($"https://192.168.36.187:81/Xamarin/{con}");
            request.Credentials = CredentialCache.DefaultCredentials;
            ServicePointManager.ServerCertificateValidationCallback += (o, certificate, chain, errors) => true;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Console.WriteLine(response.StatusDescription);
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string json = reader.ReadToEnd();
            reader.Close();
            dataStream.Close();
            response.Close();
            return json;
        }
    }
}
