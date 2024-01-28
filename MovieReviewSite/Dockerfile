FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["MovieReviewSite/MovieReviewSite.csproj", "MovieReviewSite/"]
RUN dotnet restore "MovieReviewSite/MovieReviewSite.csproj"
COPY . .
WORKDIR "/src/MovieReviewSite"
RUN dotnet build "MovieReviewSite.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MovieReviewSite.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MovieReviewSite.dll"]
