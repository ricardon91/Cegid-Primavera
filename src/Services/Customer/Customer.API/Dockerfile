#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Services/Customer/Customer.API/Customers.API.csproj", "src/Services/Customer/Customer.API/"]
COPY ["src/Services/Customer/Customer.Application/Customers.Application.csproj", "src/Services/Customer/Customer.Application/"]
COPY ["src/Services/Customer/Customer.Domain/Customers.Domain.csproj", "src/Services/Customer/Customer.Domain/"]
COPY ["src/Services/Customer/Customer.Infrastructure/Customers.Infrastructure.csproj", "src/Services/Customer/Customer.Infrastructure/"]
RUN dotnet restore "src/Services/Customer/Customer.API/Customers.API.csproj"
COPY . .
WORKDIR "/src/src/Services/Customer/Customer.API"
RUN dotnet build "Customers.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Customers.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Customers.API.dll"]