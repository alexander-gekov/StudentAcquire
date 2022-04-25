FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
WORKDIR /app

EXPOSE 6000

COPY *.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish StudentAcquire.User.Service.sln -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "StudentAcquire.User.Service.dll", "--urls", "http://*:6000"]
