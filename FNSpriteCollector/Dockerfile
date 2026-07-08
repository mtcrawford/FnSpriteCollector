# Build the Blazor WebAssembly app
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /app

COPY . ./

# Publish the app
RUN dotnet publish -c Release -o /app/publish

# Final lightweight image
FROM nginx:alpine

# Copy the published static files
COPY --from=build /app/publish/wwwroot /usr/share/nginx/html

# Expose port 80
EXPOSE 80

# Start nginx
CMD ["nginx", "-g", "daemon off;"]