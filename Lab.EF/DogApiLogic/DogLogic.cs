using Lab.EF.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DogApiLogic
{
    public class DogLogic
    {
        string link = "https://dog.ceo/api/breeds/image/random";
        public async Task<Dog> GetDogs()
        {
            var client = new HttpClient();
            var json = await client.GetStringAsync(link);
            dynamic dogs = JsonConvert.DeserializeObject<Dog>(json);
            return dogs;
        }
    }
}
