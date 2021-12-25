FROM mcr.microsoft.com/dotnet/sdk:6.0 AS installer-env
WORKDIR /app

COPY . ./
RUN dotnet restore

RUN mkdir -p /home/site/wwwroot 
RUN dotnet publish --output /home/site/wwwroot

FROM mcr.microsoft.com/azure-functions/dotnet:4.0
ENV AzureWebJobsScriptRoot=/home/site/wwwroot \
    AzureFunctionsJobHost__Logging__Console__IsEnabled=true

COPY --from=installer-env ["/home/site/wwwroot", "/home/site/wwwroot"]
