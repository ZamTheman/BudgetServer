FROM mcr.microsoft.com/dotnet/aspnet:5.0.8-buster-slim-arm32v7 AS base
WORKDIR /app
EXPOSE 5000

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["FBS.Controllers/FBS.Controllers.csproj", "FBS.Controllers/"]
COPY ["FBS.BusinessLogic/FBS.BusinessLogic.csproj", "FBS.BusinessLogic/"]
COPY ["FBS.DataAccess/FBS.DataAccess.csproj", "FBS.DataAccess/"]
RUN dotnet restore "FBS.Controllers/FBS.Controllers.csproj"
COPY . .
WORKDIR "/src/FBS.Controllers"
RUN dotnet build "FBS.Controllers.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FBS.Controllers.csproj" -c Release -r linux-arm -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FBS.Controllers.dll"]
