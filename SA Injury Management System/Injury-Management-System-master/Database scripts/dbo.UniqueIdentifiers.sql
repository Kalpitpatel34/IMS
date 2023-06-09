CREATE TABLE [dbo].[UniqueIdentifiers] (
    [Id]             INT           IDENTITY (1, 1) NOT NULL,
    [Name]           VARCHAR (500) NULL,
    [DOB]            DATE          NULL,
    [Sex]            VARCHAR (500) NULL,
    [Date_of_Injury] DATE          NULL,
    [uuid]           CHAR (600)    NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

