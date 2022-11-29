#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Cuentas.API/Cuentas.API.csproj", "Cuentas.API/"]
COPY ["Cuentas.Aplicacion/Cuentas.Aplicacion.csproj", "Cuentas.Aplicacion/"]
COPY ["Cuentas.Interfaces/Cuentas.Interfaces.csproj", "Cuentas.Interfaces/"]
COPY ["Cuentas.Modelos/Cuentas.Modelos.csproj", "Cuentas.Modelos/"]
RUN dotnet restore "Cuentas.API/Cuentas.API.csproj"
COPY . .
WORKDIR "/src/Cuentas.API"
RUN dotnet build "Cuentas.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Cuentas.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Cuentas.API.dll"]