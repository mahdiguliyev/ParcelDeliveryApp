FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 1111

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Services/Parcel/Parcel.API/Parcel.API.csproj", "Services/Parcel/Parcel.API/"]
COPY ["Services/Auth/JwtConfiguration/JwtConfiguration.csproj", "Services/Auth/JwtConfiguration/"]
RUN dotnet restore "./Services/Parcel/Parcel.API/Parcel.API.csproj"
COPY . .
WORKDIR "/src/Services/Parcel/Parcel.API"
RUN dotnet build "./Parcel.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Parcel.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Parcel.API.dll"]