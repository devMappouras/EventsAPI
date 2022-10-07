CREATE TABLE [dbo].[Venues] (
    [VenueId]   INT            IDENTITY (1, 1) NOT NULL,
    [Name]      NVARCHAR (100) NULL,
    [Address]   NVARCHAR (150) NULL,
    [Town]      NVARCHAR (50)  NULL,
    [CountryId] INT            NULL,
    CONSTRAINT [PK_Venues] PRIMARY KEY CLUSTERED ([VenueId] ASC)
);

