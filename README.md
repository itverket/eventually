# Event Service
Event service is responsible for the back-end for the event management system. Containing entities and logic needed to manage events, with descriptions, talks, atendees etc.

## Run using docker-compose
- Run `dotnet publish` from event-service directory
- Run `docker-compose up -d --build` to start the devlopment environment. This will start a sql database, run migrations and start the API in docker, on the following exported ports:
    - event-service (port 5000): Swagger documentation can be used for testing and when developing the fron-end, after starting the development server goto http://localhost:5000/swagger/ 
    - sql database: localhost:1433

- To e.g. do development on the event-service API:
    - Stop the docker container by running `docker stop eventually_event-service-api_1`
    - Next go into the event-service/src/Api directory and run `dotnet watch run` to start the dev server.
