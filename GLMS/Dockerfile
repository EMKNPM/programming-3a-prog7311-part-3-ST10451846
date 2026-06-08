FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy the entire solution folder
COPY . .

# Restore using the project file path
RUN dotnet restore GLMS/GLMS.csproj
RUN dotnet publish GLMS/GLMS.csproj -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "GLMS.dll"]