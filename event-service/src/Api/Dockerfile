FROM microsoft/aspnetcore-build
COPY /bin/Debug/netcoreapp2.0/publish /api
WORKDIR /api

RUN sed -i 's/localhost/db/g' appsettings.json
RUN sed -i 's/localhost/db/g' appsettings.Development.json

RUN sleep 5

EXPOSE 80
ENTRYPOINT sleep 5; dotnet Api.dll