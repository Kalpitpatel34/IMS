CREATE TABLE [dbo].[LocationAssociatedWithInjury] (
    [Id]                          INT  NOT NULL,
    [PlaceWhereInjuryOccured]     TEXT NULL,
    [SportOrRecreationalActivity] TEXT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_LocationAssociatedWithInjury_UniqueIdentifiers] FOREIGN KEY ([Id]) REFERENCES [dbo].[UniqueIdentifiers] ([Id])
);

