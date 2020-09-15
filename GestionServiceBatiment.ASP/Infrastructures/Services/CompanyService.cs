using System;
using System.Linq;
using System.Web;
using System.Text;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.Generic;
using GestionServiceBatiment.ASP.Models.Companies;
using GestionServiceBatiment.ASP.Infrastructures.Services;
using GestionServiceBatiment.ASP.Infrastructures.Interfaces;

namespace GestionServiceBatiment.ASP.Infrastructures
{
    public class CompanyService : BaseService, ICompanyService
    {
        //private string _uri;
        public CompanyService(string login = null, string password = null)
            : base("company/", login, password)
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

        public IEnumerable<Company> GetAll()
        {
            HttpResponseMessage response = _httpClient.GetAsync("").Result;
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Echec de la réception de données.");
            }
            return response.Content.ReadAsAsync<IEnumerable<Company>>().Result;
        }

        public Company GetById(int id)
        {
            HttpResponseMessage response = _httpClient.GetAsync(id.ToString()).Result;
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Echec de la réception de données.");
            }
            return response.Content.ReadAsAsync<Company>().Result;
        }

        public int Post(Company entity)
        {
            string jsonContent = JsonConvert.SerializeObject(entity, Formatting.Indented);
            StringContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            HttpResponseMessage response = _httpClient.PostAsync("Post", content).Result;
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Echec de l'envois de données.");
            }
            return (int)response.Content.ReadAsAsync(typeof(int)).Result;
        }

        public bool Put(int id, Company entity)
        {
            string jsonContent = JsonConvert.SerializeObject(entity);
            StringContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            HttpResponseMessage response = _httpClient.PutAsync("Put/" + id.ToString(), content).Result;
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Echec de la mise à jour des données.");
            }
            return true;
        }
    }
}