using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GestionServiceBatiment.ASP.Models.Requests;
using GestionServiceBatiment.ASP.Infrastructures.Services;
using System.Net.Http;
using GestionServiceBatiment.ASP.Infrastructures.Interfaces;
using Newtonsoft.Json;
using System.Text;
using System.Net;

namespace GestionServiceBatiment.ASP.Infrastructures
{
    public class RequestService : BaseService, IRequestService
    {
        //private string _uri;
        public RequestService(string login = null, string password = null)
            : base("Request/", login, password)
        {
            //_uri = "category/";
        }
        public bool Delete(int id)
        {
            HttpResponseMessage response = _httpClient.DeleteAsync(id.ToString()).Result;
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Echec de la suppression des données.");
            }
            return true;
        }

        public IEnumerable<Request> GetAll()
        {
            HttpResponseMessage response = _httpClient.GetAsync("").Result;
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Echec de la réception de données.");
            }
            return response.Content.ReadAsAsync<IEnumerable<Request>>().Result;
        }

        public Request GetById(int id)
        {
            HttpResponseMessage response = _httpClient.GetAsync(id.ToString()).Result;
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Echec de la réception de données.");
            }
            return response.Content.ReadAsAsync<Request>().Result;
        }

        public DisplayRequest GetRequestDetailsById(int id)
        {
            HttpResponseMessage response = _httpClient.GetAsync(id.ToString()).Result;
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Echec de la réception de données.");
            }
            DisplayRequest displayRequest = response.Content.ReadAsAsync<DisplayRequest>().Result;
            return displayRequest;
        }

        public IEnumerable<RequestListing> GetByCategory(int categoryId)
        {
            HttpResponseMessage response = _httpClient.GetAsync("Category/" + categoryId).Result;
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Echec de la réception de données.");
            }
            return response.Content.ReadAsAsync<IEnumerable<RequestListing>>().Result;
        }
        
        public IEnumerable<RequestListing> GetLatestRequests()
        {
            HttpResponseMessage response = _httpClient.GetAsync("LatestRequests/").Result;
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Echec de la réception de données.");
            }
            return response.Content.ReadAsAsync<IEnumerable<RequestListing>>().Result;
        }

        public int Post(Request entity)
        {
            string jsonContent = JsonConvert.SerializeObject(entity, Formatting.Indented);
            StringContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            HttpResponseMessage response = _httpClient.PostAsync("", content).Result;
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Echec de l'envois de données.");
            }
            return (int)response.Content.ReadAsAsync(typeof(int)).Result;
        }

        public bool Put(int id, Request entity)
        {
            string jsonContent = JsonConvert.SerializeObject(entity);
            StringContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            HttpResponseMessage response = _httpClient.PutAsync(id.ToString(), content).Result;
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Echec de la mise à jour des données.");
            }
            return true;
        }

    }
}