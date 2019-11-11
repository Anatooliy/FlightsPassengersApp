using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace FPApp.Client.Helpers
{
    public class HttpClientHelper
    {
        public static HttpClient GetHttpClient()
        {
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri("http://localhost:59318/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            return client;
        }
    }
}