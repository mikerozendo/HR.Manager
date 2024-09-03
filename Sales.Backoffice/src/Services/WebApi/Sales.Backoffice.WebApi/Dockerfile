# Utiliza a imagem base do ASP.NET Core para a execução
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081
EXPOSE 7000

# Utiliza a imagem do SDK do .NET Core para compilar e publicar o aplicativo
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR src

# Copia o arquivo de projeto e restaura as dependências
RUN dotnet restore "src/Sales.Backoffice.WebApi/Sales.Backoffice.WebApi.csproj"

# Copia todos os arquivos para o contêiner e compila o aplicativo
COPY . .
WORKDIR "/src/Sales.Backoffice.WebApi"
RUN dotnet build "Sales.Backoffice.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publica o aplicativo para o diretório /app/publish
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Sales.Backoffice.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Configuração final para execução da aplicação no contêiner
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Sales.Backoffice.WebApi.dll"]
