#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Clientes.API/Clientes.API.csproj", "Clientes.API/"]
COPY ["Clientes.Aplicacion/Clientes.Aplicacion.csproj", "Clientes.Aplicacion/"]
COPY ["Clientes.Interfaces/Clientes.Interfaces.csproj", "Clientes.Interfaces/"]
COPY ["Clientes.Modelos/Clientes.Modelos.csproj", "Clientes.Modelos/"]
RUN dotnet restore "Clientes.API/Clientes.API.csproj"
COPY . .
WORKDIR "/src/Clientes.API"
RUN dotnet build "Clientes.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Clientes.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Clientes.API.dll"]