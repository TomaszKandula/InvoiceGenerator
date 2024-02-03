# ======================================================================================================================
# 1 - BUILD PROJECTS AND RUN TESTS
# ======================================================================================================================

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS PROJECTS

WORKDIR /app
COPY . ./

# RESTORE & BUILD
RUN dotnet restore --disable-parallel
RUN dotnet build -c Release --force
RUN dotnet test -c Release --no-build --no-restore

# ======================================================================================================================
# 2 - BUILD DOCKER IMAGE
# ======================================================================================================================

FROM mcr.microsoft.com/dotnet/sdk:6.0

WORKDIR /app

# BACKEND
COPY --from=PROJECTS "/app/InvoiceGenerator.Backend/InvoiceGenerator.Backend.Core/bin/Release/net6.0" .
COPY --from=PROJECTS "/app/InvoiceGenerator.Backend/InvoiceGenerator.Backend.Cqrs/bin/Release/net6.0" .
COPY --from=PROJECTS "/app/InvoiceGenerator.Backend/InvoiceGenerator.Backend.Database/bin/Release/net6.0" .
COPY --from=PROJECTS "/app/InvoiceGenerator.Backend/InvoiceGenerator.Backend.Domain/bin/Release/net6.0" .
COPY --from=PROJECTS "/app/InvoiceGenerator.Backend/InvoiceGenerator.Backend.Shared/bin/Release/net6.0" .

# SERVICES
COPY --from=PROJECTS "/app/InvoiceGenerator.Services/InvoiceGenerator.Services.BatchService/bin/Release/net6.0" .
COPY --from=PROJECTS "/app/InvoiceGenerator.Services/InvoiceGenerator.Services.BehaviourService/bin/Release/net6.0" .
COPY --from=PROJECTS "/app/InvoiceGenerator.Services/InvoiceGenerator.Services.TemplateService/bin/Release/net6.0" .
COPY --from=PROJECTS "/app/InvoiceGenerator.Services/InvoiceGenerator.Services.UserService/bin/Release/net6.0" .
COPY --from=PROJECTS "/app/InvoiceGenerator.Services/InvoiceGenerator.Services.VatService/bin/Release/net6.0" .

# WEBAPI
COPY --from=PROJECTS "/app/InvoiceGenerator.WebApi/bin/Release/net6.0" .

ENV ASPNETCORE_URLS=http://+:80
EXPOSE 80
ENTRYPOINT ["dotnet", "InvoiceGenerator.WebApi.dll"]
