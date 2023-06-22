#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Kaizen_final/Kaizen_final.csproj", "Kaizen_final/"]
RUN dotnet restore "Kaizen_final/Kaizen_final.csproj"
COPY . .
WORKDIR "/src/Kaizen_final"
RUN dotnet build "Kaizen_final.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Kaizen_final.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Kaizen_final.dll"]