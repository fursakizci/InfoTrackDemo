
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["PropertyNormalizer.API/PropertyNormalizer.API.csproj", "PropertyNormalizer.API/"]

RUN dotnet restore "PropertyNormalizer.API/PropertyNormalizer.API.csproj"

COPY . .
WORKDIR "/src/PropertyNormalizer.API"
RUN dotnet publish "PropertyNormalizer.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "PropertyNormalizer.API.dll"]