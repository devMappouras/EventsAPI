CREATE TABLE [dbo].[Products] (
    [ProductId]   INT NOT NULL,
    [VenueId]     INT NOT NULL,
    [Capacity]    INT NOT NULL,
    [OrganiserId] INT NOT NULL,
    [HierarchyId] INT NOT NULL,
    [Price]       INT NOT NULL,
    CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED ([ProductId] ASC),
    CONSTRAINT [FK_Products_Hierarchies] FOREIGN KEY ([HierarchyId]) REFERENCES [dbo].[Hierarchies] ([HierarchyId]),
    CONSTRAINT [FK_Products_Organisers] FOREIGN KEY ([OrganiserId]) REFERENCES [dbo].[Organisers] ([OrganiserId]),
    CONSTRAINT [FK_Products_Venues] FOREIGN KEY ([VenueId]) REFERENCES [dbo].[Venues] ([VenueId])
);



