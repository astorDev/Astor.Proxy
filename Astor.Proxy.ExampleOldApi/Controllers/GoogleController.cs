using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace Astor.Proxy.ExampleOldApi.Controllers
{
    [Route("github")]
    public class GithubController : Controller
    {
        [HttpGet]
        public async Task GetAsync()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, "https://api.github.com");
            request.Headers.UserAgent.Add(new ProductInfoHeaderValue("code", "1.0"));
            var response = await client.SendAsync(request);
            await ProxyClient.CopyHttpResponseAsync(this.HttpContext, response);
        }       
    }
}