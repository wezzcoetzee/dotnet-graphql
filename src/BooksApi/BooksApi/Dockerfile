﻿FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["BooksApi/BooksApi.csproj", "BooksApi/"]
RUN dotnet restore "BooksApi/BooksApi.csproj"
COPY . .
WORKDIR "/src/BooksApi"
RUN dotnet build "BooksApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BooksApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BooksApi.dll"]
