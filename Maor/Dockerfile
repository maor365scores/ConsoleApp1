FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Maor/Maor.csproj", "Maor/"]
RUN dotnet restore "Maor/Maor.csproj"
COPY . .
WORKDIR "/src/Maor"
RUN dotnet build "Maor.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Maor.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Maor.dll"]
