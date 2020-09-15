using System;
using System.Linq;
using System.Web;
using System.Text;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.Generic;
using GestionServiceBatiment.ASP.Models.Comments;
using GestionServiceBatiment.ASP.Infrastructures.Services;
using GestionServiceBatiment.ASP.Infrastructures.Interfaces;

namespace GestionServiceBatiment.ASP.Infrastructures
{
    public class CommentService : BaseService, ICommentService
    {
        //private string _uri;
        public CommentService(string login = null, string password = null)
            : base("", login, password)
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

        public IEnumerable<Comment> GetAll()
        {
            HttpResponseMessage response = _httpClient.GetAsync("Comments/").Result;
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Echec de la réception de données.");
            }
            return response.Content.ReadAsAsync<IEnumerable<Comment>>().Result;
        }

        public Comment GetById(int id)
        {
            HttpResponseMessage response = _httpClient.GetAsync("Comments/" + id.ToString()).Result;
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Echec de la réception de données.");
            }
            return response.Content.ReadAsAsync<Comment>().Result;
        }

        public IEnumerable<Comment> GetByCompany(int companyId)
        {
            HttpResponseMessage response = _httpClient.GetAsync("Company/" + companyId.ToString() + "/Comments").Result;
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Echec de la réception de données.");
            }
            return response.Content.ReadAsAsync<IEnumerable<Comment>>().Result;
        }
        
        public IEnumerable<Comment> GetByService(int serviceId)
        {
            HttpResponseMessage response = _httpClient.GetAsync("Service/" + serviceId.ToString() + "/Comments").Result;
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Echec de la réception de données.");
            }
            return response.Content.ReadAsAsync<IEnumerable<Comment>>().Result;
        }
        
        public IEnumerable<Comment> GetByRequest(int requestId)
        {
            HttpResponseMessage response = _httpClient.GetAsync("Request/" + requestId.ToString() + "/Comments").Result;
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Echec de la réception de données.");
            }
            return response.Content.ReadAsAsync<IEnumerable<Comment>>().Result;
        }

        public int Post(Comment entity)
        {
            string jsonContent = JsonConvert.SerializeObject(entity, Formatting.Indented);
            StringContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            HttpResponseMessage response = _httpClient.PostAsync("Comment", content).Result;
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Echec de l'envois de données.");
            }
            return (int)response.Content.ReadAsAsync(typeof(int)).Result;
        }

        public bool Put(int id, Comment entity)
        {
            string jsonContent = JsonConvert.SerializeObject(entity);
            StringContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            HttpResponseMessage response = _httpClient.PutAsync("Comment/" + id.ToString(), content).Result;
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Echec de la mise à jour des données.");
            }
            return true;
        }
    }
}