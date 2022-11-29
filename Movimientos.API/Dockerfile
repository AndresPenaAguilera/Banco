#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Movimientos.API/Movimientos.API.csproj", "Movimientos.API/"]
COPY ["Movimientos.Modelos/Movimientos.Modelos.csproj", "Movimientos.Modelos/"]
RUN dotnet restore "Movimientos.API/Movimientos.API.csproj"
COPY . .
WORKDIR "/src/Movimientos.API"
RUN dotnet build "Movimientos.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Movimientos.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Movimientos.API.dll"]