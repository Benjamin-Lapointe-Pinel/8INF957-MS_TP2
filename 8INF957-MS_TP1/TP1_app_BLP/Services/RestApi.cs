using System;
using System.Collections.Generic;
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
    /**
     * Singleton for Authorization persistence.
     */
    public class RestApi
    {
        public static RestApi Client = new RestApi();
        private HttpClient client;

        private RestApi()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5000/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public RestApi getClient()
        {
            return Client;
        }

        public bool Login(AuthenticationRequest authenticationRequest)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(authenticationRequest), Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync("login", content).Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                string encodedToken = JsonConvert.DeserializeObject<string>(data);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", encodedToken);
                return true;
            }
            return false;
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

        public Doctor? PutDoctor(Doctor doctor)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(doctor), Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PutAsync("info", content).Result;
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }
            string data = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<Doctor>(data);
        }

        public IEnumerable<Patient> GetPatients()
        {
            HttpResponseMessage response = client.GetAsync("patients").Result;
            if (!response.IsSuccessStatusCode)
            {
                return Enumerable.Empty<Patient>();
            }

            string data = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<List<Patient>>(data);
        }

        public Patient? PostPatient(Patient patient)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(patient), Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync("patients", content).Result;
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }
            string data = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<Patient>(data);
        }
    }
}
