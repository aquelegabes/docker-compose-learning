FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-alpine AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-alpine AS build
WORKDIR /src

COPY . .
RUN dotnet restore "./web/web.csproj"

COPY . .
WORKDIR "/src/."

RUN dotnet build "./web/web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "./web/web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app

COPY --from=publish /app/publish .
ENV ASPNETCORE_URLS http://*:5002
ENTRYPOINT [ "dotnet", "web.dll" ]