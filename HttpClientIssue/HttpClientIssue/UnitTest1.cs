using NUnit.Framework;
using System.Net.Http;
using System.Threading.Tasks;

namespace HttpClientIssue
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task Test1()
        {
            var a = new SocketsHttpHandler();
            HttpClient client = HttpClientFactory.Create();

            var req = new HttpRequestMessage(HttpMethod.Get, "https://tools.morningstar.dk/api/rest.svc/timeseries_price/nen6ere626?id=F000015CV2%5D2%5D1%5D&currencyId=CZK&idtype=Morningstar&priceType=&frequency=daily&startDate=2020-06-29&endDate=2020-09-21&outputType=COMPACTJSON");
            var resp = await client.SendAsync(req);

            //var resp = await client.GetAsync("https://tools.morningstar.dk/api/rest.svc/timeseries_price/nen6ere626?id=F000015CV2%5D2%5D1%5D&currencyId=CZK&idtype=Morningstar&priceType=&frequency=daily&startDate=2020-06-29&endDate=2020-09-21&outputType=COMPACTJSON");
            var res = await resp.Content.ReadAsStringAsync();

            //https://stackoverflow.com/questions/38083206/not-calling-dispose-on-httprequestmessage-and-httpresponsemessage-in-asp-net-cor
            //resp.Dispose();
            //req.Dispose();

            var resp2 = await client.GetAsync("https://tools.morningstar.dk/api/rest.svc/timeseries_price/nen6ere626?id=F000015CV2%5D2%5D1%5D&currencyId=CZK&idtype=Morningstar&priceType=&frequency=daily&startDate=2020-06-29&endDate=2020-09-21&outputType=COMPACTJSON");
            var res2 = await resp2.Content.ReadAsStringAsync();

            resp2.Dispose();

            client.Dispose();
        }
    }
}