CREATE TABLE [a57].[Locations] (
    [Id]                     BIGINT        IDENTITY (1, 1) NOT NULL,
    [Name]                   VARCHAR (100) NOT NULL,
    [EmailAddress]           VARCHAR (300) NOT NULL,
    [PhoneNumber]            VARCHAR (50)  NULL,
    [AlternativePhoneNumber] VARCHAR (50)  NULL,
    [AddressId]              INT           NOT NULL,
    [TypeId]                 INT           NOT NULL,
    [CreatedBy]              INT           NOT NULL,
    [CreatedOn]              DATE          DEFAULT (getdate()) NOT NULL,
    [ChangedBy]              INT           NULL,
    [ChangedOn]              DATE          NULL,
    CONSTRAINT [PK_Locations] PRIMARY KEY CLUSTERED ([Id] ASC)
);

