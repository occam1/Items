CREATE TABLE [adm].[Furniture] (
    [Id]                 BIGINT         IDENTITY (1, 1) NOT NULL,
    [PersonId]           BIGINT         NOT NULL,
    [Description]        NVARCHAR (50)  NOT NULL,
    [Type]               NVARCHAR (50)  NULL,
    [PositionFromLeft]   SMALLINT       NULL,
    [PositionFromFront]  SMALLINT       NULL,
    [PositionFromBottom] SMALLINT       NULL,
    [Width]              NUMERIC (3, 2) NULL,
    [Depth]              NUMERIC (3, 2) NULL,
    [Height]             NUMERIC (3, 2) NULL,
    [CreatedBy]          INT            NOT NULL,
    [CreatedOn]          DATE           DEFAULT (getdate()) NOT NULL,
    [ChangedBy]          INT            NULL,
    [ChangedOn]          DATE           NULL,
    CONSTRAINT [PK_Furniture] PRIMARY KEY CLUSTERED ([Id] ASC)
);

