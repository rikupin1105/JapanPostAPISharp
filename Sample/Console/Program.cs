using JPZipSharp;
using JPZipSharp.Model;

namespace JPZipSharp.Sample
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var client = new JapanPostApiClient("cliendId", "clientSecret");

            var s = client.SearchCodeAsync("1000001").Result;

            foreach (var address in s.Addresses)
            {
                Console.WriteLine($"Prefecture: {address.pref_name}");
                Console.WriteLine($"City: {address.city_name}");
                Console.WriteLine($"Town: {address.town_name}");
                Console.WriteLine();
            }
        }
    }
}
