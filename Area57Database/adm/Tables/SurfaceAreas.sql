CREATE TABLE [adm].[SurfaceAreas] (
    [Id]                BIGINT         IDENTITY (1, 1) NOT NULL,
    [PersonId]          BIGINT         NOT NULL,
    [FurnitureId]       BIGINT         NOT NULL,
    [SurfaceId]         BIGINT         NOT NULL,
    [Description]       NVARCHAR (50)  NULL,
    [Width]             NUMERIC (3, 2) NULL,
    [Depth]             NUMERIC (3, 2) NULL,
    [PositionFromLeft]  SMALLINT       NULL,
    [PositionFromFront] SMALLINT       NULL,
    [Type]              NCHAR (10)     NULL,
    [CreatedBy]         INT            NOT NULL,
    [CreatedOn]         DATE           DEFAULT (getdate()) NOT NULL,
    [ChangedBy]         INT            NULL,
    [ChangedOn]         DATE           NULL,
    CONSTRAINT [PK_SurfaceAreas] PRIMARY KEY CLUSTERED ([Id] ASC)
);

