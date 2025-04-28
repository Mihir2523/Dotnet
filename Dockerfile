# Use the official .NET 8.0 SDK image for building
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Set the working directory inside the container
WORKDIR /app

# Copy everything to /app
COPY . .

# Restore NuGet packages
RUN dotnet restore

# Build the project - assumes .csproj file is named Project.csproj
RUN dotnet publish -c Release -o out

# Use the official .NET 8.0 runtime image for running
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime

# Set working directory inside runtime container
WORKDIR /app

# Copy published output from the build container
COPY --from=build /app/out .

# Expose port 80 to the outside
EXPOSE 80

# Tell ASP.NET Core to listen on port 80
ENV ASPNETCORE_URLS=http://+:80

# Set the entrypoint to run the app
ENTRYPOINT ["dotnet", "Project.dll"]
