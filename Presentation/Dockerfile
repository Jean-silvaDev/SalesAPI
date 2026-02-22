# ---------- Build ----------
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Copia solution
COPY *.sln .

# Copia projetos
COPY Domain/ Domain/
COPY Application/ Application/
COPY Infrastructure/ Infrastructure/
COPY Presentation/ Presentation/

# Restore
RUN dotnet restore Presentation/Presentation.csproj

# Publish
RUN dotnet publish Presentation/Presentation.csproj -c Release -o /app/publish

# ---------- Runtime ----------
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

COPY --from=build /app/publish .

EXPOSE 8080
ENTRYPOINT ["dotnet", "Presentation.dll"]