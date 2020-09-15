using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GestionServiceBatiment.ASP.Models.Modifications;
using GestionServiceBatiment.ASP.Infrastructures.Services;
using System.Net.Http;
using GestionServiceBatiment.ASP.Infrastructures.Interfaces;
using Newtonsoft.Json;
using System.Text;
using System.Net;

namespace GestionServiceBatiment.ASP.Infrastructures
{
    public class ModificationService : BaseService, IModificationService
    {
        //private string _uri;
        public ModificationService(string login = null, string password = null)
            : base("modification/", login, password)
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

        public IEnumerable<Modification> GetAll()
        {
            HttpResponseMessage response = _httpClient.GetAsync("").Result;
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Echec de la réception de données.");
            }
            return response.Content.ReadAsAsync<IEnumerable<Modification>>().Result;
        }

        public Modification GetById(int id)
        {
            HttpResponseMessage response = _httpClient.GetAsync(id.ToString()).Result;
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Echec de la réception de données.");
            }
            return response.Content.ReadAsAsync<Modification>().Result;
        }

        public int Post(Modification entity)
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

        public bool Put(int id, Modification entity)
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