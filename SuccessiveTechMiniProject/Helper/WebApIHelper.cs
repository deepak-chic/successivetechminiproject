using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;

namespace SuccessiveTechMiniProject
{
    public class WebApIHelper<T> : IWebApiHelper<T> where T : class
    {
        private HttpClient _webApiClient;

        public HttpClient WebApiClient
        {
            get
            {
                if (_webApiClient == null)
                {
                    _webApiClient = new HttpClient();
                }

                return _webApiClient;
            }
        }

        public void ConnectWithWebApi()
        {
            WebApiClient.BaseAddress = new Uri(ConfigurationManager.AppSettings["SuccessiveTechiniProject.WebAPI"]);
        }

        public void Dispose()
        {
            _webApiClient.Dispose();
        }

        /// <summary>
        /// Return the list of entity
        /// </summary>
        /// <param name="apiControllerName">Web api controller name</param>
        /// <returns>List of entity</returns>
        public IList<T> GetAll(string apiControllerName)
        {
            ConnectWithWebApi();
            IList<T> entities = new List<T>();
            var responseTask = _webApiClient.GetAsync(apiControllerName);
            responseTask.Wait();

            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<T>>();
                readTask.Wait();
                entities = readTask.Result;
            }

            return entities;
        }

        /// <summary>
        /// Return the specific entity
        /// </summary>
        /// <param name="apiControllerName">Web api controller name</param>
        /// <returns>Entity instance</returns>
        public T Get(string apiControllerName)
        {
            ConnectWithWebApi();
            T entity = null;
            var responseTask = _webApiClient.GetAsync(apiControllerName);
            responseTask.Wait();

            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<T>();
                readTask.Wait();
                entity = readTask.Result;
            }

            return entity;
        }

        public int Create(string apiControllerName, T entity)
        {
            ConnectWithWebApi();

            //HTTP POST
            var postTask = _webApiClient.PostAsJsonAsync<T>(apiControllerName, entity);
            postTask.Wait();

            var result = postTask.Result;
            if (result.IsSuccessStatusCode)
            {
                return 1;
            }

            return -1;
        }

        public int Edit(string apiControllerName, T entity)
        {
            ConnectWithWebApi();

            //HTTP POST
            var postTask = _webApiClient.PutAsJsonAsync<T>(apiControllerName, entity);
            postTask.Wait();

            var result = postTask.Result;
            if (result.IsSuccessStatusCode)
            {
                return 1;
            }

            return -1;
        }

        public int Delete(string apiControllerName)
        {
            ConnectWithWebApi();

            //HTTP POST
            var postTask = _webApiClient.DeleteAsync(apiControllerName);
            postTask.Wait();

            var result = postTask.Result;
            if (result.IsSuccessStatusCode)
            {
                return 1;
            }

            return -1;
        }

    }
}