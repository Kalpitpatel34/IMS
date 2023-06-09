CREATE TABLE [dbo].[AdditionalInjuryInformation] (
    [Id]               INT           NOT NULL,
    [TypeOfInjury]     TEXT          NULL,
    [TimeOfInjury]     VARCHAR (500) NULL,
    [GroundSurface]    TEXT          NULL,
    [SeverityOfInjury] TEXT          NULL,
    [DataEnteredBy]    TEXT          NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_AdditionalInjuryInformation_UniqueIdentifiers] FOREIGN KEY ([Id]) REFERENCES [dbo].[UniqueIdentifiers] ([Id])
);

