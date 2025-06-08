FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/ZooHelp.API/ZooHelp.API.csproj", "src/ZooHelp.API/"]
COPY ["src/ZooHelp.Application/ZooHelp.Application.csproj", "src/ZooHelp.Application/"]
COPY ["src/ZooHelp.Domain/ZooHelp.Domain.csproj", "src/ZooHelp.Domain/"]
COPY ["src/ZooHelp.Infrastructure/ZooHelp.Infrastructure.csproj", "src/ZooHelp.Infrastructure/"]
RUN dotnet restore "src/ZooHelp.API/ZooHelp.API.csproj"
COPY . .
WORKDIR "/src/src/ZooHelp.API"
RUN dotnet build "./ZooHelp.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ZooHelp.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ZooHelp.API.dll"]
