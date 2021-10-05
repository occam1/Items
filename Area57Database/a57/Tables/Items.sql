CREATE TABLE [a57].[Items] (
    [Id]                BIGINT        IDENTITY (1, 1) NOT NULL,
    [DealerId]          INT           NOT NULL,
    [Name]              VARCHAR (50)  NOT NULL,
    [Description]       VARCHAR (MAX) NOT NULL,
    [Cost]              MONEY         NULL,
    [CurrentPrice]      MONEY         NULL,
    [MinimumPrice]      MONEY         NULL,
    [Manufacturer]      VARCHAR (50)  NULL,
    [ManufacturingLine] VARCHAR (50)  NULL,
    [Keywords]          VARCHAR (MAX) NULL,
    [PricingPlanId]     INT           NULL,
    [IsAvailable]       BIT           NULL,
    [SoldDate]          DATE          NULL,
    [SoldPrice]         MONEY         NULL,
    [IsShippable]       BIT           NULL,
    [Quantity]          INT           NULL,
    [CreatedBy]         INT           NOT NULL,
    [CreatedOn]         DATE          DEFAULT (getdate()) NOT NULL,
    [ChangedBy]         INT           NULL,
    [ChangedOn]         DATE          NULL,
    CONSTRAINT [PK_Items] PRIMARY KEY CLUSTERED ([Id] ASC)
);

