FROM mcr.microsoft.com/dotnet/sdk:8.0 AS base

WORKDIR /app

COPY . .

RUN dotnet tool install --global dotnet-ef
ENV PATH="$PATH:/root/.dotnet/tools"
RUN dotnet ef database update --project src/Infrastructure/Infrastructure.Data/Infrastructure.Data.csproj --startup-project src/WebAPI/WebAPI.csproj

FROM base AS dev

CMD [ "dotnet", "watch", "run", "--project", "src/WebAPI/WebAPI.csproj", "--urls", "https://*:7185;http://*:8080" ]
EXPOSE 7185 8080

FROM base AS build

RUN dotnet publish src/WebAPI/WebAPI.csproj -c Release -o .output

FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine AS prod

WORKDIR /app

COPY --from=build /app/.output .
COPY --from=build /app/src/WebAPI/data.db data.db

# make data.db writable
RUN chmod 777 .
RUN chmod 777 data.db

# who knows what is this
RUN addgroup -S runner && adduser -S runner -G runner
USER runner

CMD ["dotnet", "Homemap.WebAPI.dll"]
EXPOSE 80
