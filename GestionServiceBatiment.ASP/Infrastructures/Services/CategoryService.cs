using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GestionServiceBatiment.ASP.Models.Categories;
using GestionServiceBatiment.ASP.Infrastructures.Services;
using System.Net.Http;
using GestionServiceBatiment.ASP.Infrastructures.Interfaces;
using Newtonsoft.Json;
using System.Text;
using System.Net;

namespace GestionServiceBatiment.ASP.Infrastructures
{
    public class CategoryService : BaseService, ICategoryService
    {
        //private string _uri;
        public CategoryService(string login = null, string password = null)
            : base("category/", login, password)
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

        public IEnumerable<Category> GetAll()
        {
            HttpResponseMessage response = _httpClient.GetAsync("").Result;
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Echec de la réception de données.");
            }
            return response.Content.ReadAsAsync<IEnumerable<Category>>().Result;
        }

        public Category GetById(int id)
        {
            HttpResponseMessage response = _httpClient.GetAsync(id.ToString()).Result;
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Echec de la réception de données.");
            }
            return response.Content.ReadAsAsync<Category>().Result;
        }

        public Category GetByName(string name)
        {
            HttpResponseMessage response = _httpClient.GetAsync("Name/" + name).Result;
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Echec de la réception de données.");
            }
            return response.Content.ReadAsAsync<Category>().Result;
        }

        public IEnumerable<Category> GetSubCategories(int categoryId)
        {
            HttpResponseMessage response = _httpClient.GetAsync("Sub/" + categoryId.ToString()).Result;
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Echec de la réception de données.");
            }
            return response.Content.ReadAsAsync<IEnumerable<Category>>().Result;
        }

        public IEnumerable<Category> GetSubCategoriesByName(string parentName)
        {
            HttpResponseMessage response = _httpClient.GetAsync("Sub/ParentName/" + parentName).Result;
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Echec de la réception de données.");
            }
            return response.Content.ReadAsAsync<IEnumerable<Category>>().Result;
        }

        public IEnumerable<Category> GetSupCategories()
        {
            HttpResponseMessage response = _httpClient.GetAsync("Sup").Result;
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Echec de la réception de données.");
            }
            return response.Content.ReadAsAsync<IEnumerable<Category>>().Result;
        }

        public int Post(Category entity)
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

        public bool Put(int id, Category entity)
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