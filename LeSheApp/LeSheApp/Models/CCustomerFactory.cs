using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace prjLayoutDemo.Models
{
    public class CCustomerFactory
    {
        private SQLiteAsyncConnection con;

        private SQLiteAsyncConnection getSQLite()
        {
            if (con == null)
            {
                con = new SQLiteAsyncConnection(Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                    "dbDemo.db"));
            }
            return con;
        }

        public CCustomerFactory()
        {
            getSQLite().CreateTableAsync<CCustomer>();
        }

        public List<CCustomer> getAll()
        {
            //List<CCustomer> list = new List<CCustomer>();
            ////list.Add(new CCustomer { fAddrsss = "台北市", fEmail = "marco@gmail.com", fId = 1, fName = "Marco", fPhone = "0921332145" });
            ////list.Add(new CCustomer { fAddrsss = "台中市", fEmail = "jenny@gmail.com", fId = 2, fName = "Jenny", fPhone = "0937458745" });
            ////list.Add(new CCustomer { fAddrsss = "台南市", fEmail = "din_yu.wang@gmail.com", fId = 4, fName = "Din Yu Wang", fPhone = "0922118000" });


            //foreach (CCustomer c in getSQLite().Table<CCustomer>)
            //{
            //    list.Add(c);                
            //}
            WebRequest request = WebRequest.Create("https://customerdemofor129withxamarin.azurewebsites.net/api/CCustomerService");
           // request.ServerCertificateCustomValidationCallback = delegate { return true; }
            request.Credentials = CredentialCache.DefaultCredentials;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Console.WriteLine(response.StatusDescription);
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string json = reader.ReadToEnd();
            reader.Close();
            dataStream.Close();
            response.Close();

            List<CCustomer> customersFromCloud = JsonConvert.DeserializeObject<List<CCustomer>>(json);
            return customersFromCloud;//getSQLite().Table<CCustomer>().ToListAsync().Result;
        }
    }
}
