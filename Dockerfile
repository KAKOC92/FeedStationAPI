

#FROM mcr.microsoft.com/dotnet/sdk:7.0 AS base
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

#RUN dotnet --info

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY FDAPI.csproj /src/FDAPI.csproj
RUN dotnet restore

COPY . .
WORKDIR /src
RUN dotnet build FDAPI.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish FDAPI.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "FDAPI.dll"]