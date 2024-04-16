

FROM gcr.io/google-appengine/aspnetcore:2.0
ADD ./ /app
ENV ASPNETCORE_URLS=http://*:${PORT}
WORKDIR /app
ENTRYPOINT ["dotnet", "COMP2139_Assignment1_Nigar_Anar_Adler.dll"]

# Use the official .NET SDK image to build the project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# Copy the CSPROJ file and restore any dependencies (via NUGET)
COPY ["COMP2139_Assignment1_Nigar_Anar_Adler.csproj", "./"]
RUN dotnet restore

# Copy the project files and build the release
COPY . ./
RUN dotnet build "COMP2139_Assignment1_Nigar_Anar_Adler.csproj" -c Release -o /out

# Publish the application
FROM build-env AS publish
RUN dotnet publish "COMP2139_Assignment1_Nigar_Anar_Adler.csproj" -c Release -o /out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=publish /out .
ENTRYPOINT ["dotnet", "COMP2139_Assignment1_Nigar_Anar_Adler.dll"]
