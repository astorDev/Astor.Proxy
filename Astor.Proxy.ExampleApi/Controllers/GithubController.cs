using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Astor.Proxy.ExampleApi.Controllers;

[Route("github")]
public class GithubController : Controller
{
    public GithubService Service { get; }
    
    public GithubController(GithubService service)
    {
        Service = service;
    }
        
    [HttpGet]
    [Authorize]
    public async Task Get()
    {
        await this.Service.Client.Proxy(this.HttpContext);
    }
}

/// <summary>
/// For some reason registering httpclient directly to controller doesn't work (BaseAddress remains blank)
/// So there's a helper service just for that
/// </summary>
public class GithubService
{
    public HttpClient Client { get; }

    public GithubService(HttpClient client)
    {
        Client = client;
    }
}