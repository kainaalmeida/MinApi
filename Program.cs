using Microsoft.EntityFrameworkCore;
using MinApi.Data;
using MinApi.Models;
using System.Linq;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MinApiDbContext>(options => options.UseInMemoryDatabase("Pessoas"));

await using var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseSwagger();

app.MapGet("/", () => "Hello World!");

app.MapGet("/pessoas", async (MinApiDbContext dbContext) => await dbContext.Pessoas.ToListAsync());

app.MapPost("/pessoas", async (Pessoa pessoa, MinApiDbContext dbContext) =>
{
    dbContext.Pessoas.Add(pessoa);
    await dbContext.SaveChangesAsync();

    return pessoa;
});

app.UseSwaggerUI();
await app.RunAsync();
