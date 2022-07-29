CREATE TABLE [dbo].[Organisers] (
    [OrganiserId] INT            NOT NULL,
    [Name]        NVARCHAR (100) NULL,
    [Location]    NVARCHAR (100) NULL,
    [Logo]        NVARCHAR (30)  NULL,
    CONSTRAINT [PK_Organisers] PRIMARY KEY CLUSTERED ([OrganiserId] ASC)
);

