FROM node:14-alpine as client

WORKDIR /client
COPY ["client/package.json", "./"]
COPY ["client/package-lock.json", "./"]
ENV GENERATE_SOURCEMAP=false
RUN npm ci
COPY ["client/", "./"]
RUN npm run build


FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["server/WebApi/WebApi.csproj", "WebApi/"]
COPY ["server/Domain/Domain.csproj", "Domain/"]
COPY ["server/Application/Application.csproj", "Application/"]
COPY ["server/Infrastructure/Infrastructure.csproj", "Infrastructure/"]

RUN dotnet restore "WebApi/WebApi.csproj"
COPY server/ .
WORKDIR "/src/WebApi"

RUN dotnet build "WebApi.csproj" -c Release -o /app/build
WORKDIR "/src/WebApi.Tests"
RUN dotnet test "WebApi.Tests.csproj"

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS prod
WORKDIR /app
EXPOSE 80
COPY --from=build /app/build ./
COPY --from=client /client/build ./wwwroot
ENTRYPOINT ["dotnet", "WebApi.dll"]
