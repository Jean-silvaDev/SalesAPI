# Imagem de build
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Copia a solução
COPY ../*.sln ./

# Copia os projetos
COPY ../Application/Application.csproj Application/
COPY ../Domain/Domain.csproj Domain/
COPY ../Infrastructure/Infrastructure.csproj Infrastructure/
COPY ./*.csproj Presentation/

# Restaura dependências
RUN dotnet restore

# Copia todo o código
COPY . .
WORKDIR /src/Presentation
RUN dotnet publish -c Release -o /app/publish

# Publica
WORKDIR /src/Presentation
RUN dotnet publish -c Release -o /app/publish

# Imagem de runtime
FROM mcr.microsoft.com/dotnet/aspnet:10.0
WORKDIR /app
COPY --from=build /app/publish .

EXPOSE 8080
ENTRYPOINT ["dotnet", "Presentation.dll"]
