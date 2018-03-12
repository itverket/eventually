FROM microsoft/aspnetcore-build
COPY /bin/Debug/netcoreapp2.0/publish /db
WORKDIR /db
ENTRYPOINT ["dotnet", "Database.dll", "Server=db;Database=event-mngmnt;User Id=SA;Password=Qwer1234*"]
