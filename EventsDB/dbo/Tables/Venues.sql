CREATE TABLE [dbo].[Venues] (
    [VenueId]  INT            NOT NULL,
    [Name]     NVARCHAR (100) NULL,
    [Location] NVARCHAR (100) NULL,
    CONSTRAINT [PK_Venues] PRIMARY KEY CLUSTERED ([VenueId] ASC)
);