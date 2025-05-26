using System.Diagnostics;

namespace JPZipSharp.Tests
{
    [TestClass()]
    public class JapanPostApiClientTests
    {
        [TestMethod()]
        public async Task SearchCodeTestAsync()
        {
            var client = new JapanPostApiClient(
                "b46cd53f6e0e4a19bff044dd97bb1b2f",
                "35be0e1db3d54ef7adcdcc689f631090");

            var r = await client.SearchCodeAsync("A7E2FK2");

            Assert.AreEqual(r.Addresses[0].pref_name, "東京都");
        }
    }
}