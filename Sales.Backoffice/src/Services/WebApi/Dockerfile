# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copie os arquivos de projeto
COPY ./Sales.Backoffice.WebApi/Sales.Backoffice.WebApi.csproj Sales.Backoffice.WebApi/Sales.Backoffice.WebApi.csproj
COPY ./Sales.Backoffice.Dto/Sales.Backoffice.Dto.csproj Sales.Backoffice.Dto/Sales.Backoffice.Dto.csproj
COPY ./Sales.Backoffice.Model/Sales.Backoffice.Model.csproj Sales.Backoffice.Model/Sales.Backoffice.Model.csproj
COPY ./Sales.Backoffice.Repository/Sales.Backoffice.Repository.csproj Sales.Backoffice.Repository/Sales.Backoffice.Repository.csproj
COPY ./Sales.Backoffice.Application/Sales.Backoffice.Application.csproj Sales.Backoffice.Application/Sales.Backoffice.Application.csproj

# Restore, build e publish os projetos
RUN dotnet restore Sales.Backoffice.WebApi/Sales.Backoffice.WebApi.csproj
RUN dotnet build Sales.Backoffice.WebApi/Sales.Backoffice.WebApi.csproj -c Release -o /app/build
RUN dotnet publish Sales.Backoffice.WebApi/Sales.Backoffice.WebApi.csproj -c Release -o /app/publish

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 7001
ENTRYPOINT ["dotnet", "Sales.Backoffice.WebApi.dll"]
