CREATE TABLE [a57].[Booths] (
    [Id]        BIGINT        IDENTITY (1, 1) NOT NULL,
    [Name]      NVARCHAR (50) NOT NULL,
    [DealerId]  BIGINT        NULL,
    [Type]      INT           NOT NULL,
    [CreatedBy] INT           NOT NULL,
    [CreatedOn] DATE          DEFAULT (getdate()) NOT NULL,
    [ChangedBy] INT           NULL,
    [ChangedOn] DATE          NULL,
    CONSTRAINT [PK_Booths] PRIMARY KEY CLUSTERED ([Id] ASC)
);

