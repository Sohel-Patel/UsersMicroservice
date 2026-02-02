FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

ENV ASPNETCORE_URLS=http://+:8080
ENV POSTGRES_HOST=localhost
ENV POSTGRES_PASSWORD=admin
ENV POSTGRES_DATABASE=eCommersUsers
ENV POSTGRES_USER=postgres
ENV POSTGRES_PORT=5433

USER app
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG configuration=Release
WORKDIR /src
COPY ["eCommers.Api/eCommers.Api.csproj", "eCommers.Api/"]
RUN dotnet restore "eCommers.Api/eCommers.Api.csproj"
COPY . .
WORKDIR "/src/eCommers.Api"
RUN dotnet build "eCommers.Api.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "eCommers.Api.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "eCommers.Api.dll"]
