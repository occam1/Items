CREATE TABLE [adm].[FurnitureType] (
    [Id]               INT           IDENTITY (1, 1) NOT NULL,
    [Description]      NVARCHAR (50) NOT NULL,
    [NumberOfSurfaces] INT           NULL,
    [CreatedBy]        INT           NOT NULL,
    [CreatedOn]        DATE          DEFAULT (getdate()) NOT NULL,
    [ChangedBy]        INT           NULL,
    [ChangedOn]        DATE          NULL,
    CONSTRAINT [PK_FurnitureType] PRIMARY KEY CLUSTERED ([Id] ASC)
);

