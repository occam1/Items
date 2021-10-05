CREATE TABLE [a57].[Roles] (
    [Id]        INT          IDENTITY (1, 1) NOT NULL,
    [Name]      VARCHAR (50) NOT NULL,
    [CreatedBy] INT          NOT NULL,
    [CreatedOn] DATE         DEFAULT (getdate()) NOT NULL,
    [ChangedBy] INT          NULL,
    [ChangedOn] DATE         NULL,
    CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED ([Id] ASC)
);

