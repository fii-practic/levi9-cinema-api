#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM public.ecr.aws/v5g1m8f0/aspnet:6.0 AS base
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
ENV DOTNET_EnableDiagnostics=0
ENTRYPOINT ["dotnet", "Levi9.Cinema.Api.dll"]
