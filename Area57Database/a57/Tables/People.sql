CREATE TABLE [a57].[People] (
    [Id]                     BIGINT        IDENTITY (1, 1) NOT NULL,
    [FirstName]              VARCHAR (100) NOT NULL,
    [MiddleName]             VARCHAR (100) NULL,
    [LastName]               VARCHAR (100) NOT NULL,
    [EmailAddress]           VARCHAR (300) NOT NULL,
    [PasswordLastChanged]    DATE          NOT NULL,
    [PasswordHash]           VARCHAR (MAX) NOT NULL,
    [CurrentWebToken]        VARCHAR (MAX) NULL,
    [PhoneNumber]            VARCHAR (50)  NULL,
    [AlternativePhoneNumber] VARCHAR (50)  NULL,
    [CreatedBy]              INT           NOT NULL,
    [CreatedOn]              DATE          DEFAULT (getdate()) NOT NULL,
    [ChangedBy]              INT           NULL,
    [ChangedOn]              DATE          NULL,
    [AddressId]              INT           NOT NULL,
    CONSTRAINT [PK_People] PRIMARY KEY CLUSTERED ([Id] ASC)
);

