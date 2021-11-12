FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["InvoiceGenerator.WebApi/InvoiceGenerator.WebApi.csproj", "InvoiceGenerator.WebApi/"]
RUN dotnet restore "InvoiceGenerator.WebApi/InvoiceGenerator.WebApi.csproj"
COPY . .
WORKDIR "/src/InvoiceGenerator.WebApi"
RUN dotnet build "InvoiceGenerator.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "InvoiceGenerator.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "InvoiceGenerator.WebApi.dll"]
