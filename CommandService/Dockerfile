FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["CommandService.csproj", "CommandService/"]
WORKDIR "/src/CommandService"
COPY . .

RUN dotnet publish "CommandService.csproj" -c Release -o /app/publish

FROM build AS publish


FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CommandService.dll"]
