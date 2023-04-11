using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Astor.Proxy.ExampleApi.Controllers
{
    [Route("posts")]
    public class PostsController : Controller
    {
        private readonly HttpClient http;
        
        public PostsController(HttpClient http)
        {
            this.http = http;
        }
        
        [HttpPost]
        public Task CreateAsync()
        {
            return this.http.Proxy(this.HttpContext, "posts");
        } 
    }
}