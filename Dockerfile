FROM mcr.microsoft.com/dotnet/sdk:6.0 AS base
WORKDIR /app

ENV ASPNETCORE_URLS=http://+:8080
ENV ASPNETCORE_ENVIRONMENT=Development

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Commerce.csproj", "./"]
RUN dotnet restore "Commerce.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "Commerce.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Commerce.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Commerce.dll"]
