using Newtonsoft.Json;
using PayoutQueueProvider.Models;
using System;
using System.Net.Http;

namespace ContractTestingDemo.Mock
{
    public class MockClient
    {
        private readonly HttpClient _client;


        public MockClient(string baseUri = null)
        {
            _client = new HttpClient { BaseAddress = new Uri(baseUri ?? "http://localhost:57898") };

        }
        public PayoutItem GetPayoutItemDetails()
        {
            string reasonPhrase;
            var request = new HttpRequestMessage(HttpMethod.Get, "/payoutitems");
            request.Headers.Add("Accept", "application/json");
            var response = _client.SendAsync(request);
            var content = response.Result.Content.ReadAsStringAsync().Result;
            var status = response.Result.StatusCode;


            reasonPhrase = response.Result. ReasonPhrase; //Note: any pact mock provider errors will be returned here and 
                                                  //in response body

            request.Dispose();
            response.Dispose();

            if (status == System.Net.HttpStatusCode.OK)
            {
                return !string.IsNullOrWhiteSpace(content) ?
                            JsonConvert.DeserializeObject<PayoutItem>(content) : null;

            }
            throw new Exception(reasonPhrase);
        }
    }
}
