# Usa la imagen del SDK de .NET para construir
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /source

# Copia el archivo de solución
COPY Iinventary.sln ./

# Copia los archivos de proyecto de las bibliotecas
COPY Bbusiness/Bbusiness.csproj Bbusiness/
COPY DdataAccess/DdataAccess.csproj DdataAccess/
COPY Eentities/Eentities.csproj Eentities/
COPY Iinventary/Iinventary.csproj Iinventary/

# Restaura las dependencias
RUN dotnet restore

# Copia el resto del código fuente
COPY . .

# Construye el proyecto
RUN dotnet build Inventary/Iinventary.csproj -c Release -o /app/build

# Usa la imagen del runtime de .NET para ejecutar la aplicación
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/build .

# Establece el punto de entrada para la aplicación
ENTRYPOINT ["dotnet", "Iinventary.dll"]
