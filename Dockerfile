# Etapa 1: Usar la imagen oficial del SDK de .NET 8 para compilar el proyecto
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /source

# Copiar el archivo de solución
COPY Iinventary.sln ./

# Copiar los archivos de proyecto
COPY Bbusiness/Bbusiness.csproj Bbusiness/
COPY DdataAccess/DdataAccess.csproj DdataAccess/
COPY Eentities/Eentities.csproj Eentities/
COPY Iinventary/Iinventary.csproj Iinventary/

# Restaurar dependencias
RUN dotnet restore

# Copiar el resto de los archivos del proyecto
COPY . ./

# Compilar el proyecto en modo Release
RUN dotnet publish -c Release -o /app

# Etapa 2: Usar la imagen del runtime de .NET 8 para ejecutar la aplicación
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Copiar los archivos compilados de la etapa de construcción
COPY --from=build /app .

# Exponer el puerto 80 para acceder a la aplicación web
EXPOSE 80

# Definir el comando de inicio de la aplicación
ENTRYPOINT ["dotnet", "Iinventary.dll"]