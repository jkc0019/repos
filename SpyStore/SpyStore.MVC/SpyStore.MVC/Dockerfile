FROM microsoft/aspnetcore:2.0-nanoserver-1709 AS base
WORKDIR /app
EXPOSE 40001

FROM microsoft/aspnetcore-build:2.0-nanoserver-1709 AS build
WORKDIR /src
COPY SpyStore.MVC/SpyStore.MVC.csproj SpyStore.MVC/
RUN dotnet restore SpyStore.MVC/SpyStore.MVC.csproj
COPY . .
WORKDIR /src/SpyStore.MVC
RUN dotnet build SpyStore.MVC.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish SpyStore.MVC.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "SpyStore.MVC.dll"]
