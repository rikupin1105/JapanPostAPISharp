namespace JapanPostAPISharp.Sample
{
    internal class Program
    {
        static async Task Main()
        {
            var client = new JapanPostApiClient("cliendId", "clientSecret");

            var s = await client.SearchCodeAsync("1000001");

            if (s == null)
            {
                Console.WriteLine("No results found.");
                return;
            }
            if (s.Addresses is null)
            {
                Console.WriteLine("No addresses found.");
                return;
            }
            foreach (var address in s.Addresses)
            {
                Console.WriteLine($"Prefecture: {address.PrefName}");
                Console.WriteLine($"City: {address.CityName}");
                Console.WriteLine($"Town: {address.TownName}");
                Console.WriteLine();
            }
        }
    }
}
