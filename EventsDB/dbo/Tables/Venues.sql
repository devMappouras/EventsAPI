CREATE TABLE [dbo].[Venues] (
    [VenueId]  INT            NOT NULL IDENTITY(1,1),
    [Name]     NVARCHAR (100) NULL,
    [Location] NVARCHAR (100) NULL,
    CONSTRAINT [PK_Venues] PRIMARY KEY CLUSTERED ([VenueId] ASC)
);