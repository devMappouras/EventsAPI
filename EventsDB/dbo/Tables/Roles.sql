CREATE TABLE [dbo].[Roles] (
    [RoleId]   INT           NOT NULL,
    [RoleName] NVARCHAR (30) NOT NULL,
    CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED ([RoleId] ASC)
);


GO