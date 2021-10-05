CREATE TABLE [a57].[PersonRoleLocations] (
    [Id]         BIGINT       IDENTITY (1, 1) NOT NULL,
    [PersonId]   INT          NOT NULL,
    [RoleId]     INT          NOT NULL,
    [LocationId] INT          NULL,
    [Nickname]   VARCHAR (50) NULL,
    [CreatedBy]  INT          NOT NULL,
    [CreatedOn]  DATE         DEFAULT (getdate()) NOT NULL,
    [ChangedBy]  INT          NULL,
    [ChangedOn]  DATE         NULL,
    CONSTRAINT [PK_PersonRoleLocations] PRIMARY KEY CLUSTERED ([Id] ASC)
);

