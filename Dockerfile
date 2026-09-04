FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Restore layer: only project/lock files, so code edits don't invalidate it.
COPY LearnAws.sln .
COPY LearnAws/LearnAws.csproj LearnAws/
COPY LearnAws/packages.lock.json LearnAws/
COPY LearnAws.Tests/LearnAws.Tests.csproj LearnAws.Tests/
COPY LearnAws.Tests/packages.lock.json LearnAws.Tests/
RUN dotnet restore --locked-mode

COPY . .
RUN dotnet publish LearnAws/LearnAws.csproj -c Release --no-restore -o /app

FROM mcr.microsoft.com/dotnet/aspnet:10.0
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "LearnAws.dll"]
