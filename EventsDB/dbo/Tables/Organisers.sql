CREATE TABLE [dbo].[Organisers] (
    [OrganiserId]  INT            IDENTITY (1, 1) NOT NULL,
    [Username]     NVARCHAR (50)  NOT NULL,
    [Password]     NVARCHAR (MAX) NOT NULL,
    [PasswordSalt] NVARCHAR (MAX) NOT NULL,
    [Name]         NVARCHAR (100) NOT NULL,
    [Location]     NVARCHAR (100) NOT NULL,
    [Logo]         NVARCHAR (30)  NULL,
    [RoleId]       INT            CONSTRAINT [DF__Organiser__RoleI__2180FB33] DEFAULT ((1)) NULL,
    CONSTRAINT [PK_Organisers] PRIMARY KEY CLUSTERED ([OrganiserId] ASC),
    CONSTRAINT [FK_Organisers_Roles] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[Roles] ([RoleId])
);





