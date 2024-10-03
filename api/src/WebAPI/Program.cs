using Homemap.ApplicationCore;
using Homemap.ApplicationCore.Interfaces.Seeders;
using Homemap.Infrastructure.Data;
using Homemap.Infrastructure.Data.Contexts;
using Homemap.Infrastructure.Data.Seeds;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddDatabase(builder.Configuration)
    .AddRepositories()
    .AddMappers()
    .AddApplicationServices()
    .AddEndpointsApiExplorer()
    .AddSwaggerGen()
    .AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    // add swagger
    app.UseSwagger().UseSwaggerUI(opts =>
    {
        opts.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        opts.RoutePrefix = string.Empty;
    });

    // seed database
    using var scope = app.Services.CreateScope();
    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

    new List<ISeeder>
    {
        new ProjectSeeder(context),
        new ReceiverSeeder(context)
    }.ForEach(async seeder => await seeder.SeedAsync());
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
