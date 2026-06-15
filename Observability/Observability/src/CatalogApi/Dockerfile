#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/CatalogApi/CatalogApi.csproj", "src/CatalogApi/"]
COPY ["src/Log.Library/Log.Library.csproj", "src/Log.Library/"]
RUN dotnet restore "src/CatalogApi/CatalogApi.csproj"
COPY . .
WORKDIR "/src/src/CatalogApi"
RUN dotnet build "CatalogApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CatalogApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CatalogApi.dll"]
