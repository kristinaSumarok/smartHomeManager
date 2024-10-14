FROM mcr.microsoft.com/dotnet/sdk:8.0 AS dev

WORKDIR /app

COPY . .

CMD [ "dotnet", "watch", "run", "--project", "src/WebAPI/WebAPI.csproj", "--urls", "https://*:7185;http://*:8080" ]

EXPOSE 7185 8080
