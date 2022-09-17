CREATE TABLE [dbo].[Organisers] (
    [OrganiserId]  INT            NOT NULL IDENTITY(1,1),
    [Username]     NVARCHAR (50)  NULL,
    [Password]     NVARCHAR (MAX) NULL,
    [PasswordSalt] NVARCHAR (MAX) NULL,
    [Name]         NVARCHAR (100) NULL,
    [Location]     NVARCHAR (100) NULL,
    [Logo]         NVARCHAR (30)  NULL,
    [RoleId]       INT            DEFAULT ((1)) NULL,
    CONSTRAINT [PK_Organisers] PRIMARY KEY CLUSTERED ([OrganiserId] ASC),
    CONSTRAINT [FK_Organisers_Roles] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[Roles] ([RoleId])
);

