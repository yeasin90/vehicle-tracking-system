#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["VTS.Backend/VTS.Backend.Api/VTS.Backend.Api.csproj", "VTS.Backend/VTS.Backend.Api/"]
COPY ["VTS.Backend/VTS.Backend.Infrastructure.GoogleMapService/VTS.Backend.Infrastructure.GoogleMapService.csproj", "VTS.Backend/VTS.Backend.Infrastructure.GoogleMapService/"]
COPY ["VTS.Backend/VTS.Backend.Infrastructure.AuthServer/VTS.Backend.Infrastructure.AuthServer.csproj", "VTS.Backend/VTS.Backend.Infrastructure.AuthServer/"]
COPY ["VTS.Backend/VTS.Backend.Core.Application/VTS.Backend.Core.Application.csproj", "VTS.Backend/VTS.Backend.Core.Application/"]
COPY ["VTS.Backend/VTS.Backend.Core.Domain/VTS.Backend.Core.Domain.csproj", "VTS.Backend/VTS.Backend.Core.Domain/"]
COPY ["VTS.Backend/VTS.Backend.Infrastructure.Persistence/VTS.Backend.Infrastructure.Persistence.csproj", "VTS.Backend/VTS.Backend.Infrastructure.Persistence/"]
RUN dotnet restore "VTS.Backend/VTS.Backend.Api/VTS.Backend.Api.csproj"
COPY . .
WORKDIR "/src/VTS.Backend/VTS.Backend.Api"
RUN dotnet build "VTS.Backend.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "VTS.Backend.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "VTS.Backend.Api.dll"]