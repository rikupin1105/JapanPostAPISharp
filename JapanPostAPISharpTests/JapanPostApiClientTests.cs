using JapanPostAPISharp;
using System.Diagnostics;

namespace JapanPostAPISharpTests
{
    [TestClass()]
    public class JapanPostApiClientTests
    {
        [TestMethod()]
        public async Task SearchCodeTestAsync()
        {
            var client = new JapanPostApiClient(
                Environment.GetEnvironmentVariable("CliendId"),
                Environment.GetEnvironmentVariable("ClientSecret"));

            var r = await client.SearchCodeAsync("A7E2FK2");

            Assert.AreEqual(r.Addresses[0].PrefName, "東京都");
        }
    }
}