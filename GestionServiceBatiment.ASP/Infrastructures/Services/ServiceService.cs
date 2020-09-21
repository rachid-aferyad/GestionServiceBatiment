using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GestionServiceBatiment.ASP.Models.Services;
using GestionServiceBatiment.ASP.Infrastructures.Services;
using System.Net.Http;
using GestionServiceBatiment.ASP.Infrastructures.Interfaces;
using Newtonsoft.Json;
using System.Text;
using System.Net;

namespace GestionServiceBatiment.ASP.Infrastructures
{
    public class ServiceService : BaseService, IServiceService
    {
        //private string _uri;
        public ServiceService(string login = null, string password = null)
            : base("Service/", login, password)
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

        public IEnumerable<Service> GetAll()
        {
            HttpResponseMessage response = _httpClient.GetAsync("").Result;
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Echec de la réception de données.");
            }
            return response.Content.ReadAsAsync<IEnumerable<Service>>().Result;
        }

        public IEnumerable<Service> GetByCategory(int categoryId)
        {
            HttpResponseMessage response = _httpClient.GetAsync("Category/" + categoryId).Result;
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Echec de la réception de données.");
            }
            return response.Content.ReadAsAsync<IEnumerable<Service>>().Result;
        }

        //public IEnumerable<Service> GetByCategoryName(string categoryName)
        //{
        //    HttpResponseMessage response = _httpClient.GetAsync("CategoryName/" + categoryName).Result;
        //    if (!response.IsSuccessStatusCode)
        //    {
        //        throw new Exception("Echec de la réception de données.");
        //    }
        //    return response.Content.ReadAsAsync<IEnumerable<Service>>().Result;
        //}

        public Service GetById(int id)
        {
            HttpResponseMessage response = _httpClient.GetAsync(id.ToString()).Result;
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Echec de la réception de données.");
            }
            Service service = response.Content.ReadAsAsync<Service>().Result;
            return service;
        }

        public int Post(Service entity)
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

        public bool Put(int id, Service entity)
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