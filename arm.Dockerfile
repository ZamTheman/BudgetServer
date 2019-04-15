FROM microsoft/dotnet:sdk AS build-env
WORKDIR /app

RUN mkdir /output

# Copy project and publish

COPY . /app

WORKDIR /app/FBS.Controllers
RUN dotnet publish --configuration Debug --output /output -r linux-arm

# Build runtime image
FROM microsoft/dotnet:aspnetcore-runtime

ENV ASPNETCORE_URLS http://*:8080

WORKDIR /app

COPY --from=build-env /output .
EXPOSE 8080

ENTRYPOINT ["dotnet", "FBS.Controllers.dll"]