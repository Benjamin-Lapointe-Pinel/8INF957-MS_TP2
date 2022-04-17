using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;
using TP01_HeartDiseaseDiagnostic;
using TP1_app_BLP.Models;

namespace TP1_app_BLP.Services
{
    public class RestApiClient
    {
        private HttpClient client;

        public RestApiClient()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5000/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public Doctor? Login(AuthenticationRequest authenticationRequest)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(authenticationRequest), Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync("login", content).Result;
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            string data = response.Content.ReadAsStringAsync().Result;
            string encodedToken = JsonConvert.DeserializeObject<string>(data);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", encodedToken);

            return GetDoctor();
        }

        public Doctor? GetDoctor()
        {
            HttpResponseMessage response = client.GetAsync("info").Result;
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            string data = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<Doctor>(data);
        }
    }
}
