# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy everything into the build container
COPY ./WhatsForDinnerApi ./WhatsForDinnerApi
WORKDIR /src/WhatsForDinnerApi

RUN dotnet restore WhatsForDinnerApi.csproj
RUN dotnet publish -c Release -o /app/publish

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .

EXPOSE 8080
ENTRYPOINT ["dotnet", "WhatsForDinnerApi.dll"]
