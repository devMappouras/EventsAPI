CREATE TABLE [dbo].[Sections] (
    [SectionId]   INT           NOT NULL,
    [Name]        NVARCHAR (40) NULL,
    [HierarchyId] INT           NULL,
    [VenueId]     INT           NULL,
    CONSTRAINT [PK_Sections] PRIMARY KEY CLUSTERED ([SectionId] ASC),
    CONSTRAINT [FK_Sections_Venues] FOREIGN KEY ([VenueId]) REFERENCES [dbo].[Venues] ([VenueId]),
    CONSTRAINT [FK_Sections_Venues1] FOREIGN KEY ([VenueId]) REFERENCES [dbo].[Venues] ([VenueId])
);

