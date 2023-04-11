using Astor.Proxy.ExampleApi;
using Astor.Proxy.ExampleApi.Controllers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(o => o.TokenValidationParameters = new()
    {
        ValidAudience = Jwt.Audience,
        ValidIssuer = Jwt.Issuer,
        IssuerSigningKey = new SymmetricSecurityKey(Jwt.KeyBytes),
    });

builder.Services.AddControllers();
builder.Services.AddHttpClient<GithubService>(cl =>
{
    cl.BaseAddress = new("http://api.github.com");
});

var app = builder.Build();
app.MapControllers();

app.Run();

public partial class Program { }