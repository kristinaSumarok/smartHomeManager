using Homemap.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddDatabase(builder.Configuration)
    .AddRepositories();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
