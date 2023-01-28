using ApiTestProject1.Model;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTestProject1
{
    public class Swagger
    {
        private Helper helper;

        public Swagger()
        {
            helper = new Helper();
        }
        public Pets GetPets() {

            //var client = new RestClient("https://petstore.swagger.io/");
            //var request = new RestRequest("v2/pet/13", Method.Get);
            //request.AddHeader("Accept", "application/json");
            //request.RequestFormat = DataFormat.Json;

            //RestResponse response = client.Execute(request);
            //var content = response.Content;

            //Pets pets=JsonConvert.DeserializeObject<Pets>(content);
            //return pets;
            var client = helper.SetUrl("v2/pet/1230");
            var request = helper.CreateGetRequest();
            request.RequestFormat = DataFormat.Json;
            var response=helper.GetResponse(client, request);
            var pets = helper.GetContent<Pets>(response);
            return pets;

        }

        public CreateUserItems GetUserItems()
        {
            var client = helper.SetUrl("v2/user/JohnTony51");
            var request = helper.CreateGetRequest();
            request.RequestFormat = DataFormat.Json;
            var response = helper.GetResponse(client, request);
            var pets = helper.GetContent< CreateUserItems>(response);
            return pets;
        }

        public CreateUserItems CreateUserpost(String feature)
        {
            var client = helper.SetUrl("v2/user/createWithArray");
            var request = helper.CreatePostRequest(feature);
            var response = helper.GetResponse(client, request);
            var creating = helper.GetContent<CreateUserItems>(response);
            return creating;


        }
    }
}
