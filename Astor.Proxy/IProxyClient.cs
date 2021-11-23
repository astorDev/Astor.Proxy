using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Astor.Proxy
{
    public interface IProxyClient
    {
        Task ForwardAsync(HttpContext context, string route);
    }
}