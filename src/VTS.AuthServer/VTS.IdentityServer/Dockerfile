#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["VTS.AuthServer/VTS.IdentityServer/VTS.IdentityServer.csproj", "VTS.AuthServer/VTS.IdentityServer/"]
RUN dotnet restore "VTS.AuthServer/VTS.IdentityServer/VTS.IdentityServer.csproj"
COPY . .
WORKDIR "/src/VTS.AuthServer/VTS.IdentityServer"
RUN dotnet build "VTS.IdentityServer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "VTS.IdentityServer.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "VTS.IdentityServer.dll"]