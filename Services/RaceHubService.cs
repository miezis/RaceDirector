using System;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using Newtonsoft.Json;
using RaceDirector.DTO;

namespace RaceDirector.Services
{
    public class RaceHubService
    {
        private static readonly string Endpoint = "http://127.0.0.1:8000/api/races/updates";

        public static async void SendData(Race data)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, Endpoint);
                requestMessage.Headers.Add("X-AUTH-TOKEN", data.apiKey);
                requestMessage.Content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");

                await client.SendAsync(requestMessage);
            }
        }
        //use HttpClient class 
    }
}