using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using JapanPostAPISharp.ASPNETSample.Models;

namespace JapanPostAPISharp.ASPNETSample.Controllers;

public class HomeController(ILogger<HomeController> logger, IJapanPostApiClient japanPostApiClient) : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public async Task<string> Address(string Code)
    {
        var responce = await japanPostApiClient.SearchCodeAsync(Code);
        var json = JsonSerializer.Serialize(responce.Addresses[0]);
        Console.WriteLine(json);
        return json;
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
