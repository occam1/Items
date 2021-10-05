CREATE TABLE [a57].[Addresses] (
    [Id]         BIGINT        IDENTITY (1, 1) NOT NULL,
    [Street1]    VARCHAR (100) NOT NULL,
    [Street2]    VARCHAR (100) NULL,
    [City]       VARCHAR (100) NULL,
    [State]      VARCHAR (50)  NULL,
    [Province]   VARCHAR (100) NULL,
    [Country]    VARCHAR (50)  NOT NULL,
    [PostalCode] VARCHAR (20)  NOT NULL,
    [CreatedBy]  INT           NOT NULL,
    [CreatedOn]  DATE          DEFAULT (getdate()) NOT NULL,
    [ChangedBy]  INT           NULL,
    [ChangedOn]  DATE          NULL,
    CONSTRAINT [PK_Addresses] PRIMARY KEY CLUSTERED ([Id] ASC)
);

