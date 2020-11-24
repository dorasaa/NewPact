using PactNet;
using PactNet.Mocks.MockHttpService;
using System;

namespace ContractTestingDemo.Consumer
{
    public class ConsumerPact : IDisposable
    {
        public IPactBuilder PactBuilder { get; private set; }
        public IMockProviderService MockProviderService { get; private set; }

        public int MockServerPort { get { return 9224; } }
        public string MockProviderServiceBaseUrl { get { return string.Format("http://localhost:{0}", MockServerPort); } }


        public ConsumerPact()
        {
            //detailed help https://github.com/pact-foundation/pact-net/blob/master/README.md
            //pact configuration
            var pactConfig = new PactConfig
            {
                SpecificationVersion = "2.0.0",
                PactDir = @"c:\dev\pactcontractfile\pacts",
                LogDir = @"c:\dev\pactcontractfile\logs"
            };
            PactBuilder = new PactBuilder(pactConfig);
            PactBuilder
                    .ServiceConsumer("PayoutApi_Consumer")
                    .HasPactWith("PayoutQueue");
            MockProviderService = PactBuilder.MockService(MockServerPort);
        }

        public void Dispose()
        {
            PactBuilder.Build();
        }
    }
}
