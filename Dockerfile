FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0-alpine AS build

COPY Directory.Packages.props tmp/build/Directory.Packages.props

COPY src /tmp/build/src

WORKDIR "/tmp/build/src/EVChargingPort.API.API"
RUN dotnet restore -r linux-musl-x64 /p:PublishReadyToRun=true
RUN dotnet build "EVChargingPort.API.API.csproj" -c Release -o /app/build -r linux-musl-x64 /p:PublishReadyToRun=true
FROM build AS publish
RUN dotnet publish "EVChargingPort.API.API.csproj" -c Release -o /app/publish --no-restore --framework net8.0 -r linux-musl-x64 --self-contained true /p:PublishTrimmed=true /p:PublishReadyToRun=true /p:PublishSingleFile=true
FROM base AS final
RUN apk add --no-cache tzdata
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["./EVChargingPort.API.API"]