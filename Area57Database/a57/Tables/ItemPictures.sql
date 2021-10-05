CREATE TABLE [a57].[ItemPictures] (
    [Id]        BIGINT         IDENTITY (1, 1) NOT NULL,
    [DealerId]  BIGINT         NOT NULL,
    [ItemId]    BIGINT         NOT NULL,
    [altText]   NVARCHAR (40)  NULL,
    [Caption1]  NVARCHAR (200) NULL,
    [Caption2]  NVARCHAR (200) NULL,
    [Path]      NVARCHAR (MAX) NOT NULL,
    [CreatedBy] INT            NOT NULL,
    [CreatedOn] DATE           DEFAULT (getdate()) NOT NULL,
    [ChangedBy] INT            NULL,
    [ChangedOn] DATE           NULL,
    CONSTRAINT [PK_ItemPictures] PRIMARY KEY CLUSTERED ([Id] ASC)
);

