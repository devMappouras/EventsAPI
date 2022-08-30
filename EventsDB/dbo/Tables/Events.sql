CREATE TABLE [dbo].[Events] (
    [EventId]          INT                NOT NULL,
    [EventTitle]       NVARCHAR (100)     NULL,
    [EventDescription] NVARCHAR (MAX)     NULL,
    [EventDateTime]    DATETIMEOFFSET (7) NULL,
    [BannerImage]      NVARCHAR (50)      NULL,
    [VenueId]          INT                NULL,
    [CollectionId]     INT                NULL,
    [OrganiserId]      INT                NULL,
    CONSTRAINT [PK_Events] PRIMARY KEY CLUSTERED ([EventId] ASC),
    CONSTRAINT [FK_Events_Collections] FOREIGN KEY ([CollectionId]) REFERENCES [dbo].[Collections] ([CollectionId]),
    CONSTRAINT [FK_Events_Organisers] FOREIGN KEY ([OrganiserId]) REFERENCES [dbo].[Organisers] ([OrganiserId]),
    CONSTRAINT [FK_Events_Organisers1] FOREIGN KEY ([OrganiserId]) REFERENCES [dbo].[Organisers] ([OrganiserId]),
    CONSTRAINT [FK_Events_Venues] FOREIGN KEY ([VenueId]) REFERENCES [dbo].[Venues] ([VenueId])
);




GO


GO



