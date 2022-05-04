using Project.OpenSky.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Project.OpenSky.Dal
{
    public class HTTP
    {
        public async Task<OpenSkyModel> GetAllData()
        {

            OpenSkyModel flightsData;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://opensky-network.org/");

                client.DefaultRequestHeaders.Accept.Clear();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage pespones = await client.GetAsync(@"api/states/all#");

                string lines = await pespones.Content.ReadAsStringAsync();

                flightsData = JsonSerializer.Deserialize<OpenSkyModel>(lines);

                return flightsData;

            }
        }

    }
    //readonly string dataToFile = $@"C:\Users\User\OneDrive\Moshe Yaso Work\C#Projects\Project.OpenSky\Project.OpenSky.UI\bin\Debug\{Guid.NewGuid()}-data.txt";
    /*
    public async Task<OpenSkyModel> GetAllData()
    {
        OpenSkyModel flightsData;
        using (var client = new HttpClient())
        {
            client.BaseAddress = new Uri("https://opensky-network.org/");

            client.DefaultRequestHeaders.Accept.Clear();

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage pespones = await client.GetAsync(@"api/states/all");

            string lines = await pespones.Content.ReadAsStringAsync();

            flightsData = JsonSerializer.Deserialize<OpenSkyModel>(lines);

            return flightsData;

        }

    }
     */



    /*
    public void SaveToFile(OpenSkyModel data)
    {
        string res = JsonSerializer.Serialize(data);

     //   File.WriteAllText(dataToFile, res);
    }
     */

}
