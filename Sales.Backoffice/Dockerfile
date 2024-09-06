FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copiar csproj e restaurar dependencias
#
COPY *.sln .
COPY ./src/Services/WebApi/Sales.Backoffice.WebApi/*.csproj ./src/Services/WebApi/Sales.Backoffice.WebApi/
COPY ./src/Services/WebApi/Sales.Backoffice.Dto/*.csproj ./src/Services/WebApi/Sales.Backoffice.Dto/
COPY ./src/Services/WebApi/Sales.Backoffice.Model/*.csproj ./src/Services/WebApi/Sales.Backoffice.Model/
COPY ./src/Services/WebApi/Sales.Backoffice.Repository/*.csproj ./src/Services/WebApi/Sales.Backoffice.Repository/
COPY ./src/Services/WebApi/Sales.Backoffice.Application/*.csproj ./src/Services/WebApi/Sales.Backoffice.Application/


# Build da aplicacao
COPY . ./
RUN dotnet publish -c Release -o out

# Build da imagem
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT ["dotnet", "Sales.Backoffice.WebApi.dll"]