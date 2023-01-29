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
        public void PositiveUpdateAPetTest()
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
                    Content = new StringContent("[\r\n  {\r\n    \"id\": 123,\r\n   " +
                    " \"username\": \"JohnTony51\",\r\n    " +
                    "\"firstName\": 12,\r\n    \"lastName\": \"tony\",\r\n  " +
                    "  \"email\": \"d@gmail.com\",\r\n    " +
                    "\"password\": \"string\",\r\n    \"phone\": \"123456789\",\r\n   " +
                    " \"userStatus\": 0\r\n  }\r\n]"
                    , Encoding.UTF8, "application/json")
                };
                var response = client.SendAsync(request).Result;
                var responseString = response.Content.ReadAsStringAsync().Result;
                
                //I should not have been able to post with integer firstname value but I could
                //it is supposed not to make a post request with an integer firstname 
                //because firstname is expected as a string in the api document. 
           

                Assert.False(responseString.Contains("200"));
            
        }

        [Test]
        public void VerifyTheNegativePostUserTest()
        {

            var api = new Swagger();
            var response = api.GetUserItems();
            Assert.IsTrue(response.firstName.Equals("12"));
        }



        [Test]
        public void NegativePostStoreTest()
        {
            /*
             * -2147483647<integer<2147483647
             */
            /* Even if the id value specified is greater than the upper limit of the integer data type,
            
            the post request is created by the api.
             */

            string apiUrl = "https://petstore.swagger.io/v2/pet";
            string jsonString = "{\r\n  \"id\": 214748364711232,\r\n  \"petId\": 156,\r\n " +
                " \"quantity\": 12,\r\n  \"shipDate\": \"2023-01-29T10:56:56.090Z\",\r\n " +
                " \"status\": \"placed\",\r\n  \"complete\": false\r\n}";

            var client = new RestClient(apiUrl);
            var request = new RestRequest()
            {
                Method = Method.Post
            };
            request.AddHeader("content-type", "application/json");
            request.AddHeader("accept", "application/json");
            request.AddJsonBody(jsonString);

            RestResponse response = client.Execute(request);
            Assert.IsFalse(response.IsSuccessful);
      }



       [Test]
        public void positiveDeleteStore()
        {
            var api = new Swagger();
            var response = api.GettingStore();
            if (response.IsSuccessful)
            {
                var getResponse = api.DeletingStore();
                Assert.IsTrue(getResponse.IsSuccessful);
            }else
            {
                Assert.IsFalse(response.IsSuccessful);
                Console.WriteLine("The store is already not available");

            }
            

            


        }

            
            
            
        }
    }



