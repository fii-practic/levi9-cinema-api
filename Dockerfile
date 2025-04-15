#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Levi9.Cinema.Api.csproj", "."]
RUN dotnet restore "./Levi9.Cinema.Api.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "Levi9.Cinema.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Levi9.Cinema.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
# Install curl for healthcheck
RUN apt-get update && apt-get install -y curl && rm -rf /var/lib/apt/lists/*
ENV DOTNET_EnableDiagnostics=0
ENTRYPOINT ["dotnet", "Levi9.Cinema.Api.dll"]
