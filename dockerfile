# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy solution and restore dependencies
COPY ["BankingApp.sln", "."]
COPY ["src/Services/Banking.Identity.API/Banking.Identity.API.csproj", "src/Services/Banking.Identity.API/"]
COPY ["src/Services/Banking.Identity.Application/Banking.Identity.Application.csproj", "src/Services/Banking.Identity.Application/"]
COPY ["src/Services/Banking.Identity.Domain/Banking.Identity.Domain.csproj", "src/Services/Banking.Identity.Domain/"]
COPY ["src/Services/Banking.Identity.Infrastructure/Banking.Identity.Infrastructure.csproj", "src/Services/Banking.Identity.Infrastructure/"]

RUN dotnet restore "./BankingApp.sln"

# Copy the rest of the files and build
COPY . .
WORKDIR "/src/src/Services/Banking.Identity.API"
RUN dotnet publish -c Release -o /app/publish --no-restore

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Banking.Identity.API.dll"]
