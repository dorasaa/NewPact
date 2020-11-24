using ContractTestingDemo.Consumer;
using ContractTestingDemo.Mock;
using PactNet.Mocks.MockHttpService;
using PactNet.Mocks.MockHttpService.Models;
using System.Collections.Generic;
using Xunit;

namespace ContractTestingDemo.Test
{
    public class ConsumerPactTest : IClassFixture<ConsumerPact>
    {
        private IMockProviderService _mockProvoiderService;
        private string _mockProviderServiceBaseUrl;

        public ConsumerPactTest(ConsumerPact data)
        {
            _mockProvoiderService = data.MockProviderService;
            _mockProvoiderService.ClearInteractions();//Note: Clear any prev regd interactions before the test is run
            _mockProviderServiceBaseUrl = data.MockProviderServiceBaseUrl;
        }

        [Fact]
        public void GetPayoutItemDetails_VerifyIfItReturns()
        {
            //Arrange
            _mockProvoiderService.Given("Payout Item details default")
                .UponReceiving("A Get request to retrieve the Payout Item details")
                .With(new ProviderServiceRequest
                {
                    Method = HttpVerb.Get,
                    Path = "/payoutitems",
                    Headers = new Dictionary<string, object> {
                        { "Accept","application/json"}
                    }
                })
                .WillRespondWith(
                new ProviderServiceResponse
                {

                    Status = 200,
                    Headers = new Dictionary<string, object> { { "content-type", "application/json: charset=utf-8" } },
                    Body = new
                    {

                           PayoutItemId =84984,
                            PayoutUBR ="JHKNKJ-JHHDJKH-NJKJHH-KJKJKJK",
                            PayoutQueueName="TUNES",
                            PayoutRouteId =2 
        
                    }
                });

            var consumer = new MockClient(_mockProviderServiceBaseUrl);
            
            //Act
            var result = consumer.GetPayoutItemDetails();

            //Assert
            Assert.Equal("TUNES", result.PayoutQueueName);
            _mockProvoiderService.VerifyInteractions();
        }

    }
}
