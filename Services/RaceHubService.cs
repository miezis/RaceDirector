using System;
using System.Diagnostics;
using System.Net;
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
        private static readonly string Endpoint = "http://manmie.stud.if.ktu.lt/api/races/updates";

        public static async void SendData(Race data)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, Endpoint);
                requestMessage.Headers.Add("X-AUTH-TOKEN", data.apiKey);
                var serializedData = JsonConvert.SerializeObject(data);
                requestMessage.Content = new StringContent(serializedData, Encoding.UTF8, "application/json");

                await client.SendAsync(requestMessage);
            }
        }
    }
}