# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 4444

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ApiGateway/PDApiGateway/PDApiGateway.csproj", "ApiGateway/PDApiGateway/"]
COPY ["Services/Auth/JwtConfiguration/JwtConfiguration.csproj", "Services/Auth/JwtConfiguration/"]
RUN dotnet restore "./ApiGateway/PDApiGateway/PDApiGateway.csproj"
COPY . .
WORKDIR "/src/ApiGateway/PDApiGateway"
RUN dotnet build "./PDApiGateway.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./PDApiGateway.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PDApiGateway.dll"]