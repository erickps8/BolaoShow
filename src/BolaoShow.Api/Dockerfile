#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
EXPOSE 5000
ENV ASPNETCORE_URLS=https://+:50000;https://+:443;http://+:80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/BolaoShow.Api/BolaoShow.Api.csproj", "src/BolaoShow.Api/"]
COPY ["src/BolaoShow.Bussiness/BolaoShow.Bussiness.csproj", "src/BolaoShow.Bussiness/"]
COPY ["src/BolaoShow.Data/BolaoShow.Data.csproj", "src/BolaoShow.Data/"]
RUN dotnet restore "src/BolaoShow.Api/BolaoShow.Api.csproj"
COPY . .
WORKDIR "/src/src/BolaoShow.Api"
RUN dotnet build "BolaoShow.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BolaoShow.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BolaoShow.Api.dll"]
