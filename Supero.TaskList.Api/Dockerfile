FROM mcr.microsoft.com/dotnet/core/aspnet:2.1-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.1-stretch AS build
WORKDIR /src
COPY ["Supero.TaskList.Api/Supero.TaskList.Api.csproj", "Supero.TaskList.Api/"]
COPY ["Supero.TaskList.IoC/Supero.TaskList.IoC.csproj", "Supero.TaskList.IoC/"]
COPY ["Supero.TaskList.Domain/Supero.TaskList.Domain.csproj", "Supero.TaskList.Domain/"]
COPY ["Supero.TaskList.Service/Supero.TaskList.Service.csproj", "Supero.TaskList.Service/"]
COPY ["Supero.TaskList.Data/Supero.TaskList.Data.csproj", "Supero.TaskList.Data/"]
COPY ["Supero.TaskList.Web.Framework/Supero.TaskList.Web.Framework.csproj", "Supero.TaskList.Web.Framework/"]
RUN dotnet restore "Supero.TaskList.Api/Supero.TaskList.Api.csproj"
COPY . .
WORKDIR "/src/Supero.TaskList.Api"
RUN dotnet build "Supero.TaskList.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Supero.TaskList.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Supero.TaskList.Api.dll"]
