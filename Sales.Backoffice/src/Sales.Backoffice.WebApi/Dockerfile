# Utiliza a imagem base do ASP.NET Core para a execu��o
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 7001

# Utiliza a imagem do SDK do .NET Core para compilar e publicar o aplicativo
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR src

# Copia o arquivo de projeto e restaura as depend�ncias
RUN dotnet restore "/src/Services/WebApi/Sales.Backoffice.WebApi/Sales.Backoffice.WebApi.csproj"

# Copia todos os arquivos para o cont�iner e compila o aplicativo
COPY . .
WORKDIR "/src/Sales.Backoffice.WebApi"
RUN dotnet build "Sales.Backoffice.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publica o aplicativo para o diret�rio /app/publish
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Sales.Backoffice.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Configura��o final para execu��o da aplica��o no cont�iner
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Sales.Backoffice.WebApi.dll"]
