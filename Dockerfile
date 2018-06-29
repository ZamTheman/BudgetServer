FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY . .
RUN dotnet restore FBS.Controllers/FBS.Controllers.csproj
COPY . .
WORKDIR /src/FBS.Controllers
RUN dotnet build FBS.Controllers.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish FBS.Controllers.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "FBS.Controllers.dll"]
