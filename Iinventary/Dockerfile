# Utiliza la imagen base para .NET 8 SDK
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiar el archivo .csproj de cada proyecto
COPY ../Bbusiness/Bbusiness.csproj ../Bbusiness/
COPY ../DdataAccess/DdataAccess.csproj ../DdataAccess/
COPY ../Eentities/Eentities.csproj ../Eentities/
COPY ../Iinventary/Iinventary.csproj .

# Restaurar dependencias para cada proyecto
RUN dotnet restore ../Iinventary.csproj
RUN dotnet restore ../Bbusiness/Bbusiness.csproj
RUN dotnet restore ../DdataAccess/DdataAccess.csproj
RUN dotnet restore ../Eentities/Eentities.csproj

# Copiar el resto de los archivos de los proyectos
COPY ../Bbusiness/ ../Bbusiness/
COPY ../DdataAccess/ ../DdataAccess/
COPY ../Eentities/ ../Eentities/
COPY . .

# Construir la aplicación
RUN dotnet build -c Release -o /app/build

# Publicar la aplicación
FROM build AS publish
RUN dotnet publish -c Release -o /app/publish

# Utilizar la imagen de runtime para ejecutar la app
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Iinventary.dll"]