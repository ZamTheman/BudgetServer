FROM mcr.microsoft.com/dotnet/core/sdk AS build-env
WORKDIR /app

# Copy project and publish
COPY *.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet public -c Release -0 out -r linux-arm

FROM mcr.microsoft.com/dotnet/core/sdk
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "FBS.Controllers.dll"]
