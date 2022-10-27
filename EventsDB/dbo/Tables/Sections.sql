CREATE TABLE [dbo].[Sections] (
    [SectionId]       INT           IDENTITY (1, 1) NOT NULL,
    [Name]            NVARCHAR (40) NULL,
    [HierarchyId]     INT           NULL,
    [VenueId]         INT           NULL,
    [DefaultCapacity] INT           NULL,
    CONSTRAINT [PK_Sections] PRIMARY KEY CLUSTERED ([SectionId] ASC),
    CONSTRAINT [FK_Sections_Hierarchies] FOREIGN KEY ([HierarchyId]) REFERENCES [dbo].[Hierarchies] ([HierarchyId]),
    CONSTRAINT [FK_Sections_Venues] FOREIGN KEY ([VenueId]) REFERENCES [dbo].[Venues] ([VenueId])
);






GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Unique_Sections_Venues]
    ON [dbo].[Sections]([VenueId] ASC, [HierarchyId] ASC, [Name] ASC);

