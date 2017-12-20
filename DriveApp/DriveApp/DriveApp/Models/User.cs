using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Android.Net;
using Xamarin.Forms;
namespace DriveApp.Models
{
    public class UserFuck
    {
        //public int Id { get; set; }
        //public string Username { get; set; }
        //public string Password { get; set; }
        public List<rit> Ritten { get; set; }
        public string ID { get; set; }


        public async Task<bool> CheckLogin(string name, string pass)             // 1
        {
            string baseUrl = "https://www.snellewiel.nu";
            Uri httprequest = new Uri(baseUrl);          // 2
            FormUrlEncodedContent content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string,string>("action","loginDriver"),
                new KeyValuePair<string,string>("name",name),
                new KeyValuePair<string,string>("password",pass),
                new KeyValuePair<string,string>("key","xHFWLJ2p69wt2lFt1udPnapctm8sBT1K")
            });

            //Let op, bij de httprequest doet die automatisch een / achter de basestring
            HttpClient client = new HttpClient();
            client = GetCorrectClient(client);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.BaseAddress = httprequest;

            HttpResponseMessage respons = client.PostAsync("api/getfunctions.php?", content).Result;
            respons.EnsureSuccessStatusCode();
            //{"result":true,"name":"Mees von den Hoff"}
            string s = await respons.Content.ReadAsStringAsync();
            JObject Contentresult = JObject.Parse(s);

            ID = (string)Contentresult["id"];
            Ritten = await GetData();
            return (bool)Contentresult["result"];
        }


        public async Task<List<rit>> GetData()
        {
            string baseUrl = "https://www.snellewiel.nu";
            Uri httprequest = new Uri(baseUrl);          // 2
            FormUrlEncodedContent content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string,string>("action", "getTasks"),
                new KeyValuePair<string,string>("ID", ID),
                new KeyValuePair<string,string>("key", "xHFWLJ2p69wt2lFt1udPnapctm8sBT1K")
            });

            //Let op, bij de httprequest doet die automatisch een / achter de basestring
            HttpClient client = new HttpClient();
            client = GetCorrectClient(client);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.BaseAddress = httprequest;

            HttpResponseMessage respons = client.PostAsync("api/getfunctions.php?", content).Result;
            respons.EnsureSuccessStatusCode();

            string s = await respons.Content.ReadAsStringAsync();
            return DeserializeToObject<Rootobject>(s).ritten;
        }

        private static HttpClient GetCorrectClient(HttpClient client)
        {
            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    client = new HttpClient();
                    break;
                case Device.Android:
                    client = new HttpClient(new AndroidClientHandler());
                    break;
                case Device.WinPhone:
                    client = new HttpClient();
                    break;
            }

            return client;
        }

        private T DeserializeToObject<T>(string jsontodeserialize)
        {
            return JsonConvert.DeserializeObject<T>(jsontodeserialize);
        }

        public class Rootobject
        {
            public List<rit> ritten { get; set; }
        }

        public class rit
        {
            public string roID { get; set; }
            public string Status { get; set; }
            public string Type { get; set; }
            public string Volgorde { get; set; }
            public string Aantal { get; set; }
            public string Voltooid { get; set; }
            public string AdresNaam { get; set; }
            public string AdresStraat { get; set; }
            public string AdresHuisnummer { get; set; }
            public string AdresPlaats { get; set; }
            public string AdresPostcode { get; set; }
        }




    }


}
