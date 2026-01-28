FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 9090
EXPOSE 9091

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["./eCommers.Api/eCommers.Api.csproj","eCommers.Api/"]
RUN dotnet restore "eCommers.Api/eCommers.Api.csproj"
COPY . .
WORKDIR /src/eCommers.Api
RUN dotnet build "./eCommers.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "./eCommers.Api.csproj" -c Release -o /app/publish /p:UserAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV POSTGRES_HOST=localhost
ENV POSTGRES_PASSWORD=admin
ENV POSTGRES_DATABASE=eCommersUsers
ENV POSTGRES_USER=postgres
ENV POSTGRES_PORT=5433

ENTRYPOINT ["dotnet","eCommers.Api.dll"]