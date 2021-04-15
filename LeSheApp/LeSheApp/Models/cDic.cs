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
        public string cWeb(string email , string password)
        {
            string con = $"Login?email={ email}&password={ password}";
            string json = getJs(con);
            return json;
        }
        public string cWeb(string address, int length)
        {
            string con = $"getLength?address={ address }&length={ length}";
            string json = getJs(con);
            return json;
        }
        public string getJs(string con)
        {
            WebRequest request = WebRequest.Create($"http://192.168.36.103:80/Xamarin/{con}");
            request.Credentials = CredentialCache.DefaultCredentials;
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
