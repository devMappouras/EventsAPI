CREATE TABLE [dbo].[Collections] (
    [CollectionId] INT            NOT NULL,
    [Name]         NVARCHAR (100) NULL,
    [OrganiserId]  INT            NOT NULL,
    CONSTRAINT [PK_Collections] PRIMARY KEY CLUSTERED ([CollectionId] ASC),
    CONSTRAINT [FK_Collections_Organisers] FOREIGN KEY ([OrganiserId]) REFERENCES [dbo].[Organisers] ([OrganiserId])
);

