FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80 

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["WTE.csproj", "."]
RUN dotnet restore "./././WTE.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "./WTE.csproj" -c $BUILD_CONFIGURATION -o /app/build
RUN dotnet publish "./WTE.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false


FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "WTE.dll"]