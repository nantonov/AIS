#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["AIS.API/AIS.API.csproj", "AIS.API/"]
COPY ["AIS.BLL/AIS.BLL.csproj", "AIS.BLL/"]
COPY ["AIS.DAL/AIS.DAL.csproj", "AIS.DAL/"]
RUN dotnet restore "AIS.API/AIS.API.csproj"
COPY . .
WORKDIR "/src/AIS.API"
RUN dotnet build "AIS.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AIS.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AIS.API.dll"]