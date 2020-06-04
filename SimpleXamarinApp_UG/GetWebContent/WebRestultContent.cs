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
            opisy.Add(new Opis() { Name = tablicka[0], Tresc = tablicka[1] });
            opisy.Add(new Opis() { Name = tablicka[2], Tresc = tablicka[3] });
            opisy.Add(new Opis() { Name = tablicka[4], Tresc = tablicka[5] });
            opisy.Add(new Opis() { Name = tablicka[6], Tresc = tablicka[7] });
            return opisy;
        }
    }
}
