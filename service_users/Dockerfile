#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["service_users/service_users.csproj", "service_users/"]
COPY ["userBusiness/userBusiness.csproj", "userBusiness/"]
COPY ["userData/userData.csproj", "userData/"]
COPY ["userContract/userContract.csproj", "userContract/"]
COPY ["TransactionModel/TransactionModel.csproj", "TransactionModel/"]
RUN dotnet restore "service_users/service_users.csproj"
COPY . .
WORKDIR "/src/service_users"
RUN dotnet build "service_users.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "service_users.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "service_users.dll"]
