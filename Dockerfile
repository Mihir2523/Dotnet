# Stage 1: Build the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy everything into container
COPY . .

# Restore dependencies
RUN dotnet restore

# Build and publish the application to the /out directory
RUN dotnet publish -c Release -o out

# Stage 2: Create a smaller runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Copy the published app from build stage
COPY --from=build /app/out ./

# Expose port 80 for the API
EXPOSE 80

# Set environment variable so app listens on port 80
ENV ASPNETCORE_URLS=http://+:80

# Command to run the application
ENTRYPOINT ["dotnet", "Dotnet.dll"]
