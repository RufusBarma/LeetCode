FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["LeetCode/LeetCode.csproj", "LeetCode/"]
RUN dotnet restore "LeetCode/LeetCode.csproj"
COPY . .
WORKDIR "/src/LeetCode"
RUN dotnet build "LeetCode.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LeetCode.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LeetCode.dll"]
