FROM microsoft/aspnetcore-build AS builder

WORKDIR /source
COPY *.csproj .
RUN dotnet restore
COPY . .
RUN dotnet publish Tasks.API.csproj --output /app/ --configuration Release

# Stage 2
FROM microsoft/aspnetcore
WORKDIR /app
COPY --from=builder /app .
ENTRYPOINT ["dotnet", "Tasks.API.dll"]
