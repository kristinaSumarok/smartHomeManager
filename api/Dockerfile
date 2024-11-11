FROM mcr.microsoft.com/dotnet/sdk:8.0 AS dev

WORKDIR /app

COPY . .

CMD [ "dotnet", "watch", "run", "--project", "src/WebAPI/WebAPI.csproj", "--urls", "https://*:7185;http://*:8080" ]

EXPOSE 7185 8080

# TODO: make stages better
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /app

COPY . .

CMD [ "dotnet", "publish", "src/WebAPI/WebAPI.csproj", "-c", "Release", "-o", "/publish" ]

FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine AS prod

WORKDIR /app

COPY --from=build /publish .

EXPOSE 80

RUN addgroup -S runner && adduser -S runner -G runner
USER runner

ENTRYPOINT ["dotnet", "Homemap.WebAPI.dll"]
