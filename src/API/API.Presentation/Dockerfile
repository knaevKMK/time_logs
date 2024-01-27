FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["API.Presentation/API.Presentation.csproj", "API.Presentation/"]
RUN dotnet restore "API.Presentation/API.Presentation.csproj"
COPY . .
WORKDIR "/src/API.Presentation"
RUN dotnet build "API.Presentation.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "API.Presentation.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "API.Presentation.dll"]
