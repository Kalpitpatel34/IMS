CREATE TABLE [dbo].[NatureOfInjury] (
    [Id]                INT  NOT NULL,
    [NatureOfActivity]  TEXT NULL,
    [NatureOfInjury]    TEXT NULL,
    [MechanismOfInjury] TEXT NULL,
    [AreaOfInjury]      TEXT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_NatureOfInjury_ToTable] FOREIGN KEY ([Id]) REFERENCES [dbo].[UniqueIdentifiers] ([Id])
);

