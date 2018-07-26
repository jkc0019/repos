FROM microsoft/aspnetcore:2.0-nanoserver-1709 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0-nanoserver-1709 AS build
WORKDIR /src
COPY ../SpyStore.Service/SpyStore.Service/SpyStore.Service.csproj ../SpyStore.Service/SpyStore.Service/
RUN dotnet restore ../SpyStore.Service/SpyStore.Service/SpyStore.Service.csproj
COPY . .
WORKDIR /src/../SpyStore.Service/SpyStore.Service
RUN dotnet build SpyStore.Service.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish SpyStore.Service.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "SpyStore.Service.dll"]
