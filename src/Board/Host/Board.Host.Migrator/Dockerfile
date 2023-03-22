FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Board/Host/Board.Host.Migrator/Board.Host.Migrator.csproj", "Board.Host.Migrator/"]
RUN dotnet restore "src/Board/Host/Board.Host.Migrator/Board.Host.Migrator.csproj"
COPY . .
WORKDIR "/src/Board.Host.Migrator"
RUN dotnet build "Board.Host.Migrator.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Board.Host.Migrator.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Board.Host.Migrator.dll"]
