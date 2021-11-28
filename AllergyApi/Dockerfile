FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY AllergyApi.csproj .
RUN dotnet restore AllergyApi.csproj
COPY . .
WORKDIR /src
RUN dotnet build "AllergyApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "/src/AllergyApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AllergyApi.dll"]