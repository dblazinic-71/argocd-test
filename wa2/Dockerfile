#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 5068
ENV ASPNETCORE_ENVIRONMENT=Development
ENV ASPNETCORE_URLS=http://+:5068

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["wa2.csproj", "./"]
RUN dotnet restore "wa2.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "wa2.csproj" -c Release -o /app/build
#RUN apt-get update \
    #&& apt-get install -y --no-install-recommends unzip \
    #&& rm -rf /var/lib/apt/lists/* \
    #&& curl -sSL https://aka.ms/getvsdbgsh | \
       #bash /dev/stdin -v latest -l /vsdbg

FROM build AS publish
RUN dotnet publish "wa2.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "wa2.dll"]