using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppNBRB.Service
{
    public class ApiCaller
    {
        public static async Task<string> Get(string url)
        {
            using (var client = new HttpClient())
            {        

                var request = await client.GetAsync(url);

                if (request.IsSuccessStatusCode)
                    return await request.Content.ReadAsStringAsync();
                else
                {
                    var errorMessage = $"Request failed with status code {(int)request.StatusCode} ({request.ReasonPhrase})";
                    throw new HttpRequestException(errorMessage);
                }
            }
        }

        public static async Task<string> Post<T>(string url, T model)
        {
            using (var client = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(model);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var request = await client.PostAsync(url, content);

                if (request.IsSuccessStatusCode)
                    return await request.Content.ReadAsStringAsync();
                else
                {
                    var errorMessage = $"Request failed with status code {(int)request.StatusCode} ({request.ReasonPhrase})";
                    throw new HttpRequestException(errorMessage);
                }

            }
        }
    }
}
