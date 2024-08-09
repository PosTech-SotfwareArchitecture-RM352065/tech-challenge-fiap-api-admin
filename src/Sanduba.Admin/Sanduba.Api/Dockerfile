#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080

ENV ASPNETCORE_URLS=http://+:8080
ENV ASPNETCORE_ENVIRONMENT=Development
ENV ASPNETCORE_ConnectionStrings__AdminDatabase__Value=default
ENV ASPNETCORE_ConnectionStrings__AdminDatabase__Type=default
ENV ASPNETCORE_CustomerBrokerSettings__ConnectionString=default
ENV ASPNETCORE_CustomerBrokerSettings__TopicName=default
ENV ASPNETCORE_CustomerBrokerSettings__SubscriptionName=default
ENV ASPNETCORE_ProductBrokerSettings__ConnectionString=default

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Sanduba.Admin/Sanduba.Api/Sanduba.API.csproj", "Sanduba.Admin/Sanduba.Api/"]
COPY ["Sanduba.Admin/Sanduba.Adapter.Mvc/Sanduba.Adapter.Mvc.csproj", "Sanduba.Admin/Sanduba.Adapter.Mvc/"]
COPY ["Sanduba.Admin/Sanduba.Core.Application/Sanduba.Core.Application.csproj", "Sanduba.Admin/Sanduba.Core.Application/"]
COPY ["Sanduba.Admin/Sanduba.Core.Application.Abstraction/Sanduba.Core.Application.Abstraction.csproj", "Sanduba.Admin/Sanduba.Core.Application.Abstraction/"]
COPY ["Sanduba.Admin/Sanduba.Core.Domain/Sanduba.Core.Domain.csproj", "Sanduba.Admin/Sanduba.Core.Domain/"]
COPY ["Sanduba.Admin/Sanduba.Infrastructure.Broker.ServiceBus/Sanduba.Infrastructure.Broker.ServiceBus.csproj", "Sanduba.Admin/Sanduba.Infrastructure.Broker.ServiceBus/"]
COPY ["Sanduba.Admin/Sanduba.Infrastructure.Persistence.SqlServer/Sanduba.Infrastructure.Persistence.SqlServer.csproj", "Sanduba.Admin/Sanduba.Infrastructure.Persistence.SqlServer/"]
RUN dotnet restore "./Sanduba.Admin/Sanduba.Api/Sanduba.API.csproj"
COPY . .
WORKDIR "/src/Sanduba.Admin/Sanduba.Api"
RUN dotnet build "./Sanduba.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Sanduba.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Sanduba.API.dll"]