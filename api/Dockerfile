FROM mcr.microsoft.com/dotnet/sdk:8.0 AS base

WORKDIR /app

COPY . .

FROM base AS dev

CMD [ "dotnet", "watch", "run", "--project", "src/WebAPI/WebAPI.csproj", "--urls", "https://*:7185;http://*:8080" ]
EXPOSE 7185 8080

FROM base AS build

RUN dotnet publish src/WebAPI/WebAPI.csproj -c Release -o .output

FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine AS prod

WORKDIR /app

COPY --from=build /app/.output .

# who knows what is this
RUN addgroup -S runner && adduser -S runner -G runner
USER runner

CMD ["dotnet", "Homemap.WebAPI.dll"]
EXPOSE 80
