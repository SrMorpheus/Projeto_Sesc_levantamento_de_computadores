#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.


FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base

WORKDIR /app
EXPOSE 80
EXPOSE 443
ENV HTTP_PROXY="http://190.120.1.2:3128"
ENV HTTPS_PROXY="https://190.120.1.2:3128"

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["Projeto_Inventáro/Projeto_Inventáro.csproj", "Projeto_Inventáro/"]
RUN dotnet restore "Projeto_Inventáro/Projeto_Inventáro.csproj"
COPY . .
WORKDIR "/src/Projeto_Inventáro"
RUN dotnet build "Projeto_Inventáro.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Projeto_Inventáro.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Projeto_Inventáro.dll"]
