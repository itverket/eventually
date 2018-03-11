# Event Service
Event service is responsible for the back-end for the event management system. Containing entities and logic needed to manage events, with descriptions, talks, atendees etc.

## Running the api during development 
Prerequisite:
- dotnet core 2.x
- Sql database running at localhost, answering to the following connection string: `Server=localhost;Database=event-mngmnt;User Id=SA; Password=Qwer1234*;`. The database will be created when migrating the database. Use localdb on windows or start a sql database in docker. Running docker-compose up will run a sql image that can be used.


Start in the /event-service directory.
- Restore dependencies (will invoke paket)
`dotnet restore`
- Build solution
`dotnet build`
- Run database migrations (optional: run `docker-compose up` to start sqlserver)
`cd src/database/; dotnet run ; cd ../../`
- Run all tests
`dotnet test`
- Start api server
`cd src/api/; dotnet run; cd ../../`

- Swagger documentation can be used for testing and when developing the fron-end, after starting the development server goto http://localhost:5000/swagger/ .