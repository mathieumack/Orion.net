#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/core/aspnet:2.1-nanoserver-1903 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.1-nanoserver-1903 AS build
WORKDIR /src
COPY ["Orion.Net.csproj", ""]
RUN dotnet restore "./Orion.Net.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "Orion.Net.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Orion.Net.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Orion.Net.dll"]
