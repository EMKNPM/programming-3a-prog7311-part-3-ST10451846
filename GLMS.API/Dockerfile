FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy the entire solution folder from the root (context: .)
COPY . .

# Restore and publish the API project specifically
RUN dotnet restore "GLMS.API/GLMS.API.csproj"
RUN dotnet publish "GLMS.API/GLMS.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
# Ensure this matches the DLL name output by the API project
ENTRYPOINT ["dotnet", "GLMS.API.dll"]