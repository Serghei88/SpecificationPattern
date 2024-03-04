FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Specification Design Pattern/Specification Design Pattern.csproj", "Specification Design Pattern/"]
RUN dotnet restore "Specification Design Pattern/Specification Design Pattern.csproj"
COPY . .
WORKDIR "/src/Specification Design Pattern"
RUN dotnet build "Specification Design Pattern.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Specification Design Pattern.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Specification Design Pattern.dll"]
