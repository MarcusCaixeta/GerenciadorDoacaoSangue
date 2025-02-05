
using GerenciadorDoacaoSangue.API;
using GerenciadorDoacaoSangue.Application;
using GerenciadorDoacaoSangue.Infrastructure;
using GerenciadorDoacaoSangue.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddDbContext<GerenciadorDoacaoSangueDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("GerenciadorDoacaoSangueDb")));


builder.Services
    .AddApplication()
    .AddInfrastructure();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapearRotas();
    
await app.RunAsync();
