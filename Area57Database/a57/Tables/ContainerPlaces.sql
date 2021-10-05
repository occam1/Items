CREATE TABLE [a57].[ContainerPlaces] (
    [Id]            BIGINT IDENTITY (1, 1) NOT NULL,
    [DealerId]      BIGINT NOT NULL,
    [ContainerId]   BIGINT NOT NULL,
    [FurnitureId]   BIGINT NOT NULL,
    [SurfaceId]     BIGINT NULL,
    [SurfaceAreaId] BIGINT NULL,
    [CreatedBy]     INT    NOT NULL,
    [CreatedOn]     DATE   DEFAULT (getdate()) NOT NULL,
    [ChangedBy]     INT    NULL,
    [ChangedOn]     DATE   NULL,
    CONSTRAINT [PK_ContainerPlaces] PRIMARY KEY CLUSTERED ([Id] ASC)
);

