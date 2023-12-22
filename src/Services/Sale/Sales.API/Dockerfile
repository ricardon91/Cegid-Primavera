#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Services/Sale/Sales.API/Sales.API.csproj", "Services/Sale/Sales.API/"]
COPY ["Services/Sale/Sales.Application/Sales.Application.csproj", "Services/Sale/Sales.Application/"]
COPY ["Services/Sale/Sales.Domain/Sales.Domain.csproj", "Services/Sale/Sales.Domain/"]
COPY ["Services/Sale/Sales.Infrastructure/Sales.Infrastructure.csproj", "Services/Sale/Sales.Infrastructure/"]
RUN dotnet restore "Services/Sale/Sales.API/Sales.API.csproj"
COPY . .
WORKDIR "/src/Services/Sale/Sales.API"
RUN dotnet build "Sales.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Sales.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Sales.API.dll"]