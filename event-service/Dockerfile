FROM microsoft/aspnetcore-build
COPY . /event-service
WORKDIR /event-service

RUN dotnet restore
RUN dotnet build

# WORKDIR src/Database
# RUN dotnet run "Server=db;Database=event-mngmnt;User Id=SA;Password=Qwer1234*"
# WORKDIR ../../tests/IntegrationTests/Api.IntegrationTests
# RUN dotnet test 
# WORKDIR ../../UnitTests/Api.UnitTest
# RUN dotnet test 

# WORKDIR ../../../src/Api

WORKDIR src/Api
EXPOSE 5000
ENTRYPOINT dotnet run