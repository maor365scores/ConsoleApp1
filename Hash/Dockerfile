FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Hash/Hash.csproj", "Hash/"]
RUN dotnet restore "Hash/Hash.csproj"
COPY . .
WORKDIR "/src/Hash"
RUN dotnet build "Hash.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Hash.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Hash.dll"]
