CREATE TABLE [dbo].[SupplementaryInjuryMechanism] (
    [Id]                  INT  NOT NULL,
    [InjuryMechanism]     TEXT NULL,
    [ContributingFactors] TEXT NULL,
    [AdditionalSuppData]  TEXT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_SupplementaryInjuryMechanism_UniqueIdentifiers] FOREIGN KEY ([Id]) REFERENCES [dbo].[UniqueIdentifiers] ([Id])
);

