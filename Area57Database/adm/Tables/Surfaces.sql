CREATE TABLE [adm].[Surfaces] (
    [Id]                 BIGINT         IDENTITY (1, 1) NOT NULL,
    [PersonId]           BIGINT         NOT NULL,
    [FurnitureId]        BIGINT         NOT NULL,
    [Description]        NVARCHAR (50)  NULL,
    [Width]              NUMERIC (3, 2) NULL,
    [Depth]              NUMERIC (3, 2) NULL,
    [PositionFromBottom] SMALLINT       NULL,
    [CreatedBy]          INT            NOT NULL,
    [CreatedOn]          DATE           DEFAULT (getdate()) NOT NULL,
    [ChangedBy]          INT            NULL,
    [ChangedOn]          DATE           NULL,
    CONSTRAINT [PK_Surfaces] PRIMARY KEY CLUSTERED ([Id] ASC)
);

