CREATE TABLE [dbo].[Hierarchies] (
    [HierarchyId] INT            NOT NULL,
    [Name]        NVARCHAR (100) NULL,
    CONSTRAINT [PK_Hierarchies] PRIMARY KEY CLUSTERED ([HierarchyId] ASC),
    CONSTRAINT [FK_Hierarchies_Sections] FOREIGN KEY ([HierarchyId]) REFERENCES [dbo].[Sections] ([SectionId])
);

