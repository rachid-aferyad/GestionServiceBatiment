using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;

namespace GestionServiceBatiment.ASP.Infrastructures.Services
{
    public class BaseService
    {
        protected HttpClient _httpClient;

        private string _baseUri;

        public BaseService(string baseUri, string login = null, string password = null)
        {
            NetworkCredential credential;
            HttpClientHandler handler = null;
            if (!(login is null && password is null))
            {
                credential = new NetworkCredential(login, password);
                handler = new HttpClientHandler { Credentials = credential };
            }
            //_httpClient = (handler is null) ? new HttpClient() : new HttpClient(handler);
            _httpClient = new HttpClient();
            _baseUri = "http://localhost:49921/api/" + baseUri;
            _httpClient.BaseAddress = new Uri(_baseUri);
        }
    }
}