using Microsoft.EntityFrameworkCore;
using MinApi.Data;
using MinApi.Extensions;
using MinApi.Apis;
using MinApi.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpoints(typeof(PessoaApi));

builder.Services.AddScoped<MinApiDbContext>();
builder.Services.AddScoped<TokenService>();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<MinApiDbContext>(options => options.UseInMemoryDatabase("Pessoas"));

builder.Services.AddAuthorization();
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["SecretKey"])),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

await using var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseEndpoints();

await app.RunAsync();
