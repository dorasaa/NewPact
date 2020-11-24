using PactNet;
using PactNet.Infrastructure.Outputters;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;

namespace ContractTestingDemo.Test
{

    public class ProviderPactTest
    {
        private readonly ITestOutputHelper _output;
        public ProviderPactTest(ITestOutputHelper Output)
        {
            _output = Output;
        }

        [Fact]
        public void TestProvider()
        {
            var config = new PactVerifierConfig
            {

                Outputters = new List<IOutput> 
                {
                    new XUnitOutput(_output)
                },
                Verbose = true
            };
            new PactVerifier(config)
                .ServiceProvider("PayoutQueue", "http://localhost:57898/api")
                .HonoursPactWith("PayoutApi_Consumer")
                .PactUri(@"C:\dev\pactcontractfile\pacts\payoutapi_consumer-payoutqueue.json")
                .Verify();

        }
    }
}
