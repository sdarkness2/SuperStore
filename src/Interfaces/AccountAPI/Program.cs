using AccountAPI.EndPoints;
using Account.Services;
using AccountAPI;

var builder = WebApplication.CreateBuilder(args);

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.ConfigureApplication();
builder.Services.ConfigureApplicationServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapAccountEndPoints();

app.UseHttpsRedirection();

app.Run();