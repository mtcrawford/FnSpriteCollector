# ======================
# Build Stage
# ======================
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Copy solution and project files
COPY ["FNSpriteCollector.slnx", "./"]

COPY ["src/FNSpriteCollector/FNSpriteCollector.csproj", "src/FNSpriteCollector/"]
COPY ["src/FNSpriteCollector.Shared/FNSpriteCollector.Shared.csproj", "src/FNSpriteCollector.Shared/"]

# Restore
RUN dotnet restore "FNSpriteCollector.slnx"

# Copy source and publish
COPY . .
WORKDIR "/src/src/FNSpriteCollector"
RUN dotnet publish -c Release -o /app/publish --no-restore

# ======================
# Runtime Stage (Nginx)
# ======================
FROM nginx:alpine AS final

# Copy the published Blazor static files
COPY --from=build /app/publish/wwwroot /usr/share/nginx/html

# Copy custom nginx config (optional but recommended)
#COPY nginx.conf /etc/nginx/conf.d/default.conf

EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]

