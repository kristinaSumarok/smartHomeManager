# ASP.NET Core Empty

Look how to [create web APIs with ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/web-api/?view=aspnetcore-8.0) to learn more.

## Setup

Make sure to restore dependencies and tools:

```bash
dotnet restore
```

Apply migrations:

```bash
dotnet ef database update --project ../Infrastructure/Infrastructure.Data/Infrastructure.Data.csproj
```

## Development Server

Start the development server:

```bash
dotnet run
```

[comment]: <> (TODO: Add  instructions on how to build for production)

## Visual Studio users
Open solution `api.sln`

Open Package Manager Console (PMC)

Select `Infrastructure.Data` (not `WebAPI`) project for PMC

Run `update-database` in PMC

Launch the solution using `https`
