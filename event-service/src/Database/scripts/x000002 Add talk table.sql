CREATE TABLE Talk
(
    Id UNIQUEIDENTIFIER NOT NULL,
    EventId UNIQUEIDENTIFIER NOT NULL,

    [Name] VARCHAR(200),
    [Description] VARCHAR(MAX),
    Talker VARCHAR(200),
    Duration int,

    PRIMARY KEY (Id),
    FOREIGN KEY (EventId) REFERENCES Event(ID)
)
