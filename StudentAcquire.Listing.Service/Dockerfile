FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
WORKDIR /app

EXPOSE 5000

COPY *.csproj ./
COPY *.sln ./
RUN dotnet restore

COPY . ./
RUN dotnet publish StudentAcquire.Listing.Service.csproj -c Release -o out
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "StudentAcquire.Listing.Service.dll","--urls","http://*:5000"]
