CREATE TABLE [dbo].[Products] (
    [ProductId]   INT            NOT NULL,
    [SectionId]   INT            NOT NULL,
    [OrganiserId] INT            NOT NULL,
    [Capacity]    INT            NOT NULL,
    [Name]        NVARCHAR (200) NOT NULL,
    CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED ([ProductId] ASC),
    CONSTRAINT [FK_Products_Organisers] FOREIGN KEY ([OrganiserId]) REFERENCES [dbo].[Organisers] ([OrganiserId]),
    CONSTRAINT [FK_Products_Sections] FOREIGN KEY ([SectionId]) REFERENCES [dbo].[Sections] ([SectionId])
);

