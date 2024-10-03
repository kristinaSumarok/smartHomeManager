using Homemap.ApplicationCore;
using Homemap.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddDatabase(builder.Configuration)
    .AddRepositories()
    .AddMappers();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
