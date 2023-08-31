# Use the official Microsoft ASP.NET Core runtime image
# This image contains the .NET Core runtime and ASP.NET Core runtime
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

# Use the SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["JokeWebApp.csproj", "./"] # Replace 'JokeWebApp.csproj' with your project name if different
RUN dotnet restore "./JokeWebApp.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "JokeWebApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "JokeWebApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "JokeWebApp.dll"] # Replace 'JokeWebApp.dll' with your output DLL name if different
