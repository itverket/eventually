FROM microsoft/aspnetcore-build
COPY /bin/Debug/netcoreapp2.0/publish /messageEndpoint
WORKDIR /messageEndpoint

RUN sed -i 's/localhost/db/g' appsettings.json

ENTRYPOINT sleep 5; dotnet MessageEndpoint.dll