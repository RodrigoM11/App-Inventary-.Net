# Use the SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /source

# Copy project files
COPY ../Iinventary.sln ./
COPY ../Bbusiness/Bbusiness.csproj Bbusiness/
COPY ../DdataAccess/DdataAccess.csproj DdataAccess/
COPY ../Eentities/Eentities.csproj Eentities/
COPY ../Iinventary/Iinventary.csproj Iinventary/

# Restore dependencies
RUN dotnet restore

# Copy the rest of your source code
COPY .. .

# Build the app
RUN dotnet publish Iinventary/Iinventary.csproj -c Release -o /app

# Use the runtime image to serve the app
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app .

ENTRYPOINT ["dotnet", "Iinventary.dll"]