using Microsoft.EntityFrameworkCore;
using MinApi.Data;
using MinApi.Models;
using Microsoft.AspNetCore;
using MinApi.Repository.Pessoas;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<MinApiDbContext>();
builder.Services.AddScoped<PessoaRepository>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<MinApiDbContext>(options => options.UseInMemoryDatabase("Pessoas"));


await using var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseSwagger();

app.MapGet("/pessoas", async (PessoaRepository repository) =>
{
    var result = await repository.ObterTodos();
    return Results.Ok(result);
});

app.MapPost("/pessoas", async (PessoaRepository repository, Pessoa pessoa) =>
{
    var result = await repository.Adicionar(pessoa);
    return result;
});

app.UseSwaggerUI();
await app.RunAsync();
