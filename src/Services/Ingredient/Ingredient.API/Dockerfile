#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Services/Ingredient/Ingredient.API/Ingredient.API.csproj", "Services/Ingredient/Ingredient.API/"]
RUN dotnet restore "Services/Ingredient/Ingredient.API/Ingredient.API.csproj"
COPY . .
WORKDIR "/src/Services/Ingredient/Ingredient.API"
RUN dotnet build "Ingredient.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Ingredient.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ingredient.API.dll"]
RUN dotnet Ingredient.API.dll Start-Process -FilePath "powershell" -ArgumentList $args -NoNewWindow
