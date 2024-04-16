# Step 1: Build the application using the official Microsoft .NET SDK image
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# Copy the CSPROJ file and restore any dependencies (via NUGET)
COPY ["COMP2139_Assignment1_Nigar_Anar_Adler.csproj", "./"]
RUN dotnet restore

# Copy the rest of the project files and build the application
COPY . ./
RUN dotnet build "COMP2139_Assignment1_Nigar_Anar_Adler.csproj" -c Release -o /out

# Publish the application
RUN dotnet publish "COMP2139_Assignment1_Nigar_Anar_Adler.csproj" -c Release -o /out

# Step 2: Build the runtime image using the official Microsoft .NET runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /out .

# Example of setting an environment variable in Dockerfile
ENV PORT=8080
EXPOSE $PORT


# Optional: Define a volume for persisting data and storing keys securely
VOLUME /root/.aspnet/DataProtection-Keys

# Configure the Docker container to run the application
ENTRYPOINT ["dotnet", "COMP2139_Assignment1_Nigar_Anar_Adler.dll"]
