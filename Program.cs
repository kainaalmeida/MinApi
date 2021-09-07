using Microsoft.EntityFrameworkCore;
using MinApi.Data;
using MinApi.Extensions;
using MinApi.Apis;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpoints(typeof(PessoaApi));
builder.Services.AddScoped<MinApiDbContext>();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<MinApiDbContext>(options => options.UseInMemoryDatabase("Pessoas"));


await using var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseEndpoints();
await app.RunAsync();
