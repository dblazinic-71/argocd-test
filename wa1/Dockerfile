FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 5001
ENV ASPNETCORE_ENVIRONMENT=Development
ENV ASPNETCORE_URLS=http://+:5001

# Creates a non-root user with an explicit UID and adds permission to access the /app folder
# For more info, please refer to https://aka.ms/vscode-docker-dotnet-configure-containers
RUN adduser -u 5678 --disabled-password --gecos "" appuser && chown -R appuser /app
USER appuser

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["wa1.csproj", "./"]
RUN dotnet restore "wa1.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "wa1.csproj" -c Release -o /app/build
#RUN apt-get update \
    #&& apt-get install -y --no-install-recommends unzip \
    #&& rm -rf /var/lib/apt/lists/* \
    #&& curl -sSL https://aka.ms/getvsdbgsh | \
       #bash /dev/stdin -v latest -l /vsdbg

FROM build AS publish
RUN dotnet publish "wa1.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "wa1.dll"]
