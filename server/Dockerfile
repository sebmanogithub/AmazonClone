FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0-alpine AS build
WORKDIR /src
COPY ["Amazon.Clone.API/Amazon.Clone.API.csproj", "Amazon.Clone.API/"]
COPY ["Amazon.Clone.Core/Amazon.Clone.Core.csproj", "Amazon.Clone.Core/"]
COPY ["Amazon.Clone.Infrastructure/Amazon.Clone.Infrastructure.csproj", "Amazon.Clone.Infrastructure/"]
RUN dotnet restore "Amazon.Clone.API/Amazon.Clone.API.csproj"
COPY . .
WORKDIR "/src/Amazon.Clone.API"
RUN dotnet build "Amazon.Clone.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Amazon.Clone.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Amazon.Clone.API.dll"]