using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using JPZipSharp.ASPNETSample.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace JPZipSharp.ASPNETSample.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IJapanPostApiClient _japanPostApiClient;

    public HomeController(ILogger<HomeController> logger,IJapanPostApiClient japanPostApiClient)
    {
        _japanPostApiClient = japanPostApiClient;
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public async Task<string> Address(string Code)
    {
        var responce = await _japanPostApiClient.SearchCodeAsync(Code);
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
