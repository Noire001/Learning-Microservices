FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["PlatformService.csproj", "PlatformService/"]
WORKDIR "/src/PlatformService"
COPY . .

RUN dotnet publish "PlatformService.csproj" -c Release -o /app/publish

FROM build AS publish


FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PlatformService.dll"]
