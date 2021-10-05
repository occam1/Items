CREATE TABLE [a57].[ContainerItems] (
    [Id]          BIGINT IDENTITY (1, 1) NOT NULL,
    [DealerId]    BIGINT NOT NULL,
    [ContainerId] BIGINT NOT NULL,
    [ItemId]      BIGINT NOT NULL,
    [CreatedBy]   INT    NOT NULL,
    [CreatedOn]   DATE   DEFAULT (getdate()) NOT NULL,
    [ChangedBy]   INT    NULL,
    [ChangedOn]   DATE   NULL,
    CONSTRAINT [PK_ContainerItems] PRIMARY KEY CLUSTERED ([Id] ASC)
);

