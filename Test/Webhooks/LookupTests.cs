using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using PayPalCheckoutSdk.Test;
using PayPalCheckoutSdk.Webhooks;
using Xunit;
using Xunit.Abstractions;

namespace PayPalCheckoutSdk.Webhooks.Test
{
    [Collection("WebhooksLookup")]
    public class LookupTests
    {
        private readonly ITestOutputHelper _output;

        public LookupTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public async Task TestLookupGetEmptyRequest()
        {
            LookupsGetRequest request = new LookupsGetRequest();

            var response = await TestHarness.client().Execute(request);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            LookupList webhookList = response.Result<LookupList>();
            Assert.NotNull(webhookList);
        }

        [Fact]
        public async Task TestCreateGetDeleteLookupRequest()
        {
            LookupCreateRequest request = new LookupCreateRequest();
            request.Prefer(HeaderValueConstants.PreferValueRepresentation);
            var webhookLookup = new Lookup()
            {
                ClientId = TestHarness.ClientId
            };
            request.RequestBody(webhookLookup);
            
            var createResponse = await TestHarness.client().Execute(request);
            var createResult = createResponse.Result<Lookup>();
            Assert.Equal(HttpStatusCode.Created, createResponse.StatusCode);

            Assert.NotNull(createResult);
            Assert.False(string.IsNullOrWhiteSpace(createResult.Id));
            _output.WriteLine($"webhookLookupId: {createResult.Id}");

            try
            {
                //Get Webhook Lookup Details
                var getDetailsRequest = new LookupGetRequest(createResult.Id);
                var getResponse = await TestHarness.client().Execute(getDetailsRequest);
                Assert.Equal(HttpStatusCode.OK, getResponse.StatusCode);

                var getDetailsResult = getResponse.Result<Lookup>();
                Assert.NotNull(getDetailsResult);
                Assert.Equal<string>(createResult.ClientId, getDetailsResult.ClientId, StringComparer.OrdinalIgnoreCase);
                Assert.Equal<string>(createResult.Id, getDetailsResult.Id, StringComparer.OrdinalIgnoreCase);
                //
                //Get Webhook Lookup List
                LookupsGetRequest getLookupsRequest = new LookupsGetRequest();

                var getLookupsResponse = await TestHarness.client().Execute(getLookupsRequest);
                Assert.Equal(HttpStatusCode.OK, getLookupsResponse.StatusCode);

                LookupList lookupListResult = getLookupsResponse.Result<LookupList>();
                Assert.NotNull(lookupListResult);
                Lookup lookup = lookupListResult.WebhookLookups.FirstOrDefault(f => f.Id == createResult.Id && f.ClientId == createResult.ClientId);
                Assert.NotNull(lookup);
                //
            }
            finally
            {
                var deleteRequest = new LookupDeleteRequest(createResult.Id);
                var deleteResponse = await TestHarness.client().Execute(deleteRequest);
                Assert.Equal(HttpStatusCode.NoContent, deleteResponse.StatusCode);
            }

        }
    }
}
