FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Api_Pokemon/Api_Pokemon.csproj", "Api_Pokemon/"]
RUN dotnet restore "Api_Pokemon/Api_Pokemon.csproj"
COPY . .
WORKDIR "/src/Api_Pokemon"
RUN dotnet build "Api_Pokemon.csproj" -c Release -o /app/build
FROM build AS publish
RUN dotnet publish "Api_Pokemon.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
EXPOSE 8080
ENTRYPOINT ["dotnet", "Api_Pokemon.dll"]
