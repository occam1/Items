CREATE TABLE [a57].[Containers] (
    [Id]          BIGINT        IDENTITY (1, 1) NOT NULL,
    [DealerId]    BIGINT        NOT NULL,
    [Name]        NVARCHAR (50) NOT NULL,
    [Description] NVARCHAR (50) NULL,
    [Type]        INT           NULL,
    [CreatedBy]   INT           NOT NULL,
    [CreatedOn]   DATE          DEFAULT (getdate()) NOT NULL,
    [ChangedBy]   INT           NULL,
    [ChangedOn]   DATE          NULL,
    CONSTRAINT [PK_Containers] PRIMARY KEY CLUSTERED ([Id] ASC)
);

