FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /sgc_station
COPY . .
ENV - HTTP_METHOD=noredirect
ENTRYPOINT ["dotnet", "bin/Debug/net7.0/FDAPI.dll"]