#FROM microsoft/aspnetcore-build:1.0-2.0 AS base
#WORKDIR /app
#EXPOSE 40001

FROM microsoft/aspnetcore-build:1.0-2.0 AS build
WORKDIR /app
#COPY SpyStore.MVC/SpyStore.MVC.csproj SpyStore.MVC/
COPY SpyStore.MVC.csproj ./
#RUN dotnet restore SpyStore.MVC/SpyStore.MVC.csproj
#RUN dotnet restore
COPY . ./
COPY Nuget.Config ./
#RUN dotnet build SpyStore.MVC.csproj -c Release -o /app
RUN dotnet publish -c Release -o out

#FROM build AS publish
#RUN dotnet publish SpyStore.MVC.csproj -c Release -o /app

#FROM base AS final
#WORKDIR /app
#COPY /app/out .
ENTRYPOINT ["dotnet", "out/SpyStore.MVC.dll"]