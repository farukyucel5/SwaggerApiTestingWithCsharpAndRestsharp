﻿using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTestProject1
{
    public class Helper
    {
        private RestClient client;
        private RestRequest request;
        private const String baseUrl = "https://petstore.swagger.io/";

        public RestClient SetUrl(String endpoint){
            var url = baseUrl + endpoint;
            client= new RestClient(url);
            return client;
        }

        public RestRequest CreateGetRequest() {
            request = new RestRequest()
            {
                Method = Method.Get
            };
            request.AddHeader("Accept", "application/json");
            return request;

        }

        public RestRequest CreatePostRequest<T>(T feature)
        {
            request = new RestRequest()
            {
                Method = Method.Post
            };
            request.AddHeader("accept","application/json");
            request.AddHeader("Content-Type","application/json");
            request.AddBody(feature);
            request.RequestFormat=DataFormat.Json;
            return request;
        }

        public RestResponse GetResponse(RestClient restClient,RestRequest restRequest)
        {
            return restClient.Execute(restRequest);
        }

        public T GetContent<T>(RestResponse response)
        {
            var content = response.Content;
            return JsonConvert.DeserializeObject<T>(content);
        }

    }
}
