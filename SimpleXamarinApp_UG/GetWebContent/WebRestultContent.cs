using Newtonsoft.Json;
using SimpleXamarinApp_UG.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SimpleXamarinApp_UG.GetWebContent
{
    public class WebRestultContent
    {
        public async Task<List<Opis>> ReadSwienteOpisy()
        {
            var opisy = new List<Opis>();
            var client = new HttpClient();
            var result = await client.GetStringAsync(@"https://superapi20200603113044.azurewebsites.net/donkey");
            client.Dispose();
            var tablicka = result.Split(new string[] { "###" }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < tablicka.Length; i++)
            {
                var n = tablicka[i];
                i++;
                var t = tablicka.Length > i? tablicka[i] : "Brak tresci";
                opisy.Add(new Opis() { Name = n, Tresc = t });
            }
            return opisy;
        }

        public async void DodawanieOpisiku(Opis opis)
        {
            var client = new HttpClient();
            var jsonOpisik = JsonConvert.SerializeObject(opis);
            var nsc = new StringContent(jsonOpisik, Encoding.UTF8, "application/json");
            await client.PostAsync(@"https://superapi20200603113044.azurewebsites.net/donkey", nsc);
        }
    }
}
