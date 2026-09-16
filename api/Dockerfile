FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Restore layer: only project/lock files, so code edits don't invalidate it.
COPY LearnAws.Api.sln .
COPY LearnAws.Api/LearnAws.Api.csproj LearnAws.Api/
COPY LearnAws.Api/packages.lock.json LearnAws.Api/
COPY LearnAws.Api.Tests/LearnAws.Api.Tests.csproj LearnAws.Api.Tests/
COPY LearnAws.Api.Tests/packages.lock.json LearnAws.Api.Tests/
RUN dotnet restore --locked-mode

COPY . .
RUN dotnet publish LearnAws.Api/LearnAws.Api.csproj -c Release --no-restore -o /app

FROM mcr.microsoft.com/dotnet/aspnet:10.0
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "LearnAws.Api.dll"]
