using ApiTestProject1;
using ApiTestProject1.Model;
using NUnit.Framework;
using RestSharp;
using System.Text;
using System.Text.Unicode;

namespace SwaggerApiTestProject
{
    public class SwaggerTestClass
    {

        [Test]
        public void PositivePostApetTest() {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                RequestUri = new Uri("https://petstore.swagger.io/v2/pet"),
                Method = HttpMethod.Post,
                Content = new StringContent("{\r\n  \"id\": 1230,\r\n  \"category\": {\r\n    " +
                "\"id\": 13,\r\n    \"name\": \"british\"\r\n  },\r\n  \"name\": \"honeyCat\"" +
                ",\r\n  \"photoUrls\": [\r\n    \"string\"\r\n  ]" +
                ",\r\n  \"tags\": [\r\n    {\r\n      \"id\": 0,\r\n      \"name\": \"string\"\r\n" +
                "    }\r\n  ],\r\n  \"status\": \"available\"\r\n}"
                , Encoding.UTF8, "application/json")
            };
            var response = client.SendAsync(request).Result;
            var responseString = response.Content.ReadAsStringAsync().Result;
            Console.WriteLine(responseString);

            String expectedName = "honeyCat";
            Assert.IsTrue(responseString.Contains(expectedName));
            


        }

        [Test]
        public void positiveGetPetTest01()
        {
            var api = new Swagger();
            var response = api.GetPets();
            Assert.AreEqual("sold", response.Status);
            Console.WriteLine(response.Status);
            Console.WriteLine(response.Id);
            Console.WriteLine(response.Name);
            string expectedName = "honeyCat";
            Assert.True(response.Name == expectedName);
        }

        [Test]
        public void PositivepUpdateAPetTest()
        {

            string apiUrl = "https://petstore.swagger.io/v2/pet";
            string jsonString = "{\r\n  \"id\": 1230,\r\n  \"category\": {\r\n    " +
                "\"id\": 13,\r\n    \"name\": \"british\"\r\n  },\r\n  \"name\": \"honeyCat\"" +
                ",\r\n  \"photoUrls\": [\r\n    \"string\"\r\n  ]" +
                ",\r\n  \"tags\": [\r\n    {\r\n      \"id\": 0,\r\n      \"name\": \"string\"\r\n" +
                "    }\r\n  ],\r\n  \"status\": \"sold\"\r\n}";

            var client = new RestClient(apiUrl);
            var request = new RestRequest()
            {
                Method = Method.Put
            };
            request.AddHeader("content-type", "application/json");
            request.AddJsonBody(jsonString);

            RestResponse response = client.Execute(request);
            Assert.IsTrue(response.IsSuccessful);



        }




        [Test]
        public void NegativeUserPostwithArrayTest()
        {

                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    RequestUri = new Uri("https://petstore.swagger.io/v2/user/createWithList"),
                    Method = HttpMethod.Post,
                    Content = new StringContent("[\r\n  {\r\n    \"id\": \"123\",\r\n   " +
                    " \"username\": \"JohnTony51\",\r\n    " +
                    "\"firstName\": \"Robot\",\r\n    \"lastName\": \"tony\",\r\n  " +
                    "  \"email\": \"d@gmail.com\",\r\n    " +
                    "\"password\": \"string\",\r\n    \"phone\": \"123456789\",\r\n   " +
                    " \"userStatus\": 0\r\n  }\r\n]"
                    , Encoding.UTF8, "application/json")
                };
                var response = client.SendAsync(request).Result;
                var responseString = response.Content.ReadAsStringAsync().Result;
                
                //I have not been able to post with string id value but I could 
                //it created a post request with a string id value
                //I expected to get codes like 400 vs but I got 200
           

                Assert.False(responseString.Contains("200"));
            
        }

        [Test]
        public void NegativeGetUserTest()
        {
            var api = new Swagger();
            var response = api.GetUserItems();
            Assert.AreEqual(123, response.id);
        }
    }



    }