#FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
#COPY . /app
#WORKDIR /app/src/Board/Host/Board.Host.Migrator
#RUN dotnet restore "Board.Host.Migrator.csproj"
#RUN dotnet publish "Board.Host.Migrator.csproj" -c Release -o /app/publish
#
#FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
#WORKDIR /app
#COPY --from=build /app/publish .
#ENTRYPOINT ["dotnet", "Board.Host.Migrator.dll"]
#


FROM mcr.microsoft.com/dotnet/sdk:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
COPY . /app
WORKDIR /app/src/Board/Host/Board.Host.Migrator
RUN dotnet restore Board.Host.Migrator.csproj
RUN dotnet build Board.Host.Migrator.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Board.Host.Migrator.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Board.Host.Migrator.dll"]