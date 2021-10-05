CREATE TABLE [a57].[ItemPlaces] (
    [Id]            BIGINT IDENTITY (1, 1) NOT NULL,
    [DealerId]      BIGINT NOT NULL,
    [ItemId]        BIGINT NOT NULL,
    [FurnitureId]   BIGINT NOT NULL,
    [SurfaceId]     BIGINT NULL,
    [SurfaceAreaId] BIGINT NULL,
    [CreatedBy]     INT    NOT NULL,
    [CreatedOn]     DATE   DEFAULT (getdate()) NOT NULL,
    [ChangedBy]     INT    NULL,
    [ChangedOn]     DATE   NULL,
    CONSTRAINT [PK_ItemPlaces] PRIMARY KEY CLUSTERED ([Id] ASC)
);

