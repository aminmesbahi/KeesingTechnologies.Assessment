#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/KeesingTechnologies.Assessment.CalendarService.Api/KeesingTechnologies.Assessment.CalendarService.Api.csproj", "src/KeesingTechnologies.Assessment.CalendarService.Api/"]
RUN dotnet restore "src/KeesingTechnologies.Assessment.CalendarService.Api/KeesingTechnologies.Assessment.CalendarService.Api.csproj"
COPY . .
WORKDIR "/src/src/KeesingTechnologies.Assessment.CalendarService.Api"
RUN dotnet build "KeesingTechnologies.Assessment.CalendarService.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "KeesingTechnologies.Assessment.CalendarService.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "KeesingTechnologies.Assessment.CalendarService.Api.dll"]